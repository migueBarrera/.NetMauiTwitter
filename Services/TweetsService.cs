using MauiTwitterApp.Features.Timeline.Models;
using Microsoft.Maui.Essentials;
using Tweetinvi;
using Tweetinvi.Auth;
using Tweetinvi.Models;
using Tweetinvi.Parameters;

namespace MauiTwitterApp.Services;

internal class TweetsService : ITweetsService
{
    private TwitterClient twitterClient;
    private static string CONSUMER_KEY = "NOrHH1VZ3LqQ4djCGmYK4tKJM";
    private static string CONSUMER_SECRET = "5z7QZ29sXettnRDKVMTesK9pa1dEA0zEx2NCckrzYpAeSTk9L4";
    private static string redirectPath = "myapp://";
    private static readonly IAuthenticationRequestStore _myAuthRequestStore = new LocalAuthenticationRequestStore();

    public async Task<IEnumerable<Timeline>> GetUserTimeline()
    {
        IEnumerable<Timeline> timeline = new List<Timeline>();
        try
        {
            var homeTimelineTweets = await twitterClient.Timelines.GetHomeTimelineAsync();
            if (homeTimelineTweets != null)
            {
                timeline = homeTimelineTweets
                    .Select(Timeline.CreateFromItweet)
                    .ToList();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return timeline;
    }

    public async Task<bool> SignInAsync()
    {
        var appClient = new TwitterClient(CONSUMER_KEY, CONSUMER_SECRET);
        var authenticationRequestId = Guid.NewGuid().ToString();

        // Add the user identifier as a query parameters that will be received by `ValidateTwitterAuth`
        var redirectURL = _myAuthRequestStore.AppendAuthenticationRequestIdToCallbackUrl(redirectPath, authenticationRequestId);
        // Initialize the authentication process
        var authenticationRequestToken = await appClient.Auth.RequestAuthenticationUrlAsync(redirectURL);
        // Store the token information in the store
        await _myAuthRequestStore.AddAuthenticationTokenAsync(authenticationRequestId, authenticationRequestToken);

        var authResult = await WebAuthenticator.AuthenticateAsync(
            new Uri(authenticationRequestToken.AuthorizationURL),
            new Uri(redirectPath));


        var isSuccess = await CheckResponse(authResult, authenticationRequestToken);

        return isSuccess;
    }

    private async Task<bool> CheckResponse(WebAuthenticatorResult authResult, Tweetinvi.Models.IAuthenticationRequest authenticationRequestToken)
    {
        IAuthenticatedUser user;
        try
        {
            var appClient = new TwitterClient(CONSUMER_KEY, CONSUMER_SECRET);

            // Extract the information from the redirection url
            var tweetinvi = authResult?.Properties.GetValueOrDefault("tweetinvi_auth_request_id");
            var verifier = authResult?.Properties.GetValueOrDefault("oauth_verifier");
            var path = redirectPath + $"?tweetinvi_auth_request_id={tweetinvi}&oauth_verifier={verifier}";
            var requestParameters = await RequestCredentialsParameters.FromCallbackUrlAsync(path, _myAuthRequestStore);
            // Request Twitter to generate the credentials.
            var userCreds = await appClient.Auth.RequestCredentialsAsync(requestParameters);

            // Congratulations the user is now authenticated!
            twitterClient = new TwitterClient(userCreds);
            user = await twitterClient.Users.GetAuthenticatedUserAsync();
        }
        catch (Exception)
        {
            return false;
        }

        return user != null;
    }

    public async Task<Client> GetClientAsync()
    {
        var user = await twitterClient.Users.GetAuthenticatedUserAsync();
        return Client.Create(user);
    }
}

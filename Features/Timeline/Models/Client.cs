using Tweetinvi.Models;

namespace MauiTwitterApp.Features.Timeline.Models;

public class Client
{
    public string Email { get; set; }
    public string Image { get; set; }
    internal static Client Create(IAuthenticatedUser user)
    {
        return new Client()
        {
            Email = user.Email,
            Image = user.ProfileImageUrl,
        };
    }
}

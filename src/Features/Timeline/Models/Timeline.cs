using Tweetinvi.Models;

namespace MauiTwitterApp.Features.Timeline.Models;

public class Timeline
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string UserImage { get; set; }
    public string UserName { get; set; }
    public string UserTweeterName { get; set; }
    public string ElapsedTime { get; set; }
    public int CountReteet { get; set; }
    public int CountMessages { get; set; }
    public int CountFavorites { get; set; }
    public bool IsAThread { get; set; }
    public bool IsFavorited { get; set; }
    public bool IsRetweet { get; set; }

    public ITweet Tweet { get; set; }

    internal Timeline CreateFakeContent()
    {
        this.Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. " +
            "Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.";
        this.ElapsedTime = "2h";
        this.UserImage = Random.Shared.NextDouble() >= 0.5 ? "https://www.pixinvent.com/materialize-material-design-admin-template/laravel/demo-4/images/user/12.jpg" : "https://cdn1.iconfinder.com/data/icons/avatar-97/32/avatar-02-512.png";
        this.UserTweeterName = Random.Shared.NextDouble() >= 0.5 ? "@nombrePrueba" : "@default";
        this.UserName = Random.Shared.NextDouble() >= 0.5 ? "Mi nombre" : "Default";
        this.Id = Random.Shared.NextInt64();
        this.CountFavorites = Random.Shared.Next(0,255);
        this.CountMessages = Random.Shared.Next(0, 255);
        this.CountReteet = Random.Shared.Next(0, 255);
        this.IsAThread = Random.Shared.NextDouble() >= 0.5;
        return this;
    }

    internal static Timeline CreateFromItweet(ITweet tweet)
    {
        return new Timeline()
        {
            Content = tweet.IsRetweet ? tweet.RetweetedTweet?.Text : tweet.Text,
            CountReteet = (tweet.IsRetweet ? tweet.RetweetedTweet?.RetweetCount : tweet.RetweetCount) ?? 0,
            CountFavorites = (tweet.IsRetweet ? tweet.RetweetedTweet?.FavoriteCount : tweet.FavoriteCount) ?? 0,
            CountMessages = (tweet.IsRetweet ? tweet.RetweetedTweet?.ReplyCount : tweet.ReplyCount) ?? 0,
            IsAThread = tweet.UserMentions?.Any() ?? false, //No es correcto
            IsFavorited = tweet.Favorited,
            ElapsedTime = tweet.CreatedAt.ToString("d"),
            Id = tweet.Id,
            UserImage = tweet.IsRetweet ? tweet.RetweetedTweet?.CreatedBy?.ProfileImageUrl : tweet.CreatedBy?.ProfileImageUrl,
            UserName = tweet.IsRetweet ? tweet.RetweetedTweet?.CreatedBy?.Name : tweet.CreatedBy?.Name,
            UserTweeterName = tweet.IsRetweet ? tweet.RetweetedTweet?.CreatedBy?.ScreenName : tweet.CreatedBy?.ScreenName,
            IsRetweet = tweet.IsRetweet,
            Tweet = tweet,
            Title = tweet.IsRetweet ? $"{tweet.CreatedBy?.Name} lo retwitteó" : "Puede ser me gusta o tweet normal"
    };
    }
}

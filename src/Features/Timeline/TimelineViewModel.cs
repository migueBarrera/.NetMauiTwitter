using MauiTwitterApp.Features.Timeline.Models;
using MauiTwitterApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using MvvmHelpers.Interfaces;

namespace MauiTwitterApp.Features.Timeline;

public class TimelineViewModel : BaseViewModel
{
    private readonly ITweetsService tweetsService;
    public IAsyncCommand<Models.Timeline> ShowThreadCommand { get; set; }
    public IAsyncCommand<Models.Timeline> RetweetCommand { get; set; }
    public IAsyncCommand<Models.Timeline> CommentCommand { get; set; }
    public IAsyncCommand<Models.Timeline> ShareCommand { get; set; }
    public IAsyncCommand<Models.Timeline> FavoriteCommand { get; set; }

    private Client client;
    private IEnumerable<Models.Timeline> _timeline;

    public Client Client
    {
        get { return client; }
        set { SetProperty(ref client, value); }
    }
    public IEnumerable<Models.Timeline> Timeline
    {
        get { return _timeline; }
        set { SetProperty(ref _timeline, value); }
    }

    public TimelineViewModel()
    {
        tweetsService = ServicesProvider.GetService<ITweetsService>();
        ShowThreadCommand = new AsyncCommand<Models.Timeline>(ShowThreadCommandExecute);
        RetweetCommand = new AsyncCommand<Models.Timeline>(RetweetCommandExecute);
        CommentCommand = new AsyncCommand<Models.Timeline>(CommentCommandExecute);
        FavoriteCommand = new AsyncCommand<Models.Timeline>(FavoriteCommandExecute);
        ShareCommand = new AsyncCommand<Models.Timeline>(ShareCommandExecute);
        LoadDataAsync();
    }

    private async Task LoadDataAsync()
    {
        IsBusy = true;
        Client = await tweetsService.GetClientAsync();
        Timeline = await tweetsService.GetUserTimeline();
        IsBusy = false;
    }

    private async Task ShareCommandExecute(Models.Timeline arg)
    {
        await App.Current.MainPage.DisplayAlert("Hey", "Hey", "Ok");
    }

    private async Task CommentCommandExecute(Models.Timeline arg)
    {
        await App.Current.MainPage.DisplayAlert("Hey", "Hey", "Ok");
    }

    private async Task FavoriteCommandExecute(Models.Timeline arg)
    {
        await App.Current.MainPage.DisplayAlert("Hey", "Hey", "Ok");
    }

    private async Task RetweetCommandExecute(Models.Timeline arg)
    {
        await App.Current.MainPage.DisplayAlert("Hey", "Hey", "Ok");
    }

    private async Task ShowThreadCommandExecute(Models.Timeline timeline)
    {
        await App.Current.MainPage.DisplayAlert("Hey", "Hey", "Ok");
    }
}

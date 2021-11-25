using MauiTwitterApp.Features.Home;
using MauiTwitterApp.Services;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System.Windows.Input;

namespace MauiTwitterApp.Features.OnBoarding;

internal class OnBoardingViewModel : BaseViewModel
{
    private readonly ITweetsService tweetsService;
    public ICommand SignIn { get; set; }

    public OnBoardingViewModel()
    {
        tweetsService = ServicesProvider.GetService<ITweetsService>();
        SignIn = new AsyncCommand(GoToSignInExecuteAsync);
    }

    private async Task GoToSignInExecuteAsync()
    {
        var result = await tweetsService.SignInAsync();
        if (result)
        {
            App.Current.MainPage = new HomePage();
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("Opps", "Algo salio mal", "Ok");
        }
    }
}

using MauiTwitterApp.Features.OnBoarding;
using Microsoft.Maui.Controls;
using Application = Microsoft.Maui.Controls.Application;

namespace MauiTwitterApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new OnBoardingPage());
    }
}

using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace MauiTwitterApp
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();
		}

		private async void OnCounterClicked(object sender, EventArgs e)
		{
			await Temp.ExecuteClicked();
		}
	}
}

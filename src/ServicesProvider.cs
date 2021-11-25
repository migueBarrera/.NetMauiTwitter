﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using System;

namespace MauiTwitterApp
{
    public static class ServicesProvider
	{
		public static TService GetService<TService>()
			=> Current.GetService<TService>();

		private static IServiceProvider Current
			=>
#if WINDOWS10_0_17763_0_OR_GREATER
			MauiWinUIApplication.Current.Services;
#elif ANDROID
			MauiApplication.Current.Services;
#elif IOS || MACCATALYST
			MauiUIApplicationDelegate.Current.Services;
#else
			null;
#endif
	}
}
﻿
namespace DiagramApp.Client
{
    public partial class App : Microsoft.Maui.Controls.Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            LoadPreferedTheme();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window =  base.CreateWindow(activationState);
#if WINDOWS

            const int minimalWidth = 1280;
            const int minimalHeight = 800;

            window.MinimumWidth = minimalWidth;
            window.MinimumHeight = minimalHeight;

#endif
            return window;
        }

        private void LoadPreferedTheme() => Current!.UserAppTheme = (AppTheme)Enum.Parse(typeof(AppTheme), Preferences.Get("AppTheme", "Unspecified"));
    }
}

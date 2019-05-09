﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TCSS_WindowsApp.Activation;
using TCSS_WindowsApp.Core.Helpers;
using TCSS_WindowsApp.Core.Services;

using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace TCSS_WindowsApp.Services
{
    // For more information on application activation see https://github.com/Microsoft/WindowsTemplateStudio/blob/master/docs/activation.md
    internal class ActivationService
    {
        private readonly App _app;
        private readonly Type _defaultNavItem;
        private Lazy<UIElement> _shell;

        private object _lastActivationArgs;

        private IdentityService IdentityService => Singleton<IdentityService>.Instance;

        private UserDataService UserDataService => Singleton<UserDataService>.Instance;

        public ActivationService(App app, Type defaultNavItem, Lazy<UIElement> shell = null)
        {
            _app = app;
            _shell = shell;
            _defaultNavItem = defaultNavItem;
            IdentityService.LoggedIn += OnLoggedIn;
        }

        public async Task ActivateAsync(object activationArgs)
        {
            if (IsInteractive(activationArgs))
            {
                // Initialize things like registering background task before the app is loaded
                await InitializeAsync();
                UserDataService.Initialize();
                IdentityService.InitializeWithAadAndPersonalMsAccounts();
                var silentLoginSuccess = await IdentityService.AcquireTokenSilentAsync();
                if (!silentLoginSuccess || !IdentityService.IsAuthorized())
                {
                    await RedirectLoginPageAsync();
                }

                // Do not repeat app initialization when the Window already has content,
                // just ensure that the window is active
                if (Window.Current.Content == null)
                {
                    // Create a Frame to act as the navigation context and navigate to the first page
                    Window.Current.Content = _shell?.Value ?? new Frame();
                }
            }

            if (IdentityService.IsLoggedIn())
            {
                await HandleActivationAsync(activationArgs);
            }

            _lastActivationArgs = activationArgs;

            if (IsInteractive(activationArgs))
            {
                // Ensure the current window is active
                Window.Current.Activate();

                // Tasks after activation
                await StartupAsync();
            }
        }

        private async void OnLoggedIn(object sender, EventArgs e)
        {
            if (_shell?.Value != null)
            {
                Window.Current.Content = _shell.Value;
            }
            else
            {
                var frame = new Frame();
                Window.Current.Content = frame;
                NavigationService.Frame = frame;
            }

            await ThemeSelectorService.SetRequestedThemeAsync();
            await HandleActivationAsync(_lastActivationArgs);
        }

        private async Task InitializeAsync()
        {
            await ThemeSelectorService.InitializeAsync();
        }

        private async Task HandleActivationAsync(object activationArgs)
        {
            var activationHandler = GetActivationHandlers()
                                                .FirstOrDefault(h => h.CanHandle(activationArgs));

            if (activationHandler != null)
            {
                await activationHandler.HandleAsync(activationArgs);
            }

            if (IsInteractive(activationArgs))
            {
                var defaultHandler = new DefaultLaunchActivationHandler(_defaultNavItem);
                if (defaultHandler.CanHandle(activationArgs))
                {
                    await defaultHandler.HandleAsync(activationArgs);
                }
            }
        }

        private async Task StartupAsync()
        {
            await ThemeSelectorService.SetRequestedThemeAsync();
        }

        private IEnumerable<ActivationHandler> GetActivationHandlers()
        {
            yield return Singleton<SuspendAndResumeService>.Instance;
        }

        private bool IsInteractive(object args)
        {
            return args is IActivatedEventArgs;
        }

        public async Task RedirectLoginPageAsync()
        {
            var frame = new Frame();
            NavigationService.Frame = frame;
            Window.Current.Content = frame;
            await ThemeSelectorService.SetRequestedThemeAsync();
            NavigationService.Navigate<Views.LogInPage>();
        }

        public void SetShell(Lazy<UIElement> shell)
        {
            _shell = shell;
        }
    }
}

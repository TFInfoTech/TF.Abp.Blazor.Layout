using AntDesign;
using AntDesign.Pro.Layout;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Localization;
using Volo.Abp.UI.Navigation;

namespace TF.Abp.Blazor.Layout.AntDesignTheme.Themes.Basic
{
    public partial class MainLayout : IDisposable
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] protected IMenuManager MenuManager { get; set; }
        [Inject] protected HttpClient HttpClient { get; set; }
        [Inject] public ILogger<MainLayout> Logger { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }
        [Inject] ILanguageProvider LanguageProvider { get; set; }

        private MenuDataItem[] _menuData = { };
        private bool IsCollapseShown { get; set; }
        private string[] Locales { get; set; }
        private IDictionary<string, string> LanguageLabels { get; set; }
        private IDictionary<string, string> LanguageIcons { get; set; }
        private IReadOnlyList<LanguageInfo> _otherLanguages;
        private LanguageInfo _currentLanguage;

        protected override void OnInitialized()
        {
            Logger.LogInformation("start to ini layout");
            NavigationManager.LocationChanged += OnLocationChanged;

        }
        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation("start to ini layout async");
            await base.OnInitializedAsync();
            await IniMainMenu();
            await IniLanguages();
        }

        private async Task IniMainMenu ()
        {
            //_menuData = await HttpClient.GetFromJsonAsync<MenuDataItem[]>("data/menu.json");
            ApplicationMenu menu = await MenuManager.GetAsync(StandardMenus.Main);

            //_menuData = new MenuDataItem[1];
            //MenuDataItem item = new MenuDataItem();
            //item.Path = "/";
            //item.Name = "Dashboard";
            //item.Key = "dashboard";
            //item.Icon = "dashboard";
            //_menuData [0] = item;

            if (menu != null)
            {
                _menuData = GetMenuDataItems(menu.Items);
            }
        }
        private async Task IniLanguages()
        {
            var selectedLanguageName = await JsRuntime.InvokeAsync<string>(
                "localStorage.getItem",
                "Abp.SelectedLanguage"
                );

            _otherLanguages = await LanguageProvider.GetLanguagesAsync();

            if (!_otherLanguages.Any())
            {
                return;
            }

            if (!selectedLanguageName.IsNullOrWhiteSpace())
            {
                _currentLanguage = _otherLanguages.FirstOrDefault(l => l.UiCultureName == selectedLanguageName);
            }

            if (_currentLanguage == null)
            {
                _currentLanguage = _otherLanguages.FirstOrDefault(l => l.UiCultureName == CultureInfo.CurrentUICulture.Name);
            }

            if (_currentLanguage == null)
            {
                _currentLanguage = _otherLanguages.FirstOrDefault();
            }

            //language menu
            List<string> _locales = new List<string>();
            LanguageLabels = new Dictionary<string, string>();
            LanguageIcons = new Dictionary<string, string>();
            foreach (LanguageInfo language in _otherLanguages)
            {
                Logger.LogInformation("language:{0}", language.CultureName);
                _locales.Add(language.CultureName);
                LanguageLabels.Add(language.CultureName, language.DisplayName);
                LanguageIcons.Add(language.CultureName, language.FlagIcon);
            }
            this.Locales = _locales.ToArray();
            _otherLanguages = _otherLanguages.Where(l => l != _currentLanguage).ToImmutableList();

        }

        private MenuDataItem[] GetMenuDataItems(ApplicationMenuItemList menuItems)
        {
            if (menuItems != null && menuItems.Count > 0)
            {
                MenuDataItem[] antMenuItems;
                antMenuItems = new MenuDataItem[menuItems.Count];
                for (int i = 0; i < antMenuItems.Length; i++)
                {
                    MenuDataItem item = new MenuDataItem();
                    item.Path = menuItems[i].Url;
                    item.Name = menuItems[i].DisplayName;
                    item.Key = menuItems[i].Name;
                    item.Icon = menuItems[i].Icon;
                    antMenuItems[i] = item;

                    if (menuItems[i].Items != null && menuItems[i].Items.Count > 0)
                    {
                        antMenuItems[i].Children = GetMenuDataItems(menuItems[i].Items);
                    }
                }
                return antMenuItems;
            }
            return null;
        }

        private async Task ChangeLanguageAsync (MenuItem item)//(LanguageInfo language)
        {
            Logger.LogInformation("menu clicked =>{0}", item.Key);

            await JsRuntime.InvokeVoidAsync(
                "localStorage.setItem",
                "Abp.SelectedLanguage", new LanguageInfo(item.Key, item.Key, "").UiCultureName 
                );

            await JsRuntime.InvokeVoidAsync("location.reload");
        }

        private void ToggleCollapse()
        {
            IsCollapseShown = !IsCollapseShown;
        }

        public void Dispose()
        {
            //NavigationManager.LocationChanged -= OnLocationChanged;
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            IsCollapseShown = false;
            StateHasChanged();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntDesign.Pro.Layout;
using Microsoft.AspNetCore.Components;
using AntDesign;
using Volo.Abp.Users;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using Volo.Abp.Localization;
using System;
using System.Globalization;
using System.Collections.Immutable;
using Microsoft.Extensions.Options;
using TF.Abp.Blazor.Layout.AntDesignTheme.Setting;
using Microsoft.Extensions.Localization;
using TF.Abp.Blazor.Layout.Localization;
using Localization.Resources.AbpUi;

namespace TF.Abp.Blazor.Layout.AntDesignTheme.Themes.Basic
{
    public partial class RightContent
    {
        [Inject] IOptions<TFAntDesignSettings> SettingState { get; set; }
        [Inject] public ILogger<RightContent> Logger { get; set; }
        [Inject] IJSRuntime JsRuntime { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] ICurrentUser CurrentUser { get; set; }
        //[Inject] protected IProjectService ProjectService { get; set; }
        [Inject] protected MessageService MessageService { get; set; }
        [Inject] ILanguageProvider LanguageProvider { get; set; }
        [Inject] IStringLocalizer<AbpUiResource> L { get; set; }

        private NoticeIconData[] _notifications = { };
        private NoticeIconData[] _messages = { };
        private NoticeIconData[] _events = { };
        private int _count = 0;
        private string UserAvatar { get; set; }

        private bool IsMultiLanguage { get { return Locales != null && Locales.Length > 1; } }
        private string[] Locales { get; set; }
        private IDictionary<string, string> LanguageLabels { get; set; }
        private IDictionary<string, string> LanguageIcons { get; set; }
        private IReadOnlyList<LanguageInfo> _otherLanguages;
        private LanguageInfo _currentLanguage;

        [Parameter] public EventCallback<MenuItem> OnUserItemSelected { get; set; }
        private List<AutoCompleteDataItem<string>> DefaultOptions { get; set; } = new List<AutoCompleteDataItem<string>>
        {
            new AutoCompleteDataItem<string>
            {
                Label = "umi ui",
                Value = "umi ui"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Table",
                Value = "Pro Table"
            },
            new AutoCompleteDataItem<string>
            {
                Label = "Pro Layout",
                Value = "Pro Layout"
            }
        };


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await IniLanguages();
            IniUserInformation();
            SetClassMap();
            //_currentUser = await UserService.GetCurrentUserAsync();
            //var notices = await ProjectService.GetNoticesAsync();
            //_notifications = notices.Where(x => x.Type == "notification").Cast<NoticeIconData>().ToArray();
            //_messages = notices.Where(x => x.Type == "message").Cast<NoticeIconData>().ToArray();
            //_events = notices.Where(x => x.Type == "event").Cast<NoticeIconData>().ToArray();
            //_count = notices.Length;
        }

        protected void SetClassMap()
        {
            ClassMapper
                .Clear()
                .Add("right");
        }

        public void HandleSelectUser(MenuItem item)
        {
            switch (item.Key)
            {
                case "center":
                    NavigationManager.NavigateTo("/account/center");
                    break;
                case "setting":
                    NavigationManager.NavigateTo("/account/settings");
                    break;
                case "logout":
                    NavigationManager.NavigateTo("/user/login");
                    break;
            }
        }
        private void IniUserInformation()
        {
            UserAvatar = "https://gw.alipayobjects.com/zos/antfincdn/XAosXuNZyF/BiazfanxmamNRoxxVxka.png";
            if (CurrentUser.IsAuthenticated)
            {
                string avatar = CurrentUser.FindClaimValue("Avatar");
                Logger.LogDebug("avatar =>{0}", avatar);
                if (avatar != null)
                {
                    UserAvatar = avatar;
                }
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
                Logger.LogDebug("language:{0}", language.CultureName);
                _locales.Add(language.CultureName);
                LanguageLabels.Add(language.CultureName, language.FlagIcon);
                LanguageIcons.Add(language.CultureName, language.DisplayName);
            }
            this.Locales = _locales.ToArray();
            _otherLanguages = _otherLanguages.Where(l => l != _currentLanguage).ToImmutableList();

        }


        private async Task HandleSelectLang(MenuItem item)
        {
            Logger.LogDebug("menu clicked =>{0}", item.Key);

            await JsRuntime.InvokeVoidAsync(
                "localStorage.setItem",
                "Abp.SelectedLanguage", new LanguageInfo(item.Key, item.Key, "").UiCultureName
                );

            await JsRuntime.InvokeVoidAsync("location.reload");
        }

        public async Task HandleClear(string key)
        {
            switch (key)
            {
                case "notification":
                    _notifications = new NoticeIconData[] { };
                    break;
                case "message":
                    _messages = new NoticeIconData[] { };
                    break;
                case "event":
                    _events = new NoticeIconData[] { };
                    break;
            }
            await MessageService.Success($"清空了{key}");
        }

        public async Task HandleViewMore(string key)
        {
            await MessageService.Info("Click on view more");
        }

        private void OnClickLogin()
        {
            NavigationManager.NavigateTo("/authentication/login");
        }

    }
}
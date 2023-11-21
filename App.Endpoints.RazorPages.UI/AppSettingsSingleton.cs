namespace App.Endpoints.RazorPages.UI
{
    public class AppSettingsSingleton
    {
        public AppSettings AppSettings { get; }

        private static AppSettingsSingleton _instance;

        private AppSettingsSingleton(AppSettings appSettings)
        {
            AppSettings = appSettings;
        }

        public static AppSettingsSingleton Instance => _instance ??= new AppSettingsSingleton(new AppSettings());
    }
}

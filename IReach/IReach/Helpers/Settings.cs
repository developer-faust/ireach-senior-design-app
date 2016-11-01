// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace IReach.Helpers
{
/// <summary>
/// This is the Settings static class that can be used in your Core solution or in any
/// of your client applications. All settings are laid out the same exact way with getters
/// and setters. 
/// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        private const string CalorieTargetKey = "calorie_target_key";
        private static double CalorieTargetDefault = 1800.0;

        private const string UserNameKey = "username_key";
        private static readonly string UserNameDefault = string.Empty;

        private const string PasswordKey = "password_key";
        private static readonly string PasswordDefault = string.Empty;

        private const string UseUseKilometeresKey = "usekilometers_key";
        private static readonly bool UseKilometeresDefault = false;

        private const string StepGoalKey = "stepgoal_key";
        private static readonly int StepGoalDefault = 1000;
        #endregion

        public static int StepGoal
        {
            get { return AppSettings.GetValueOrDefault<int>(StepGoalKey, StepGoalDefault); }
            set { AppSettings.AddOrUpdateValue<int>(StepGoalKey, value); }
        }
        public static bool UseKilometers
        {
            get { return AppSettings.GetValueOrDefault<bool>(UseUseKilometeresKey, UseKilometeresDefault); }
            set { AppSettings.AddOrUpdateValue<bool>(UseUseKilometeresKey, value); }
        }
        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
            }
        }

        public static double TargetCalorieSettings
        {
            get { return AppSettings.GetValueOrDefault<double>(CalorieTargetKey, CalorieTargetDefault); }
            set { AppSettings.AddOrUpdateValue<double>(CalorieTargetKey, value); }
        }

        public static string UserName
        {
                get { return AppSettings.GetValueOrDefault<string>(UserNameKey, UserNameDefault); }
                set { AppSettings.AddOrUpdateValue<string>(UserNameKey, value); }
        }

        public static string Password
        {
            get { return AppSettings.GetValueOrDefault<string>(PasswordKey, PasswordDefault); }
            set { AppSettings.AddOrUpdateValue<string>(PasswordKey, value); }
        }
    }
}
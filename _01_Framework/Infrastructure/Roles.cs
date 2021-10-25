namespace _01_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Administrator = "1";
        public const string SystemUser = "2";
        public const string ContentUploader = "3";
        public const string ColleagueUser = "4";

        public static string GetRoleBy(long id)
        {
            switch (id)
            {
                case 1: return "مدیر سیستم";
                case 2: return "کاربر سیستم";
                case 3: return "محتوی‌گذار";
                case 4: return "همکار";
                default: return "";
            }
        }
    }
}

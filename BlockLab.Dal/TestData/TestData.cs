namespace BlockLab.Dal.TestData;

public static class TestData
{
    public static class AdminRole
    {
        public static string Name = "admins";
        public static string Description = "Администраторы";
    }
    public static class UserRole
    {
        public static string Name = "labs";
        public static string Description = "Лаборанты";
    }
    public static class Admin
    {
        public static string Username = "admin";
        public static string Email = "admin@example.com";
        public static string Password = "secret";
        public static string Rolename = "admins";
    }
    public static class User
    {
        public static string Username = "lab";
        public static string Email = "lab@example.com";
        public static string Password = "123";
        public static string Rolename = "labs";
    }
}


namespace Warehouse
{
    public static class CurrentUser
    {
        public static int Id { get; set; }
        public static string Login { get; set; }
        public static string Role { get; set; }

        public static bool IsAdmin => Role == "Администратор";
        public static bool IsStorekeeper => Role == "Кладовщик";
    }
}

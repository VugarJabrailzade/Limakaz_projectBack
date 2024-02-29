namespace Limakaz.Contracts
{
    public enum Role
    {
        User,
        SuperAdmin,
        Moderator

    }

    public static class RoleNames
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Moderator = "Moderator";
        public const string User = "User";
    }
}

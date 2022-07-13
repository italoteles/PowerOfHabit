namespace PowerOfHabit.Domain.Entities
{
    public sealed class User
    {
        public int UserId { get; private set; }
        public string UserPassword { get; private set; }
        public string UserFullName { get; private set; }
        public bool UserActived { get; private set; }
        public int RoleId { get; set; }
        public Role Role{ get; set; }

        public User(int userId, string userPassword, string userFullName, bool userActived, int roleId, Role role)
        {
            UserId = userId;
            UserPassword = userPassword;
            UserFullName = userFullName;
            UserActived = userActived;
            RoleId = roleId;
            Role = role;
        }
    }
}

using PowerOfHabit.Domain.Validation;

namespace PowerOfHabit.Domain.Entities
{
    public sealed class User
    {
        public int UserId { get; private set; }
        public string UserPassword { get; private set; }
        public string UserName { get; private set; }
        public string UserFullName { get; private set; }
        public bool UserActived { get; private set; }
        public int RoleId { get; set; }
        public Role Role{ get; set; }

        public User(int userId, string userPassword,string userName, string userFullName, bool userActived)
        {
            DomainExceptionValidation.When(userId < 0, "Invalid Id value");
            UserId = userId;
            ValidateDomain(userPassword, userName, userFullName, userActived);
        }
        public User(string userPassword, string userName, string userFullName, bool userActived)
        {
            ValidateDomain(userPassword, userName, userFullName, userActived);
        }

        public void Update(string userPassword, string userName, string userFullName, bool userActived, int roleID)
        {
            ValidateDomain(userPassword, userName, userFullName, userActived);
            RoleId = roleID;
        }
        public void ValidateDomain(string userPassword, string userName, string userFullName, bool userActived)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(userPassword), "Invalid Name. User name is required!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(userName), "Invalid Name. User name is required!");
            DomainExceptionValidation.When(userName.Length < 3, "Invalid user name. Minimum 3 characters!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(userFullName), "Invalid Name. User name is required!");

            UserPassword = userPassword;
            UserName = userName;
            UserFullName = userFullName;
            UserActived = userActived;
        }
    }
}

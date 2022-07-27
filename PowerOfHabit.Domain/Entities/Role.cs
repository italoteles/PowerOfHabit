using PowerOfHabit.Domain.Validation;

namespace PowerOfHabit.Domain.Entities
{
    public sealed class Role
    {
        public int RoleId { get; private set; }
        public string RoleName { get; private set; }
        public ICollection<User> Users {get; set;}

        public Role(string roleName)
        {
            ValidateDomain(roleName);
        }
        public Role(int roleId, string roleName)
        {
            
            DomainExceptionValidation.When(RoleId < 0, "Invalid Id value");
            RoleId = roleId;
            ValidateDomain(roleName);
        }

        public void Update(string roleName)
        {
            ValidateDomain(roleName);
        }

        private void ValidateDomain(string roleName)
        {
            
            DomainExceptionValidation.When(string.IsNullOrEmpty(roleName), "Invalid role Name. Name is required!");

            DomainExceptionValidation.When(roleName.Length < 3, "Invalid Name. Minimum 3 characters!");

            RoleName = roleName;

        } 
        
    }
}

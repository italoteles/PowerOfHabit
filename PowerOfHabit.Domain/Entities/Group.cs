using PowerOfHabit.Domain.Validation;

namespace PowerOfHabit.Domain.Entities
{
    public sealed class Group
    {
        public int GroupId { get; private set; }
        public string GroupName { get; private set; }
        public string GroupDescription { get; private set; }
        public string GroupAmountUnit { get; private set; }
        public ICollection<User> Users { get; set; }

        public Group(int groupId, string groupName, string groupDescription, string groupAmountUnit)
        {
            DomainExceptionValidation.When(groupId < 0, "Invalid Id value");
            GroupId = groupId;
            ValidateDomain(groupName, groupDescription, groupAmountUnit);
        }

        public Group(string groupName, string groupDescription, string groupAmountUnit)
        {

            ValidateDomain(groupName, groupDescription, groupAmountUnit);
            
        }
        public void Update(string groupName, string groupDescription, string groupAmountUnit)
        {

            ValidateDomain(groupName, groupDescription, groupAmountUnit);

        }

        public void ValidateDomain(string groupName, string groupDescription, string groupAmountUnit)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(groupName), "Invalid Name. User name is required!");
            GroupName = groupName;
            GroupDescription = groupDescription;
            GroupAmountUnit = groupAmountUnit;
        }

    }
}

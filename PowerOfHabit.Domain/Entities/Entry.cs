using PowerOfHabit.Domain.Validation;

namespace PowerOfHabit.Domain.Entities
{
    public sealed class Entry
    {
        public int EntryId { get; private set; }
        public DateOnly EntryDate { get; private set; }
        public double EntryAmount { get; private set; }
        public DateTime EntryDateRegistration { get; private set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public Entry(int entryId, DateOnly entryDate, double entryAmount, DateTime entryDateRegistration)
        {
            DomainExceptionValidation.When(entryId < 0, "Invalid Id value!");
            EntryId = entryId;
            ValidateDomain(entryDate, entryAmount, entryDateRegistration);

        }

        public Entry(DateOnly entryDate, double entryAmount, DateTime entryDateRegistration)
        {
            ValidateDomain(entryDate, entryAmount, entryDateRegistration);

        }
        public void Update(DateOnly entryDate, double entryAmount, DateTime entryDateRegistration, int groupId, int userId)
        {
            ValidateDomain(entryDate, entryAmount, entryDateRegistration);
            GroupId = groupId;
            UserId = userId;

        }

        public void ValidateDomain(DateOnly entryDate, double entryAmount, DateTime entryDateRegistration)
        {
            DomainExceptionValidation.When(entryAmount == 0, "Amount has to be different from 0!");
            EntryDate = entryDate;
            EntryAmount = entryAmount;
            EntryDateRegistration = entryDateRegistration;

        }
    }
}

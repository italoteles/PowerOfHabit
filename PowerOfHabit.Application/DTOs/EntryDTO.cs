
namespace PowerOfHabit.Application.DTOs
{
    public class EntryDTO
    {
        public int EntryId { get; set; }
        public DateOnly EntryDate { get; set; }
        public double EntryAmount { get; set; }
        public DateTime EntryDateRegistration { get; set; }
        public int GroupId { get; set; }
        public int UserId { get; set; }
        
    }
}

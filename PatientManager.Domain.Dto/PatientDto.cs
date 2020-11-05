namespace PatientManager.Domain.Dto
{
    public class PatientDto
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public bool IsDeleted { get; set; }
    }
}

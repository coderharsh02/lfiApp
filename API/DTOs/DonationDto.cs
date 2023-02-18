namespace API.DTOs
{
    public class DonationDto
    {
        public int DonationId { get; set; }
        public int NoOfMeals { get; set; }
        public string Status { get; set; }
        public UserDetailDto DonatedBy { get; set; }
        public UserDetailDto CollectedBy { get; set; }
    }
}
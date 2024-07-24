namespace LicenseServer.Models.Hospital
{
    public class HospitalListResponse
    {
        public string Id { get; set; }
        public string ContactName { get; set; }
        public string HospitalName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
    }
}

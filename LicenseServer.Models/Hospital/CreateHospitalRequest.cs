namespace LicenseServer.Models.Hospital
{
    public class CreateHospitalRequest
    {
        public string ContactName { get; set; }
        public string HospitalName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
    }
}

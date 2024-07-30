﻿using System.ComponentModel.DataAnnotations;

namespace LicenseServer.Models.Hospital
{
    public class CreateHospitalRequest
    {
        [Required(ErrorMessage ="Please ")]
        public string ContactName { get; set; }
        public string HospitalName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string LicenseNumber { get; set; }
    }
}

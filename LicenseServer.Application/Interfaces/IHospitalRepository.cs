using LicenseServer.Models.Hospital;

namespace LicenseServer.Application.Interfaces
{
    public interface IHospitalRepository
    {
        Task<int> CreateHospital(CreateHospitalRequest request);
        Task DeleteHospital(string id);
        Task<HospitalListResponse?> GetHospitalById(string id);
        Task<List<HospitalListResponse>> GetHospitals();
        Task UpdateHospital(string id, CreateHospitalRequest request);
        Task UpdateHospitalName(string id, string name);
    }
}

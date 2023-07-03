using RoleBasedAuthorization.Models;

namespace RoleBasedAuthorization.Repository.Interfaces
{
    public interface IStaffService
    {
        public Task<Staff> PostStaff(Staff staff);
        public Task<List<Staff>> GetStaff();
        public Task<List<Staff>> DeleteStaff(string id);
    }
}

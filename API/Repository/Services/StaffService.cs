using JWTAuthenticationApp.Interfaces;
using JWTAuthenticationApp.Models.DTO;
using JWTAuthenticationApp.Services;
using Microsoft.EntityFrameworkCore;
using RoleBasedAuthorization.Data;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorization.Repository.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace RoleBasedAuthorization.Repository.Services
{
    public class StaffService : IStaffService
    {

        public RoleBasedAuthorizationDbContext _context;
        public StaffService(RoleBasedAuthorizationDbContext context)
        {
            _context = context;
        }


        public async Task<Staff> PostStaff(Staff staff)
        {

            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<List<Staff>> GetStaff()
        {
            var staff = await _context.Staff.ToListAsync();
            return staff;
        }

        public async Task<List<Staff>> DeleteStaff(string id)
        {
            var staff =await _context.Staff.FirstOrDefaultAsync(s=>s.Id== id);
            if (staff == null)
            {
                return null;
            }
             _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();
            return await _context.Staff.ToListAsync();
        }
    }
}

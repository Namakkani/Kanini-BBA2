using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorization.Repository.Interfaces;
using RoleBasedAuthorization.Repository.Services;

namespace RoleBasedAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpPost]
        public async Task<Staff> PostStaff(Staff staff)
        {
            return await _staffService.PostStaff(staff);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IEnumerable<Staff>> GetStaff()
        {
            return await _staffService.GetStaff();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Staff>>> DeleteStaff(string id)
        {
            var staff = await _staffService.DeleteStaff(id);

            if (staff == null)
            {
                return NotFound("Staff id not matching");
            }
            return Ok(staff);
        }


    }
}

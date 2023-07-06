using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthorization.Models;
using RoleBasedAuthorization.Repository.Interfaces;
using RoleBasedAuthorization.Repository.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            try
            {
                return await _staffService.PostStaff(staff);
            }
            catch (Exception ex)
            { 
                Console.WriteLine($"An error occurred while creating the staff: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the staff.");
            }
        }

        [HttpGet]
         
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            try
            {
                return await _staffService.GetStaff();
            }
            catch (Exception ex)
            {
                 
                Console.WriteLine($"An error occurred while fetching the staff: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the staff.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Staff>>> DeleteStaff(string id)
        {
            try
            {
                var staff = await _staffService.DeleteStaff(id);

                if (staff == null)
                {
                    return NotFound("Staff id not matching");
                }
                return Ok(staff);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while deleting the staff: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while deleting the staff.");
            }
        }
    }
}

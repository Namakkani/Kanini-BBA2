using JWTAuthenticationApp.Models.DTO;
using JWTAuthenticationApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoleBasedAuthorization.Models;
using System;
using System.Data;

namespace RoleBasedAuthorization.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AngularCORS")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        [HttpPost("Register")]
        public ActionResult<UserDTO> Register([FromBody] UserRegisterDTO userDTO)
        {
            try
            {
                var user = _service.Register(userDTO);
                if (user == null)
                {
                    return BadRequest("Unable to register");
                }
                return Created("Home", user);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while registering the user: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while registering the user.");
            }
        }

        [HttpPost("Login")]
        public ActionResult<UserDTO> Login([FromBody] UserDTO userDTO)
        {
            try
            {
                var user = _service.Login(userDTO);
                if (user == null)
                {
                    return BadRequest("Invalid username or password");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                 
                Console.WriteLine($"An error occurred while logging in: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while logging in.");
            }
        }

        [HttpGet]
         
        public async Task<ActionResult<List<User>>> GettDoctor()
        {
            try
            {
                return await _service.GettDoctor();
            }
            catch (Exception ex)
            {
                 
                Console.WriteLine($"An error occurred while fetching the doctors: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while fetching the doctors.");
            }
        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult<List<User>>> DeleteStaff(string id)
        {
            try
            {
                var staff = await _service.DeleteStaff(id);

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

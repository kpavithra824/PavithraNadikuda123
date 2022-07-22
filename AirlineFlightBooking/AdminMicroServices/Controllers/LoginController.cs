using AdminMicroServices.Services;
using AdminMicroServices.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminMicroServices.Controllers
{
    [Route("api/1.0/flight/admin")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        IJwtManagerRepository ijwtManagerRepository;

        public LoginController(IJwtManagerRepository _ijwtManagerRepository)
        {

            ijwtManagerRepository = _ijwtManagerRepository;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(AdminLoginViewModel adminloginViewModel)
        {
            var token = ijwtManagerRepository.Anthenticate(adminloginViewModel, false);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }
        [HttpPost]
        public IActionResult Register(AdminLoginViewModel loginViewModel)
        {
            var token = ijwtManagerRepository.Anthenticate(loginViewModel, true);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpGet("findall")]
        
        public IActionResult FindAll()
        {
            try
            {
                return Ok(ijwtManagerRepository.FindAll());
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}

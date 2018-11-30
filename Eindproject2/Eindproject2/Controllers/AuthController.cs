using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Eindproject2.Models;
using Eindproject2.Models.Data;
using Eindproject2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Logging;

namespace Eindproject2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AuthController : ControllerBase
    {
        private SignInManager<Users> signInMgr;
        private ILogger<AuthController> logger;
        private Eindproject2APIContext context;
        private readonly IConfiguration configuration;
        private readonly UserManager<Users> userManager;
        private readonly IPasswordHasher<Users> hasher;

        public AuthController(Eindproject2APIContext context, SignInManager<Users> signInMgr, ILogger<AuthController> logger, IPasswordHasher<Users> hasher, UserManager<Users> userManager, IConfiguration configuration)
        {
            this.context = context;
            this.logger = logger;
            this.signInMgr = signInMgr;
            this.configuration = configuration;
            this.userManager = userManager;
            this.hasher = hasher;
        }

        [HttpPost("api/auth/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] IdentityModel identityModel)
        {
            //LoginViewModel met (Required) UserName en Password aanbrengen.
            if (!ModelState.IsValid)
                return BadRequest("Unvalid data");
            try
            {
                //geen persistence, geen lockout -> via false, false
                var result = await signInMgr.PasswordSignInAsync(identityModel.UserName, identityModel.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok("Welcome " + identityModel.UserName);
                }
                ModelState.AddModelError("", "Username or password not found");
                return BadRequest("Failed to login");
                //zo algemeen mogelijke reactive. Vertelt niet dat het pwd niet juist is.
            }
            catch (Exception exc)
            {
                logger.LogError($"Exception thrown when logging in: {exc}");
            }
            return BadRequest("Failed to login"); //zo weinig mogelijk (hacker) info
        }

        /*[HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> GenerateJwtToken([FromBody]IdentityModel identityModel)
        {
            try
            {
                var jwtsvc = new JWTServices<Users>(configuration, logger, userManager, hasher);
                var token = await jwtsvc.GenerateJwtToken(identityModel);
                return Ok(token);
            }
            catch (Exception exc)
            {
                logger.LogError($"Exception thrown when creating JWT: {exc}");
            }
            //Bij niet succesvolle authenticatie wordt een Badrequest (=zo weinig mogelijke info) teruggeven.
            return BadRequest("Failed to generate JWT token");
        }*/
    }
}
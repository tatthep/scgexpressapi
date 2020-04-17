using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VK1.SCGExpress.Models;
using VK1.SCGExpress.Services;

namespace VK1.SCGExpress.Api.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AlphasController : ControllerBase {
        private readonly IConfiguration config;
        private readonly AppQuery appQuery;

        public AlphasController(IConfiguration config, AppQuery appQuery) {
            this.config = config;
            this.appQuery = appQuery;
        }


        [HttpPost("AlphaDeliveryStatus")]
        public async Task<IActionResult> AlphaDeliveryStatus(DeliveryStatusRequest item) {
            var now = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}";
            var receive = $"{item.ReceiveDate:yyyy-MM-dd HH:mm:ss}";

            //insert 1of2
            var strSql = $"insert tbl_scg_3rd_parcel_status (3rd_party_id,3rd_parcel_status_code,c2_tracking_number,3rd_party_tracking_1,datetime_input,datetime_created) values  ('4','{item.Status}','{item.QRCode}','{item.QRCode}','{receive}','{now}')";

            //insert 2of2
            //todo waiting from joe

            await appQuery.ExecuteToSqlAsync(strSql);

            var serealize = System.Text.Json.JsonSerializer.Serialize<OkObjectResult>(new OkObjectResult(StatusCodes.Status200OK));

            return StatusCode(StatusCodes.Status201Created, serealize);
        }


        [HttpPost("SignIn")]
        public ActionResult<SignInResponse> SignIn(SignInRequest item) {
            try {
                if (IsValidUser(item)) {
                    //
                    var claims = new[]
                    {
                    new Claim(ClaimTypes.Name, item.Username),
                    new Claim("luckeyNumber","3214"),
                    new Claim("lat","92.111")
                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:SecurityKey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: config["JWT:Issuer"],
                        audience: config["JWT:Audience"],
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds);

                    return Ok(new SignInResponse {
                        Token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }

                return Unauthorized();
            } catch (Exception ex) {
                string messages = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(StatusCodes.Status500InternalServerError,messages);
               
            }
        }

        private bool IsValidUser(SignInRequest item) => true;
    }
}
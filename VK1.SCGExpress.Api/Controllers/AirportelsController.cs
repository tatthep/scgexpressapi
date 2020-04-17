using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VK1.SCGExpress.Api.Controllers {
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AirportelsController : ControllerBase {
        [HttpGet("CreateTimeSignature")]
        public IActionResult CreateTimeSignature() {
            var timeStamp = $"{DateTime.Now:yyyyMMddHHmmss}";
            var secret = "953225403197";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(timeStamp);
            using (var hmacsha256 = new HMACSHA256(keyByte)) {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Content(Convert.ToBase64String(hashmessage));
            }
        }
    }
}
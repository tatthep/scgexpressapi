using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VK1.SCGExpress.Models {
   public class SignInRequest {
        [Required]
        [StringLength(30)]
        public  string Username { get; set; }

        [StringLength(99)]
        public string Password { get; set; }

    }
}

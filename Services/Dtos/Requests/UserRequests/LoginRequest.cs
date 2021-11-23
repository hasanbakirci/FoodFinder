using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Dtos.Requests.UserRequests
{
    public class LoginRequest
    {
        public string EmailAdress { get; set; }
        public string Password { get; set; }
    }
}
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IAuthService
    {
        Task<string> Register(UserDTO userDto);
        Task<string> Login(LoginRequest request);
    }
}

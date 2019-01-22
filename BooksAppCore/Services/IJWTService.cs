using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BooksAppCore.Services
{
    public interface IJWTService
    {
        string GetJwt(ClaimsIdentity identity);
    }
}
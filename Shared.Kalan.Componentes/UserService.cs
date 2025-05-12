using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks; 
namespace Shared.Kalan.Componentes
{
    public class UserService : IDisposable
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        private bool disposedValue;

        public string connectionString => UserInfo().Result.connectionString;

        public string Email => UserInfo().Result.Email;

        public string Login => UserInfo().Result.Login;

        public string Nombre => UserInfo().Result.Nombre;
         

        public UserService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }
        public async Task SetClaimAsync(string claimType, string claimValue)
        {
            ClaimsPrincipal user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            if (user.Identity.IsAuthenticated)
            {
                var identity = user.Identity as ClaimsIdentity;
                identity.RemoveClaim(identity.FindFirst(claimType));
                identity.AddClaim(new Claim(claimType, claimValue));
            }
        }
        public async Task<string> GetClaimAsync(string claimType)
        {
            string claimType2 = claimType;
            ClaimsPrincipal user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault((Claim c) => c.Type == claimType2)?.Value;
            }

            return null;
        }

        public async Task<UserInfo> UserInfo()
        {
            ClaimsPrincipal user = (await _authenticationStateProvider.GetAuthenticationStateAsync()).User;
            if (user.Identity.IsAuthenticated)
            {
                return new UserInfo
                {
                    connectionString = user.Claims.FirstOrDefault((Claim c) => c.Type == "connectionString")?.Value,
                    Email = user.Claims.FirstOrDefault((Claim c) => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value,
                    Login = user.Claims.FirstOrDefault((Claim c) => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value,
                    Nombre = user.Claims.FirstOrDefault((Claim c) => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value,
                };
            }

            return null;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace UGIM.WebUI
{
    public class LocalAuthenticationStateProvider:AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;

        public LocalAuthenticationStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _localStorage.ContainKeyAsync("User"))
            {
                var userInfo = await _localStorage.GetItemAsync<string>("User");
                var claim = new[]
                {
                    new Claim("accessToken",userInfo)
                };
                var identity = new ClaimsIdentity(claim, "BearerToken");
                var user =new ClaimsPrincipal(identity);
                var state =  new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("User");
            NotifyAuthenticationStateChanged(Task.FromResult(
                new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}

﻿using LbcAuthentication;
using XGaleryPhotos.Interfaces;
using XGaleryPhotos.Models;

namespace XGaleryPhotos.Services
{
    public class AuthenticateService : IAuthenticateService
    {
        AuthenticationResponse AuthenticationResponse { get; set; }

        public AuthenticateService()
        {
            AuthenticationResponse = new AuthenticationResponse();
        }

        public AuthenticationResponse Authenticate(string userName, string password)
        {
            WbsAuthentication authentication = new WbsAuthentication();
            authentication.InvokeService(userName, "EXT101", password);

            AuthenticationResponse.User = App.RepositoryService.GetUser(userName, password);
            AuthenticationResponse.IsAuthenticated = AuthenticationResponse.User != null;
            return AuthenticationResponse;
        }

        public bool IsUserAuthenticated()
        {
            return AuthenticationResponse.IsAuthenticated;
        }
    }
}

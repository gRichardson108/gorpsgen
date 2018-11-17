using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;

[ApiController]
public class AuthenticationController : ControllerBase
{
    private const string _clientId = "5l2r1rgsko79llfovjbiongc0p";
    private readonly RegionEndpoint _region = RegionEndpoint.USWest2;

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    [HttpPost]
    [Route("api/register")]
    public async Task<ActionResult<string>> Register(User user)
    {
        var cognito = new AmazonCognitoIdentityProviderClient(_region);

        var request = new SignUpRequest
        {
            ClientId = _clientId,
            Password = user.Password,
            Username = user.Username
        };

        var emailAttribute = new AttributeType
        {
            Name = "email",
            Value = user.Email
        };
        request.UserAttributes.Add(emailAttribute);

        var response = await cognito.SignUpAsync(request);

        return Ok();
    }
    [HttpPost]
    [Route("api/signin")]
    public async Task<ActionResult<string>> SignIn(User user)
    {
        var cognito = new AmazonCognitoIdentityProviderClient(_region);

        var request = new AdminInitiateAuthRequest
        {
            UserPoolId = "us-west-2_p6lgdDlXc",
            ClientId = _clientId,
            AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH
        };

        request.AuthParameters.Add("USERNAME", user.Username);
        request.AuthParameters.Add("PASSWORD", user.Password);

        var response = await cognito.AdminInitiateAuthAsync(request);

        return Ok(response.AuthenticationResult.IdToken);
    }
}

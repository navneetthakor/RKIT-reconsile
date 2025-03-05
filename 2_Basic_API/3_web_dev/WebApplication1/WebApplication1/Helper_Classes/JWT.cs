using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Diagnostics;
using System.Configuration;

namespace WebApplication1.Helper_Classes
{
    public class JWT
    {
        /// <summary>
        /// JWT structure: 
        /// <Header>.<Payload>.<Signature>
        /// 
        /// - header and payload (calims) just encoded in Base64URI
        /// - signature : created by singing header and payload with secret key. 
        /// Signature = HMACSHA256(EncodedHeader + "." + EncodedPayload, SecretKey)
        /// </summary>
        private static string mySecret { get; set; } = ConfigurationManager.AppSettings["JwtSecretKey"];
        public static string GenerateJwtToken(string email)
        {
            // Create a security key and signing credentials
            byte[] key = Encoding.UTF8.GetBytes(JWT.mySecret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Define the claims
            Dictionary<string,Object> claims = new Dictionary<string, object>
        {
            { "email", email },
            { "iat", DateTimeOffset.UtcNow.ToUnixTimeSeconds() }, // Issued At
            { "exp", DateTimeOffset.UtcNow.AddMonths(3).ToUnixTimeSeconds() } // Expiration
        };

            // Create a token handler
            JsonWebTokenHandler handler = new JsonWebTokenHandler();

            // Create the token
            string token = handler.CreateToken(new SecurityTokenDescriptor
            {
                Claims = claims,
                Expires = DateTime.UtcNow.AddMonths(3),
                SigningCredentials = credentials,
                Issuer = "my_notes",
                Audience = "my_notes"
            });
            Debug.WriteLine("Email1 : " +  email);
            Debug.WriteLine("token : " + token);
            return token;
        }

        public static bool ValidateJwtToken(string token, out string email)
        {
            email = null;

            //we requires only mySecret as informaion about hashing algorithm is already,
            //present inside the header of the token
            byte[] key = Encoding.UTF8.GetBytes(JWT.mySecret);
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "my_notes",
                ValidAudience = "my_notes",
                IssuerSigningKey = securityKey
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                SecurityToken validatedToken;
                ClaimsPrincipal result = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                email = Convert.ToString(result.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                Debug.WriteLine("hello : " + result.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Token validation failed: {ex.Message}");
            }

            return false;
        }
    }
}
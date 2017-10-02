using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;

namespace HMACAuthExemple.Areas.BearerAuth.Authorization
{
    public static class JwtManager
    {
        /// <summary>
        /// Use the below code to generate symmetric Secret Key
        ///     var hmac = new HMACSHA256();
        ///     var key = Convert.ToBase64String(hmac.Key);
        /// </summary>
        private const string Secret = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateToken(string username, int expireMinutes = 20)
        {
            var userData = LoadUserData(username);
            var symmetricKey = Convert.FromBase64String(userData["Secret"]);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.Name, userData["Username"]),
                            new Claim(ClaimTypes.GroupSid, userData["PermissionGroup"])
                        }),

                NotBefore = now,

                Audience = userData["Username"],

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature),

                Issuer = "Splice Mobilidade Urbana",

                IssuedAt = now
            };

            if (Convert.ToInt32(userData["ExpiresTime"]) > 0)
            {
                tokenDescriptor.Expires = now.AddMinutes(Convert.ToInt32(userData["ExpiresTime"]));
            }

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                var symmetricKey = Convert.FromBase64String(ReturnUserSecret(jwtToken.Audiences.First()));

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = "Splice Mobilidade Urbana",
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey),
                    ValidateLifetime = true
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken securityToken);

                return principal;
            }

            catch (Exception)
            {
                return null;
            }
        }

        private static Dictionary<string,string> LoadUserData(string username)
        {
            return new Dictionary<string, string>()
            {
                { "Username", username },
                { "Secret",  "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw=="},
                { "ExpiresTime", "60" },
                { "PermissionGroup", "1" }
            };
        }

        private static string ReturnUserSecret(string audience)
        {
            var dic =  new Dictionary<string, string>()
            {
                { "renan.renger", "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==" },
                { "user2", Convert.ToBase64String(new HMACSHA256().Key) },
                { "user3", Convert.ToBase64String(new HMACSHA256().Key) },
                { "user4", Convert.ToBase64String(new HMACSHA256().Key) }
            };

            return dic[audience];
        }
    }
}
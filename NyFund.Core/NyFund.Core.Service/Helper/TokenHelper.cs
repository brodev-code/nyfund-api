using NyFund.Common.Dto.Base;
using NyFund.Core.Framework.Settings;
using NyFund.Data.Entity.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace NyFund.Core.Service.Helper
{
    public static class TokenHelper
    {
        /*public static AccessToken CreateEmployeeToken(Employee employee)
        {
            var tokenSettings = AppSettingsHelper.TokenSettings;
            var accessTokenExpiration = DateTime.Now.AddMinutes(tokenSettings.AccessTokenExpiration);

            var securityKey = GetSecurityKey(tokenSettings.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetEmployeeClaim(employee),
                signingCredentials: signingCredentials
            );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accessTokenExpiration;

            return accessToken;
        }
        */

        public static AccessToken CreateCustomerToken(Customer customer)
        {
            var tokenSettings = AppSettingsHelper.TokenSettings;
            var accessTokenExpiration = DateTime.Now.AddMinutes(tokenSettings.AccessTokenExpiration);

            var securityKey = GetSecurityKey(tokenSettings.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: tokenSettings.Issuer,
                audience: tokenSettings.Audience,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: GetCustomerClaim(customer),
                signingCredentials: signingCredentials
            );

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            AccessToken accessToken = new AccessToken();
            accessToken.Token = token;
            accessToken.RefreshToken = CreateRefreshToken();
            accessToken.Expiration = accessTokenExpiration;

            return accessToken;
        }

        public static long GetTokenId(string token)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var tokenS = handler.ReadToken(token) as JwtSecurityToken;
                var nameIdentifier = tokenS.Claims.First(claim => claim.Type == ClaimTypes.NameIdentifier).Value;
                var id = !string.IsNullOrEmpty(nameIdentifier) ? Convert.ToInt64(nameIdentifier) : 0;
                return id;
            }
            catch (Exception ex)
            {
                return -1;
            }            
        }

        private static SecurityKey GetSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }

        /*private static IEnumerable<Claim> GetEmployeeClaim(Employee employee)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, employee.Id.ToString()),
                new Claim(ClaimTypes.Email, employee.Email),
                new Claim(ClaimTypes.Name, employee.Name),
                new Claim(ClaimTypes.Surname, employee.Surname),
                new Claim(ClaimTypes.SerialNumber, Guid.NewGuid().ToString())
            };

            return claims;
        }*/

        private static IEnumerable<Claim> GetCustomerClaim(Customer customer)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                new Claim(ClaimTypes.Email, string.IsNullOrEmpty(customer.Email) ? "empty" : customer.Email),
                new Claim(ClaimTypes.Name, string.IsNullOrEmpty(customer.Name) ? "empty" : customer.Name),
                new Claim(ClaimTypes.Surname, string.IsNullOrEmpty(customer.Surname) ? "empty" : customer.Surname),
                new Claim(ClaimTypes.SerialNumber, Guid.NewGuid().ToString())
            };

            return claims;
        }

        private static string CreateRefreshToken()
        {
            var numberByte = new Byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(numberByte);
                return Convert.ToBase64String(numberByte);
            }
        }

        public static IEnumerable<Claim> ValidateToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

                //var claimValue = securityToken.Claims.FirstOrDefault(c => c.Type == claimName)?.Value;
                var claimValue = securityToken.Claims;
                
                return claimValue;
            }
            catch (Exception)
            {
                //TODO: Logger.Error
                return null;
            }
        }
    }
}

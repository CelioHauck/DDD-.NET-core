using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjetoDDDCore.Application.jwt;
using ProjetoDDDCore.Application.jwt.factory;

namespace ProjetoDDDCore.Application.Helper
{
    public class Tokens
    {
        public static async Task<object> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string userName,
            JwtIssuerOptions jwtOptions)
        {
            var response = new
            {
                auth_token = await jwtFactory.GenerateEncodedToken(userName, identity)
            };


            return response;
        }
    }
}

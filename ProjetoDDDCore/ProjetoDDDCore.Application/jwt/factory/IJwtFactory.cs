using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjetoDDDCore.Application.jwt.factory
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(string userName, ClaimsIdentity identity);
        ClaimsIdentity GenerateClaimsIdentity(string userName, long id);
    }
}

using System.Threading.Tasks;

namespace TokenManager.Interfaces.Services
{
    public interface ITokenService
    {
        Task<bool> IsActiveAsync(string token);
        Task<bool> IsCurrentTokenActiveAsync();
        Task DeactivateAsync(string token);
        Task DeactivateCurrentAsync();
    }
}

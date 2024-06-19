using SWD.BBMS.Repositories.Entities;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken (User user);

        Task<string> GetUserId ();
    }
}

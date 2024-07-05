using SWD.BBMS.Repositories.Entities;
using SWD.BBMS.Services.BusinessModels;

namespace SWD.BBMS.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken (UserModel user);

        Task<string> GetUserId ();
    }
}

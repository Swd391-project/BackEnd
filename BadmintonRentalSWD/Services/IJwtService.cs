using BadmintonRentalSWD.Entities;

namespace BadmintonRentalSWD.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken (User user);
    }
}

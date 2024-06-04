using BadmintonRentalSWD.Data;
using BadmintonRentalSWD.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Win32;

namespace BadmintonRentalSWD
{
    public class Seed
    {
        private readonly BBMSDbContext dbContext;

        private readonly UserManager<User> userManager;

        public Seed(BBMSDbContext dbContext, UserManager<User> userManager)
        {
            this.dbContext = dbContext;
            this.userManager = userManager;
        }

        public void SeedDataContext()
        {
            
            if (!dbContext.PaymentMethods.Any())
            {
                var paymentMethod = new PaymentMethod
                {
                    //Id = 1,
                    MethodName = "Banking",
                    Description = "ashfksajhfskf",
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = 1,
                    ModifiedDate = DateTime.UtcNow,
                };
                dbContext.PaymentMethods.AddRange(paymentMethod);
                dbContext.SaveChanges();
            }
        }
    }
}

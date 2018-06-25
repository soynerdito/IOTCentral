using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IOTCentral.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace IOTCentral
{
    public class AppClaimFactory : UserClaimsPrincipalFactory<User>
    {
        private readonly ApplicationDbContext _context;

        public AppClaimFactory(ApplicationDbContext context, UserManager<User> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
            this._context = context;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(User user)
        {
            var claims = await base.GenerateClaimsAsync(user);
            var userOrganization = _context.Organization.Where(x => x.Users.Contains(user))?.FirstOrDefault();
            if(userOrganization!= null)
            {
                //Add organization claim
                claims.AddClaim(new Claim("Organization", userOrganization.Id.ToString() ));
            }          
            return claims;
        }
    }
}
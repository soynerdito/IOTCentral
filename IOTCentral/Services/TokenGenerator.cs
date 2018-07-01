using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IotCentral.Data;

namespace IotCentral.Services
{
    public class TokenGenerator : DataAccessService
    {
        // CLaims in al tokens
        public const string CLAIM_ORGANIZATION = "cLaim_organization";
        public const string CLAIM_OWNER = "claim_owner";
        public const string CLAIM_EXPIRATION = "claim_expiration";
        public const string CLAIM_TARGET_DEVICE = "claim_target_device";

        protected TokenGenerator(ApplicationDbContext db) : base(db)
        {
        }

        /// <summary>
        /// Should add all claims to the token
        /// When expires
        /// User owner
        /// Organization
        /// </summary>
        /// <param name="user"></param>
        /// <param name="device"></param>
        /// <returns></returns>
        public string CreateToken(User user, IotDevice device, DateTime? expiration)
        {
            // TODO Add token creation logic
            return "";
        }
    }
}

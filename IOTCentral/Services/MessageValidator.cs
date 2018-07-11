using IotCentral.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IotCentral.Services
{
    /// <summary>
    /// Handles the apporval of messages
    /// </summary>
    public class MessageValidator : DataAccessService
    {
        public MessageValidator(ApplicationDbContext db) : base(db)
        {

        }

        /// <summary>
        /// Receives who sent the Message and to whom is intended
        /// Account sending should have permission to talk to destination
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool IsValid(MessageDto message)
        {
            return false;
        }
    }
}

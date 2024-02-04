using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Core.Entities
{
    public class Services
    {
        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string EstimatedDuration { get; set; }

        public int TeamMembersInvolved { get; set; }

        public string ServiceType { get; set; }

        public int UserID { get; set; }
    }
}

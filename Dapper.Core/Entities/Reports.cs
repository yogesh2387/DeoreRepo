using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Core.Entities
{
    public class Reports
    {
        public int ReportId { get; set; }
        public int ServiceId { get; set; }

        public int MeetingId { get; set; }
        public int UserId { get; set; }
        public DateTime reportGenerationDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Core.Entities
{
    public class Meeting
    {
        public int MeetingID { get; set; }
        public int UserID { get; set; }
        public DateTime meetingStartDate { get; set; }
        public DateTime meetingEndDate { get; set; }
        public string Status { get; set; }

    }
}

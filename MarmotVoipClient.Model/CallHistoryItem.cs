using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarmotVoipClient.Model
{
    public enum CallType
    {
        Incoming,
        Outcoming,
        Rejected
    }

    public class CallHistoryItem
    {
        public int Id { get; set; }

        public string Phone { get; set; }
        
        public int PersonId { get; set; }
        
        public DateTime CallStarted { get; set; }

        public DateTime CallEnded { get; set; }

        public CallType CallType { get; set; }
    }
}

using System;
using static MarmotVoipClient.Model.Enums;

namespace MarmotVoipClient.Model.Data
{
    public class CallHistoryItem
    {
        private Contact contact;

        public Contact Contact
        {
            get
            {
                return contact;
            }
            private set
            {
                this.contact = value ?? throw new NullReferenceException("Contact must be not null!");
            }
        }

        public CallDirection CallDirection { get; private set; }

        public int Id { get; private set; }

        public int ContactID { get; set; }

        public CallHistoryItem(int id, int ContactID, CallDirection callDirection = CallDirection.Incoming)
        {
            Id = id;
            this.Contact = contact;
            this.CallDirection = CallDirection;
        }

        public static CallHistoryItem Default()
        {
            return new CallHistoryItem(0, 0, CallDirection.Rejected);
        }
    }
}

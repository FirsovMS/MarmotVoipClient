using System.ComponentModel.DataAnnotations;

namespace MarmotVoipClient.Model
{
    public class Contact
    {
        #region Props

        public int Id { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Sip { get; set; }

        public string Email { get; set; }

        #endregion

        public Contact(int id, string firstName, string lastName, string sip, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Sip = sip;
            Email = email;
        }

        public static Contact Default()
        {
            return new Contact(0, string.Empty, string.Empty, string.Empty, string.Empty);
        }
    }
}

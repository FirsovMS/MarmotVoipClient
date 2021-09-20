using System.ComponentModel.DataAnnotations;

namespace MarmotVoipClient.Model
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}

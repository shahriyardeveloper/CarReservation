using CarReservation.Domain.Entities;

namespace CarReservation.Models
{
    public class ClaintFacingFormToUsers
    {
        public IReadOnlyList<ClientFacingForm> Client { get; set; }
        public User User { get; set; }

    }
}

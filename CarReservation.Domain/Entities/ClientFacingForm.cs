using CarReservation.Domain.Common;

namespace CarReservation.Domain.Entities;

public class ClientFacingForm : BaseEntity
{
    public string Name { get; set; }
    public DateTime BookingDate { get; set; }
    public int Flexibility { get; set; }
    public int VehicleSize { get; set; }
    public string ContactNumber { get; set; }
    public string EmailAddress { get; set; }
    public int Status { get; set; }
}


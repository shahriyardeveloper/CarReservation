namespace CarReservation.Application.DTOs;

public class ClientFacingFormDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime BookingDate { get; set; }
    public int Flexibility { get; set; }
    public int VehicleSize { get; set; }
    public string ContactNumber { get; set; }
    public string EmailAddress { get; set; }
    public int Status { get; set; }
}


namespace CarReservation.Domain.Common;

public abstract class BaseEntity
{
    public virtual int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set; }
    public bool IsDeleted { get; set; }
}


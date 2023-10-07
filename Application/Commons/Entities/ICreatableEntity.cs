namespace Application.Commons.Entities;

public interface ICreatableEntity
{
    public int CreatedBy { get; set; }
    public DateTime CreateDate { get; set; }
}
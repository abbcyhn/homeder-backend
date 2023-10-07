namespace Application.Commons.Entities;

public interface IEditableEntity
{
    public int? EditedBy { get; set; }
    public DateTime? EditDate { get; set; }
}
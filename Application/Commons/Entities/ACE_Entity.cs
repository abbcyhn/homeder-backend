namespace Application.Commons.Entities;

public abstract class ACE_Entity : IArchivableEntity, ICreatableEntity, IEditableEntity
{
    public int CreatedBy { get; set; }
    public DateTime CreateDate { get; set; }
    public int? EditedBy { get; set; }
    public DateTime? EditDate { get; set; }
    public int? ArchivedBy { get; set; }
    public DateTime? ArchivedDate { get; set; }
}
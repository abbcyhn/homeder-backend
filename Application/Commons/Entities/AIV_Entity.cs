namespace Application.Commons.Entities;

public abstract class AIV_Entity : IArchivableEntity, IEntity, IValueEntity
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int? ArchivedBy { get; set; }
    public DateTime? ArchivedDate { get; set; }    
}
namespace Domain.Abstracts;

public abstract class AIV_Entity : IArchivableEntity, IEntity, IValueEntity
{
    public int Id { get; set; }
    public string Value { get; set; } = null!;
    public int? ArchivedBy { get; set; }
    public DateTime? ArchivedDate { get; set; }    
}
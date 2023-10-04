namespace Domain.Entities;

public abstract class BaseLibEntity
{
    public int Id { get; set; }
    public string Value { get; set; }
    public int? ArchivedBy { get; set; }
    public DateTime? ArchivedDate { get; set; }
}
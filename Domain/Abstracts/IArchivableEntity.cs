namespace Domain.Abstracts;

public interface IArchivableEntity
{
    public int? ArchivedBy { get; set; }
    public DateTime? ArchivedDate { get; set; }
}
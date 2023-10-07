namespace Application.Commons.Entities;

public interface IArchivableEntity
{
    public int? ArchivedBy { get; set; }
    public DateTime? ArchivedDate { get; set; }
}
namespace Domain.Entities;

public class Citizenship : BaseLibEntity
{
    public int IdCountry { get; set; }
    public Country Country { get; set; }
}
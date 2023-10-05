using Domain.Abstracts;

namespace Domain.Regions;

public class Citizenship : AIV_Entity
{
    public int IdCountry { get; set; }
    public Country Country { get; set; }
}
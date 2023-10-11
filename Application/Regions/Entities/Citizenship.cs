
using Application.Commons.Entities;

namespace Application.Regions.Entities;

public class Citizenship : AIV_Entity
{
    public int IdCountry { get; set; }
    public Country Country { get; set; }
}
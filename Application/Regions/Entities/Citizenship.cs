
using Application.Commons.Entities;
using Application.Regions.Configs;

namespace Application.Regions.Entities;

public class Citizenship : AIV_Entity
{
    public int IdCountry { get; set; }
    public Country Country { get; set; }
}
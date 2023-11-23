using Application.Commons.Entities;

namespace Application.Regions.Entities;

public class State : IdValueEntity
{
    public int IdCountry { get; set; }

    public Country Country { get; set; }

    public ICollection<City> Cities { get; set; }
}
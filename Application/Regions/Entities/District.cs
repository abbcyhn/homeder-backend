using Application.Apartments.Entities;
using Application.Commons.Entities;

namespace Application.Regions.Entities;

public class District : IdValueEntity
{
    public int IdCity { get; set; }

    public City City { get; set; }

    public ICollection<Apartment> Apartments { get; set; }
}
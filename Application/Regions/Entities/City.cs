using Application.Apartments.Entities;
using Application.Commons.Entities;

namespace Application.Regions.Entities;

public class City : IdValueEntity
{
    public int IdState { get; set; }

    public State State { get; set; }

    public ICollection<District> Districts { get; set; }
    public ICollection<Apartment> Apartments { get; set; }
}
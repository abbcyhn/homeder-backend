using Application.Commons.Entities;

namespace Application.Apartments.Entities;

public class ApartmentGeneralDetail : BaseEntity
{
    public int IdApartment { get; set; }
    public bool? HasBuildingType { get; set; }
    public bool? HasBuildingMaterial { get; set; }
    public bool? HasHeatingType { get; set; }
    public bool? HasHotWaterType { get; set; }
    public bool? HasWindowType { get; set; }
    public bool? HasElevatorType { get; set; }
    public bool? HasConditionType { get; set; }
    public bool? HasOwnershipType { get; set; }
    public bool? HasFinishingType { get; set; }
    public bool? HasKitchenType { get; set; }
    public bool? HasBathroomType { get; set; }
    public bool? HasBalconyType { get; set; }
    public bool? HasTerraceType { get; set; }
    public bool? HasGardenType { get; set; }
    public bool? HasGarageType { get; set; }
    public bool? HasParkingType { get; set; }
    public bool? HasBasementType { get; set; }
    public bool? HasAtticType { get; set; }
    public bool? HasViewType { get; set; }
    public bool? HasNoiseLevel { get; set; }
    public bool? HasSunlight { get; set; }

    public Apartment Apartment { get; set; }
}
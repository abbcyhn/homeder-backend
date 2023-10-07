using Application.Commons.Entities;

namespace Application.Apartments.Entities;

public class ApartmentEquipmentDetail : ACE_Entity
{
    public int IdApartment { get; set; }
    public bool? HasFridge { get; set; }
    public bool? HasWashingMachine { get; set; }
    public bool? HasDishwasher { get; set; }
    public bool? HasOven { get; set; }
    public bool? HasMicrowave { get; set; }
    public bool? HasAirConditioning { get; set; }
    public bool? HasTv { get; set; }
    public bool? HasInternet { get; set; }
    public bool? HasPhone { get; set; }
    public bool? HasIntercom { get; set; }
    public bool? HasAlarm { get; set; }
    public bool? HasSafe { get; set; }
    public bool? HasGenerator { get; set; }
    public bool? HasSolarPanels { get; set; }
    public bool? HasWaterPurifier { get; set; }
    public bool? HasCentralVacuum { get; set; }
    public bool? HasSmartHome { get; set; }

    public Apartment Apartment { get; set; }
}
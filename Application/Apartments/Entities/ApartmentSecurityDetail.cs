using Application.Commons.Entities;

namespace Application.Apartments.Entities;

public class ApartmentSecurityDetail : ACE_Entity
{
    public int IdApartment { get; set; }
    public bool? HasAlarmSystem { get; set; }
    public bool? HasSecurityDoors { get; set; }
    public bool? HasCCTV { get; set; }
    public bool? HasConcierge { get; set; }
    public bool? HasSecurityShutters { get; set; }
    public bool? HasFireAlarm { get; set; }
    public bool? HasSmokeDetectors { get; set; }
    public bool? HasGasDetectors { get; set; }
    public bool? HasFloodDetectors { get; set; }
    public bool? HasSafeRoom { get; set; }

    public Apartment Apartment { get; set; }
}
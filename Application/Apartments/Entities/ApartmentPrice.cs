﻿using Application.Commons.Entities;

namespace Application.Apartments.Entities;

public class ApartmentPrice : BaseEntity
{
    public int IdApartment { get; set; }
    public decimal Price { get; set; }
    public int IdPriceCurrency { get; set; }
    public decimal? PriceExtra { get; set; }
    public int? IdPriceExtraCurrency { get; set; }
    public decimal? Deposit { get; set; }
    public int? IdDepositCurrency { get; set; }

    public Apartment Apartment { get; set; }
}
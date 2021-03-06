﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Domain.Models;

namespace PriceCalculator.Domain.Interfaces
{
    public interface ISpecialOffer
    {
        Product DetermineSpecialOffer(IDictionary<Product, int> products);
    }
}

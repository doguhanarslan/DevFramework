﻿using DevFramework.Northwind.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Business.Abstract;

namespace DevFramework.Northwind.Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p=>p.ProductName).NotEmpty();
            RuleFor(p=>p.CategoryId).NotEmpty();
            RuleFor(p=>p.UnitPrice).GreaterThan(0);
            RuleFor(p=>p.QuantityPerUnit).NotEmpty();
            RuleFor(p=>p.ProductName).Length(2,20);
            RuleFor(p=>p.UnitPrice).GreaterThan(0).When(p=>p.CategoryId == 3);
        }
    }
}

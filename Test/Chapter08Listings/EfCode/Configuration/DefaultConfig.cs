﻿// Copyright (c) 2017 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT licence. See License.txt in the project root for license information.

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Test.Chapter08Listings.EfClasses;

namespace Test.Chapter08Listings.EfCode.Configuration
{
    public static class DefaultConfig
    {
        public static void Configure
            (this EntityTypeBuilder<DefaultTest> entity, 
             ValueGenerator<string> myGenerator)
        {
            entity.Property<DateTime>("DateOfBirth")
                .HasDefaultValue(new DateTime(2000, 1, 1));

            entity.Property(x => x.CreatedOn)
                .HasDefaultValueSql("getutcdate()");

            entity.Property(p => p.OrderId)
                .HasValueGenerator((p, e) => myGenerator);
        }
    }
}
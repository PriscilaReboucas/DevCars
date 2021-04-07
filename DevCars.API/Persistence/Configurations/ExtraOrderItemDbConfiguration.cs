﻿using DevCars.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace DevCars.API.Persistence.Configurations
{
    public class ExtraOrderItemDbConfiguration : IEntityTypeConfiguration<ExtraOrderItem>
    {
        public void Configure(EntityTypeBuilder<ExtraOrderItem> builder)
        {
            builder
                .HasKey(e => e.Id);
            //builder
            //  .ToTable("ExtraOrderItem");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Orak.AdvertisementApp.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orak.AdvertisementApp.DataAccess.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasIndex(x => new
            {
                x.AppRoleId, x.AppUserId
            });
            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppRoleId);
            builder.HasOne(x => x.AppUser).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppUserId);
        }
    }
}

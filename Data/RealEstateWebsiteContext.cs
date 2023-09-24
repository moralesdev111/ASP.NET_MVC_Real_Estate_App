using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealEstateWebsite.Models;

namespace RealEstateWebsite.Data
{
    public class RealEstateWebsiteContext : DbContext
    {
        public RealEstateWebsiteContext (DbContextOptions<RealEstateWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<RealEstateWebsite.Models.Listings> Listings { get; set; } = default!;
    }
}

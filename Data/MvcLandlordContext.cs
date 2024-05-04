using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Restify.Models;

namespace MvcLandlord.Data
{
    public class MvcLandlordContext : DbContext
    {
        public MvcLandlordContext (DbContextOptions<MvcLandlordContext> options)
            : base(options)
        {
        }

        public DbSet<Restify.Models.Landlord> Landlord { get; set; } = default!;
    }
}

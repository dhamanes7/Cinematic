using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinematic.Models;

namespace Cinematic
{
    public class Data : DbContext
    {
        public Data (DbContextOptions<Data> options)
            : base(options)
        {
        }

        public DbSet<Cinematic.Models.Movie> Movie { get; set; } = default!;
    }
    }

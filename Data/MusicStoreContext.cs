using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext (DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public DbSet<MusicStore.Models.Artists> Artists { get; set; } = default!;

        public DbSet<MusicStore.Models.Genres> Genres { get; set; } = default!;

        public DbSet<MusicStore.Models.Songs> Songs { get; set; } = default!;
    }
}

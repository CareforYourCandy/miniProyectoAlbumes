using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeliApp.Models;

namespace Miniproyecto.Models
{
    public class MiniproyectoContext : DbContext
    {
        public MiniproyectoContext (DbContextOptions<MiniproyectoContext> options)
            : base(options)
        {
        }

        public DbSet<Miniproyecto.Models.Album> Album { get; set; }

        public DbSet<PeliApp.Models.Comment> Comment { get; set; }

        public DbSet<PeliApp.Models.Photo> Photo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebFotoAlbum3.Models
{
    public class AlbumContext : DbContext

    {
        public virtual  DbSet<Slika> Slike { get; set; }
        public virtual DbSet<Komentar> Komentari { get; set; }
    }
}
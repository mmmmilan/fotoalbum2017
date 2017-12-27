using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebFotoAlbum3.Models
{
    [Table ("Komentar")]
    public class Komentar
    {

        public int KomentarId { get; set; }

        [Required (ErrorMessage = "Morate odabrati sliku")]
        public int SlikaId { get; set; }

        [Required (ErrorMessage = "unesite korisnika")]
        public string Korisnik { get; set; }

        [Display (Name = "Naslov Komentara")]
        [Required (ErrorMessage = "Morate uneti naslov komentara")]
        [StringLength (50, ErrorMessage = "Sme najvise 50 karaktera da ima naslov")]
        public string Naslov { get; set; }

      
        [Display(Name = "Komentar")]
        [Required(ErrorMessage = "Morate uneti komentar")]
        [StringLength(100, ErrorMessage = "Sme komentar da ima od 10 do 100 karaktera", MinimumLength = 10)]
        public string TeloKomentara { get; set; }

        public virtual Slika Slika { get; set; }

    }
}
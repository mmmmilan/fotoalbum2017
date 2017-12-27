using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace WebFotoAlbum3.Models
{
    [Table ("Slika")]
    public class Slika
    {
        public int SlikaId { get; set; }
        public Slika()
        {
            Komentari = new HashSet<Komentar>();
        }

        [Required (ErrorMessage ="morate uneti naslov")]
        [StringLength (50, ErrorMessage = "morate uneti max 50 karaktera")]
        public string Naslov { get; set; }

        [Display (Name = " Fotografija ")]
        [MaxLength]
        public byte[]  FajlSlike { get; set; }

        [HiddenInput (DisplayValue = false)]
        public string TipFajla { get; set; }

        [DataType (DataType.MultilineText)]
        [Required (ErrorMessage = "Unesite opis slike")]
        [StringLength (100, ErrorMessage = "opis ima max 100 karaktera")]
        public string Opis { get; set; }

        [Display (Name = "DatumKreiranja")]
        [DisplayFormat (ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}") ]
        public DateTime DatumKreiranja { get; set; }

        [Required (ErrorMessage = "unesi obavezno ime korisnika")]
        public string Korisnik { get; set; }

        public virtual ICollection<Komentar> Komentari { get; set; }
    }
}
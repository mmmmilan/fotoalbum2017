using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebFotoAlbum3.Models;
using System.IO;

namespace WebFotoAlbum3.Controllers
{
    public class SlikeController : Controller
    {
        private AlbumContext db = new AlbumContext();

        // GET: Slike
        public ActionResult Index()
        {
            return View(db.Slike.ToList());
        }

        public FileContentResult CitajSliku(int? id)
        {
            Slika sl = db.Slike.Find(id);
            if (sl == null)
            {
                return null;
            }
            return File(sl.FajlSlike, sl.TipFajla);
        }

        // GET: Slike/Details/5
        public ActionResult Prikaz(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = db.Slike.Find(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // GET: Slike/Create
        public ActionResult Create()
        {
            Slika sl = new Models.Slika();
            sl.DatumKreiranja = DateTime.Now;
            return View(sl);
        }

        // POST: Slike/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SlikaId,Naslov,FajlSlike,TipFajla,Opis,DatumKreiranja,Korisnik")] Slika slika, HttpPostedFileBase poslataSlika)
        {
            if (poslataSlika != null)
            {
                slika.TipFajla = poslataSlika.ContentType;
                slika.FajlSlike = new byte[poslataSlika.ContentLength];
                Stream st = poslataSlika.InputStream;
                st.Read(slika.FajlSlike, 0, poslataSlika.ContentLength);

                db.Slike.Add(slika);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: Slike/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = db.Slike.Find(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // POST: Slike/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SlikaId,Naslov,FajlSlike,TipFajla,Opis,DatumKreiranja,Korisnik")] Slika slika)
        {
            if (ModelState.IsValid)
            {
                db.Entry(slika).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slika);
        }

        // GET: Slike/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slika slika = db.Slike.Find(id);
            if (slika == null)
            {
                return HttpNotFound();
            }
            return View(slika);
        }

        // POST: Slike/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slika slika = db.Slike.Find(id);
            db.Slike.Remove(slika);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

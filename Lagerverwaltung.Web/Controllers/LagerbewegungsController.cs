using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lagerverwaltung.Model.DatabaseModels;
using Lagerverwaltung.Web.Models;

namespace Lagerverwaltung.Web.Controllers
{
    public class LagerbewegungsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lagerbewegungs
        public async Task<ActionResult> Index()
        {
            var lagerbewegungs = db.Lagerbewegungs.Include(l => l.Geschäftsfall).Include(l => l.Lagerartikel).Include(l => l.Vorgangstyp);
            return View(await lagerbewegungs.ToListAsync());
        }

        // GET: Lagerbewegungs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lagerbewegung lagerbewegung = await db.Lagerbewegungs.FindAsync(id);
            if (lagerbewegung == null)
            {
                return HttpNotFound();
            }
            return View(lagerbewegung);
        }

        /*public async Task<ActionResult> Bewegung(int? id)
        {
            var bewegung = db.Lagerartikels.FindAsync(id);
            
        }*/

        // GET: Lagerbewegungs/Create
        public ActionResult Create()
        {
            ViewBag.GeschäftsfallId = new SelectList(db.Geschäftsfalls, "GeschäftsfallId", "GeschäftsfallId");
            ViewBag.LagerartikelId = new SelectList(db.Lagerartikels, "LagerartikelId", "L_Bezeichnung");
            ViewBag.VorgangsId = new SelectList(db.Vorgangstyps, "VorgangsId", "Vorgang");
            return View();
        }

        // POST: Lagerbewegungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LagerbewegungId,B_Menge,LagerartikelId,GeschäftsfallId,VorgangsId")] Lagerbewegung lagerbewegung)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var vorgang = await db.Lagerartikels.FindAsync(lagerbewegung.LagerartikelId);
                    if (lagerbewegung.VorgangsId == 1)
                    {
                        vorgang.Lagerstand += lagerbewegung.B_Menge;
                    }
                    else
                    {
                        vorgang.Lagerstand -= lagerbewegung.B_Menge;
                    }

                    /*var available = db.Articles.Find(rental.ArticleId);
                    available.StatusId = 2;
                    available.RentCount += 1;*/

                    db.Lagerbewegungs.Add(lagerbewegung);
                    await db.SaveChangesAsync();
                }
                catch (DbEntityValidationException ev)
                {
                    Console.WriteLine(ev);
                }
                
                return RedirectToAction("Index");
            }

            ViewBag.GeschäftsfallId = new SelectList(db.Geschäftsfalls, "GeschäftsfallId", "GeschäftsfallId", lagerbewegung.GeschäftsfallId);
            ViewBag.LagerartikelId = new SelectList(db.Lagerartikels, "LagerartikelId", "L_Bezeichnung", lagerbewegung.LagerartikelId);
            ViewBag.VorgangsId = new SelectList(db.Vorgangstyps, "VorgangsId", "Vorgang", lagerbewegung.VorgangsId);
            return View(lagerbewegung);
        }

        // GET: Lagerbewegungs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lagerbewegung lagerbewegung = await db.Lagerbewegungs.FindAsync(id);
            if (lagerbewegung == null)
            {
                return HttpNotFound();
            }
            ViewBag.GeschäftsfallId = new SelectList(db.Geschäftsfalls, "GeschäftsfallId", "GeschäftsfallId", lagerbewegung.GeschäftsfallId);
            ViewBag.LagerartikelId = new SelectList(db.Lagerartikels, "LagerartikelId", "L_Bezeichnung", lagerbewegung.LagerartikelId);
            ViewBag.VorgangsId = new SelectList(db.Vorgangstyps, "VorgangsId", "Vorgang", lagerbewegung.VorgangsId);
            return View(lagerbewegung);
        }

        // POST: Lagerbewegungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LagerbewegungId,B_Menge,LagerartikelId,GeschäftsfallId,VorgangsId")] Lagerbewegung lagerbewegung)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lagerbewegung).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.GeschäftsfallId = new SelectList(db.Geschäftsfalls, "GeschäftsfallId", "GeschäftsfallId", lagerbewegung.GeschäftsfallId);
            ViewBag.LagerartikelId = new SelectList(db.Lagerartikels, "LagerartikelId", "L_Bezeichnung", lagerbewegung.LagerartikelId);
            ViewBag.VorgangsId = new SelectList(db.Vorgangstyps, "VorgangsId", "Vorgang", lagerbewegung.VorgangsId);
            return View(lagerbewegung);
        }

        // GET: Lagerbewegungs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lagerbewegung lagerbewegung = await db.Lagerbewegungs.FindAsync(id);
            if (lagerbewegung == null)
            {
                return HttpNotFound();
            }
            return View(lagerbewegung);
        }

        // POST: Lagerbewegungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lagerbewegung lagerbewegung = await db.Lagerbewegungs.FindAsync(id);
            db.Lagerbewegungs.Remove(lagerbewegung);
            await db.SaveChangesAsync();
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

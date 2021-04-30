using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lagerverwaltung.Model.DatabaseModels;
using Lagerverwaltung.Web.Models;

namespace Lagerverwaltung.Web.Controllers
{
    public class LagerartikelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lagerartikels
        public async Task<ActionResult> Index()
        {
            return View(await db.Lagerartikels.ToListAsync());
        }

        // GET: Lagerartikels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lagerartikel lagerartikel = await db.Lagerartikels.FindAsync(id);
            if (lagerartikel == null)
            {
                return HttpNotFound();
            }
            return View(lagerartikel);
        }

        // GET: Lagerartikels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lagerartikels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LagerartikelId,L_Bezeichnung,L_Preis,Lagerstand,L_MengenEinheit")] Lagerartikel lagerartikel)
        {
            if (ModelState.IsValid)
            {
                db.Lagerartikels.Add(lagerartikel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lagerartikel);
        }

        // GET: Lagerartikels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lagerartikel lagerartikel = await db.Lagerartikels.FindAsync(id);
            if (lagerartikel == null)
            {
                return HttpNotFound();
            }
            return View(lagerartikel);
        }

        // POST: Lagerartikels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LagerartikelId,L_Bezeichnung,L_Preis,Lagerstand,L_MengenEinheit")] Lagerartikel lagerartikel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lagerartikel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lagerartikel);
        }

        // GET: Lagerartikels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lagerartikel lagerartikel = await db.Lagerartikels.FindAsync(id);
            if (lagerartikel == null)
            {
                return HttpNotFound();
            }
            return View(lagerartikel);
        }

        // POST: Lagerartikels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lagerartikel lagerartikel = await db.Lagerartikels.FindAsync(id);
            db.Lagerartikels.Remove(lagerartikel);
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

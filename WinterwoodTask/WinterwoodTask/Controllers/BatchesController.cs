using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WinterwoodTask;

namespace WinterwoodTask.Controllers
{
    public class BatchesController : Controller
    {
        private BatchModel db = new BatchModel();

        // GET: Batches
        public ActionResult Index()
        {
            return View(db.Batches.ToList());
        }

        // GET: Batches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // GET: Batches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BatchID,Fruit,Variety,Quantity")] Batch batch)
        {
            if (ModelState.IsValid)
            {

                var query = db.Batches         // source
       .Join(db.Stocks,         // target
          b => b.Fruit,          // FK
          s => s.Fruit,   // PK
          (b, s) => new { Batch = b, Stock = s }) // project result
       .Select(x => x.Batch);  // select result

                db.Batches.Add(batch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(batch);
        }

        // GET: Batches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // test by adding new code
            Batch batch = db.Batches.Find(id);

            //var found = db.Batches.Join(db.Stocks, Batch => Batch.Fruit, Stock => Stock.Fruit);
            //var found = from b in b.Batch
            //            join s in s.Stock on b.Fruit equals s.Fruit on b.Variety equals s.Variety
            //            select b;


   //         var query = db.Batches         // source
   //.Join(db.Stocks,         // target
   //   b => b.Fruit,          // FK
   //   s => s.Fruit,   // PK
   //   (b, s) => new { Batch = b, Stock = s}) // project result
   //.Select(x => x.Batch);  // select result

            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: Batches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
       public ActionResult Edit([Bind(Include = "BatchID,Fruit,Variety,Quantity")] Batch batch)
             

        {
            if (ModelState.IsValid)
            {
                db.Entry(batch).State = EntityState.Modified;

                db.SaveChanges();


                return RedirectToAction("Index");
            }
            return View(batch);
        }

        // GET: Batches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Batch batch = db.Batches.Find(id);
            if (batch == null)
            {
                return HttpNotFound();
            }
            return View(batch);
        }

        // POST: Batches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Batch batch = db.Batches.Find(id);
            db.Batches.Remove(batch);
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

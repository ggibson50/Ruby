using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Ruby.Models;
using Ruby.ViewModels;

namespace Ruby.Controllers
{
    [Authorize]
    public class ServersController : Controller
    {
        private RubyDBContext db = new RubyDBContext();

        // GET: Servers
        public ActionResult Index()
        {
            return View(db.Servers.ToList());
        }

        public bool ValidateFile(HttpPostedFileBase file)
        {
            if (file.ContentLength > Constants.MAX_FILE_SIZE)
            {
                ModelState.AddModelError("myFile", "File size too big!");
                return false;
            }
            if (file.ContentLength < 0)
            {
                ModelState.AddModelError("myFile", "File content is empty");
                return false;
            }

            string fileExtension = Path.GetExtension(file.FileName).ToLower();

            if (!ViewModels.Constants.FILE_EXTENSIONS.Contains(fileExtension))
            {
                ModelState.AddModelError(fileExtension, "File type not supported.");
                return false;
            }
            return true;
        }

        public void SaveServerImage(Server server, HttpPostedFileBase image)
        {
            try
            {
                WebImage img = new WebImage(image.InputStream);

                // Check for resize
                if (img.Width > 300 || img.Height > 450)
                {
                    img.Resize(300, 450);
                }
                img.Save(Constants.SERVER_IMAGE_PATH + image.FileName);
                
                // Thumbnail Image
                img.Resize(100, 100);
                img.Save(Constants.SERVER_IMAGE_PATH + Constants.THUMBNAILS + image.FileName);

                server.ServerImage = image.FileName;
            }
            catch (Exception)
            {

            }
        }

        // GET: Servers/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Server server = db.Servers.Find(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return View(server);
        }

        // GET: Servers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ServerId,ServerName,ServerImage")] Server server,
            HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null && ValidateFile(imageUpload))
            {
                SaveServerImage(server, imageUpload);
            }

            if (ModelState.IsValid)
            {
                server.ServerId = Guid.NewGuid();
                db.Servers.Add(server);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(server);
        }

        // GET: Servers/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Server server = db.Servers.Find(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return View(server);
        }

        // POST: Servers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ServerId,ServerName,ServerImage")] Server server,
            HttpPostedFileBase imageUpload)
        {
            if (imageUpload != null && ValidateFile(imageUpload))
            {
                SaveServerImage(server, imageUpload);
            }

            if (ModelState.IsValid)
            {
                db.Entry(server).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(server);
        }

        // GET: Servers/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Server server = db.Servers.Find(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return View(server);
        }

        // POST: Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Server server = db.Servers.Find(id);
            db.Servers.Remove(server);
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

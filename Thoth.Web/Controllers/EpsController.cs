﻿using PagedList;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Thoth.Data;
using Thoth.Service;

namespace ThothProjects.Controllers
{
    public class EpsController : Controller
    {
        private ServiceBase serviceBase = new ServiceBase();

        // GET: Eps
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            // var eps = serviceBase.EpsRepository.GetAll();
            var eps = from s in serviceBase.EpsRepository.GetAll()
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                eps = eps.Where(s => s.Nombre.ToUpper().Contains(searchString.ToUpper()));
            }

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    eps = eps.Where(s => s.Nombre.Contains(searchString));
            //}
            switch (sortOrder)
            {
                case "name_desc":
                    eps = eps.OrderByDescending(s => s.Nombre);
                    break;
                case "Codigo":
                    eps = eps.OrderBy(s => s.Codigo);
                    break;
                default:  // Name ascending 
                    eps = eps.OrderBy(s => s.Nombre);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(eps.ToPagedList(pageNumber, pageSize));
        }

        // GET: Eps/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Eps eps = serviceBase.EpsRepository.GetByID(id);

            if (eps == null)
            {
                return HttpNotFound();
            }

            return View(eps);
        }

        // GET: Eps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Eps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Codigo,Nombre,Descripcion,Activo,UsuarioRegistra,FechaRegistro,UsuarioModifica,FechaModifica")] Eps eps)
        {
            if (ModelState.IsValid)
            {
                serviceBase.EpsRepository.Insert(eps);
                serviceBase.Save();
                return RedirectToAction("Index");
            }

            return View(eps);
        }

        // GET: Eps/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Eps eps = serviceBase.EpsRepository.GetByID(id);

            if (eps == null)
            {
                return HttpNotFound();
            }

            return View(eps);
        }

        // POST: Eps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Codigo,Nombre,Descripcion,Activo,UsuarioRegistra,FechaRegistro,UsuarioModifica,FechaModifica")] Eps eps)
        {
            if (ModelState.IsValid)
            {
                serviceBase.EpsRepository.Update(eps);
                serviceBase.Save();
                return RedirectToAction("Index");
            }

            return View(eps);
        }

        // GET: Eps/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Eps eps = serviceBase.EpsRepository.GetByID(id);

            if (eps == null)
            {
                return HttpNotFound();
            }

            return View(eps);
        }

        // POST: Eps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Eps eps = serviceBase.EpsRepository.GetByID(id);
            serviceBase.EpsRepository.Delete(id);
            serviceBase.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                serviceBase.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MoviesCatalog.Data.EF;
using MoviesCatalog.Data.Models;
using System.IO;
using MoviesCatalog.Data.Infrastructure;
using MoviesCatalog.Attributes;
using MoviesCatalog.Service.Identity;

namespace MoviesCatalog.Controllers
{
    public class MoviesController : BaseController
    {
        private ApplicationUserManager _userManager;
        public  MoviesController(IUnitOfWork uow, ApplicationUserManager userManager) : base(uow) {
            _userManager = userManager;
        }
        
        // GET: Movies
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: Movies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await _uow.Movies.GetByIdAsync(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        [Authorize]
        // GET: Movies/Create
        public ActionResult Create()
        {
            //ViewBag.UserId = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create(HttpPostedFileBase Poster, [Bind(Include = "Id,Name,Description,Director,ReleaseYear")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movie.UserId= (await _userManager.FindByNameAsync(User.Identity.Name)).Id;
                if (Poster!=null)
                {
                    var posterFileName = $"{Guid.NewGuid().ToString()}.{ Poster.FileName.Split('.').Last()}";
                    var path = Path.Combine(Server.MapPath("~/Posters/"), posterFileName);
                    Poster.SaveAs(path);
                    movie.Poster = posterFileName;

                }
                _uow.Movies.Add(movie);
                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(movie);
        }


        [AuthorizedToEditAndDelete]
        // GET: Movies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Movie movie = await _uow.Movies.GetByIdAsync(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [AuthorizedToEditAndDelete]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(HttpPostedFileBase Poster, [Bind(Include = "Id,Name,Poster,Description,Director,ReleaseYear,UserId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (Poster != null)
                {
                    var posterFileName = $"{Guid.NewGuid().ToString()}.{ Poster.FileName.Split('.').Last()}";
                    var path = Path.Combine(Server.MapPath("~/Posters/"), posterFileName);
                    Poster.SaveAs(path);
                    movie.Poster = posterFileName;
                }
                Movie oldmovie = await _uow.Movies.GetByIdAsync(movie.Id);
                _uow.Movies.Detach(oldmovie);
                _uow.Movies.Update(movie);

                await _uow.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = await _uow.Movies.GetByIdAsync(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Movie movie = await _uow.Movies.GetByIdAsync(id);
            _uow.Movies.Remove(movie);
            await _uow.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
    }
}

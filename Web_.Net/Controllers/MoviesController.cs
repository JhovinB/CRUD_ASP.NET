using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_.Net.Models;


namespace Web_.Net.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

    
        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>();
            if (Session["Movies"] == null)
            {

                movies.Add(new Movie { ID = 1, Title = "ABC",ReleaseDate= new DateTime(2020, 11, 17, 10, 0, 0),Price = 10, Genre = "Comedia" });
                movies.Add(new Movie { ID = 2, Title = "Busqueda Implacable", ReleaseDate = new DateTime(2020, 11, 17, 10, 0, 0) ,Price = 20, Genre = "Acción" });
                movies.Add(new Movie { ID = 3, Title = "Caminos del Terror", ReleaseDate = new DateTime(2020, 11, 17, 10, 0, 0), Price = 30, Genre = "Terror" });
                movies.Add(new Movie { ID = 4, Title = "Cada día", ReleaseDate = new DateTime(2020, 11, 17, 10, 0, 0), Price = 40, Genre = "Dramática" });
                movies.Add(new Movie { ID = 5, Title = "13 horas", ReleaseDate = new DateTime(2020, 11, 17, 10, 0, 0),Price = 50, Genre = "Guerra" });
                Session["Movies"] = movies;
            }
            else
            {
                movies = ((List<Movie>)Session["Movies"]);
            }
            return View(movies);
        
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            Movie movie = ((List<Movie>)Session["Movies"]).
                               Where(m => m.ID == id)
                               .FirstOrDefault();
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            try
            {
               ((List<Movie>)Session["Movies"]).Add(movie);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int id)
        {

            Movie movie = ((List<Movie>)Session["Movies"]).
                               Where(m => m.ID == id)
                               .FirstOrDefault();

            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                Movie findMovie = ((List<Movie>)Session["Movies"]).
                Where(m => m.ID == id).FirstOrDefault();

                findMovie.Title = movie.Title;
                findMovie.Genre = movie.Genre;
                findMovie.ReleaseDate = movie.ReleaseDate;
                findMovie.Price = movie.Price;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movie = ((List<Movie>)Session["Movies"]).
                               Where(m => m.ID == id)
                               .FirstOrDefault();

            return View(movie);
            
        }

        // POST: Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                List<Movie> movies=((List<Movie>)Session["Movies"]);
                for (int i = 0; i < movies.Count; i++)
                {
                    if (movies[i].ID == id)
                    {
                        movies.RemoveAt(i);
                    }
                }
               
                Session["Movies"] = movies;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

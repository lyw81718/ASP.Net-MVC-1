using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // return type examples
        // GET: Movies/random    (where 'Movie' is the name of this controller, minus the 'Controller' part
        public ActionResult random()
        {
            var movies = new Movie() { name = "shrek" };

            /***examples of return types****/

            return View(movies);                     //helper method inherited from the 'Controller' class
            //return Content("hello world");         //just a simple content that display the 'hello world'
            //return HttpNotFound();                 //returns 404 error
            //return new EmptyResult();              //returns empty result; need 'new' keyword because this is not a helper method (not inherited from 'Controller' class

            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });        //redirect to 'Index' view, by 'Home' controller... 
            //...and passes 'page = 1' and 'sortBy = "name"' as parameters (optional)
        }

        //==============================================================================

        // parameter example
        // movies/edit/1
        public ActionResult Edit(int id)    //parameter 'id' must share the SAME name as the one specified in the default route of 'RouteConfig', else accessing /movies/edit/1 will result in an error...
                                            //if it's named 'movieId' then you MUST use query form /movies/edit?movieId=1 to access it
        {
            return Content("id " + id);     
        }

        //==============================================================================

        // multiple parameters example
        // movies/index?pageIndex=2&sortby=ReleaseDate
        public ActionResult Index(int? pageIndex, string sortBy)   //the '?' allows int to be nullable (when user didn't specifies it), no need to string since it's a reference type and it's nullable by default
        {
            if (!pageIndex.HasValue)    //if user passed in a value or not
                pageIndex = 1;

            if (String.IsNullOrEmpty(sortBy))
                sortBy = "Name";

            string info = "pageIndex= " + pageIndex + " sortBy= " + sortBy;

            return Content(info);
        }

        //==============================================================================
        
        // default route example
        // movies/released/2019/3
        //must enable attribute routing using 'routes.MapMvcAttributeRoutes()' in 'RouteConfig' 

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2})}")]           //year and month must be 4 and 2 digits respectively   
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/ " + month);
        }

        //==============================================================================

        // passes in a view model instead of a standalone model, a view model serves as an extension of a model, which can contain more information
        public ActionResult Random2()
        {
            var movie = new Movie() { name = "shrek!" };
            var customers = new List<Customer>
            {
                new Customer { name = "Customer 1" },
                new Customer { name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);

        }

    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.ViewModels;

namespace MVCApplication.Controllers
{

    public class HomeController : Controller
    {
        static public string TheString;
        static public string Searchstr;

        public IActionResult Index()
        {

            IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        public IActionResult Error()
        {

            return View();
        }

        [HttpGet]
        public IActionResult Result()
        {
            if (TheString.Length > 0)
            {
                ResultViewModel resultViewModel = new ResultViewModel();

                resultViewModel.TheString = TheString;

                return View(resultViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult Result(ResultViewModel resultViewModel)

        {
            if (ModelState.IsValid)
            {

                TheString += resultViewModel.NewElement.ToLower();

                resultViewModel.TheString = TheString;

                return View(resultViewModel);
            }

            return Redirect("/Home/Error");

        }



        [HttpGet]
        public IActionResult EditItem()
        {
            if (TheString.Length > 0)
            {
                ViewBag.NewElement1 = TheString;

                EditItemViewModel editItemViewModel = new EditItemViewModel();

                return View(editItemViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult EditItem(EditItemViewModel editItemViewModel)

        {
            if (ModelState.IsValid)

            {


                TheString = editItemViewModel.NewElement2;

                return Redirect("/Home/Result");
            }

            return Redirect("/Home/Error");

        }


        [HttpGet]
        public IActionResult SearchSelect()
        {
            if (TheString.Length > 0)
            {
                SearchSelectViewModel searchSelectViewModel = new SearchSelectViewModel();

                return View(searchSelectViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

        [HttpPost]
        public IActionResult SearchSelect(SearchSelectViewModel searchSelectViewModel)

        {
            if (ModelState.IsValid)

            {
                Searchstr = searchSelectViewModel.Searchstr.ToLower();
                return Redirect("/Home/SearchResult");
            }

            return Redirect("/Home/Error");

        }

        [HttpGet]
        public IActionResult SearchResult()
        {
            if (TheString.Length > 0)
            {
                SearchResultViewModel searchResultViewModel = new SearchResultViewModel();

                if (TheString.Contains(Searchstr))
                {

                    bool Anslist = true;
                    ViewBag.Anslist = Anslist;
                    ViewBag.TheString = TheString;
                    ViewBag.Searchstr = Searchstr;

                    return View(searchResultViewModel);
                }

                else
                {

                    bool Anslist = false;
                    ViewBag.Anslist = Anslist;
                    ViewBag.TheString = TheString;
                    ViewBag.Searchstr = Searchstr;

                    return View(searchResultViewModel);

                }
            }

            else
            {
                return Redirect("/");
            }
        }


        [HttpGet]
        public IActionResult Sort()
        {
            if (TheString.Length > 0)
            {
                SortViewModel sortViewModel = new SortViewModel();

                List<char> Bridgelist = new List<char>();

                foreach (char item in TheString)
                {

                    Bridgelist.Add(item);

                }

                Bridgelist.Sort();

                var builder = new StringBuilder();

                foreach (char item in Bridgelist)
                {

                  builder.Append(item);

                }

                sortViewModel.Sortstring = builder.ToString();

                return View(sortViewModel);
            }

            else
            {
                return Redirect("/");
            }
        }

    }

}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using MVCApplication.ViewModels;

namespace MVCApplication.Controllers
{
  
    public class HomeController : Controller
    {
        static public string TheString;

        public IActionResult Index()
        {
            
        IndexViewModel indexViewModel = new IndexViewModel();

            return View(indexViewModel);
        }

        [HttpGet]
        public IActionResult Result()
        {
            if(TheString.Length > 0) { 
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

                TheString += resultViewModel.NewElement;

                resultViewModel.TheString = TheString;

                return View(resultViewModel);
            }

            return Redirect("/");

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

            return Redirect("/");

        }
    }



}

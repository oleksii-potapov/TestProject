using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FolderProject.Models;

namespace FolderProject.Controllers
{
    public class HomeController : Controller
    {
        public IFolderRepository Repository { get; set; } = new EFFolderRepository();

        public ViewResult Index(string catchall)
        {
            if (catchall == null)
                return View(Repository.GetFolderByName(""));
            else
                return View(Repository.GetFolderByName(GetNameFromCatchall(catchall)));
        }

        private string GetNameFromCatchall(string catchall)
        {
            catchall = catchall.TrimEnd('/');
            IEnumerable<string> names = catchall.Split('/');
            return names.Last();
        }
    }
}
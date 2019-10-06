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
        private readonly IFolderRepository _repository;

        public HomeController(IFolderRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(string catchall)
        {
            if (catchall == null)
                return View(_repository.GetFolderByName(""));
            else
                return View(_repository.GetFolderByName(GetNameFromCatchall(catchall)));
        }

        private string GetNameFromCatchall(string catchall)
        {
            catchall = catchall.TrimEnd('/');
            IEnumerable<string> names = catchall.Split('/');
            return names.Last();
        }
    }
}
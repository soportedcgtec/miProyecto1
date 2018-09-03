using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVCApp.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductosController : Controller
    {
        // GET: Admin/Productos
        public ActionResult Index()
        {
            return View();
        }
    }
}
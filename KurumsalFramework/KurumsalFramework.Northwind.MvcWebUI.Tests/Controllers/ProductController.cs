using KurumsalFramework.Northwind.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalFramework.Northwind.MvcWebUI.Tests.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

         public ProductController(IProductService productServic)
        {
            _productService = productServic;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}
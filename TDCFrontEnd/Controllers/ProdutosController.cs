using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace TDCFrontEnd.Controllers
{
    public class ProdutosController : Controller
    {
        //
        // GET: /Produtos/
        [OutputCache]
        public ActionResult ListaEmHtml()
        {


            var produtos = new List<Produto>();

            produtos.Add(new Produto() { Id = 1, Nome = "Livro ASP.NET" });
            produtos.Add(new Produto() { Id = 2, Nome = "Livro C#" });
            produtos.Add(new Produto() { Id = 3, Nome = "Livro .NET" });
            produtos.Add(new Produto() { Id = 4, Nome = "Livro IIS 8.0" });
            produtos.Add(new Produto() { Id = 5, Nome = "Livro MVC 5" });
            produtos.Add(new Produto() { Id = 6, Nome = "Livro Visual Studio" });

            return View(produtos);
        }

        public JsonResult Lista()
        {
            var produtos = new List<Produto>();

            produtos.Add(new Produto() { Id = 1, Nome = "Livro ASP.NET" });
            produtos.Add(new Produto() { Id = 2, Nome = "Livro C#" });
            produtos.Add(new Produto() { Id = 3, Nome = "Livro .NET" });
            produtos.Add(new Produto() { Id = 4, Nome = "Livro IIS 8.0" });
            produtos.Add(new Produto() { Id = 5, Nome = "Livro MVC 5" });
            produtos.Add(new Produto() { Id = 6, Nome = "Livro Visual Studio" });

            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

    }
    public class Produto
    {
        public string Nome { get; set; }
        public int Id { get; set; }
    }
}
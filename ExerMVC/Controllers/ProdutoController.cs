using ExerMVC.Context;
using ExerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExerMVC.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ExerContext _context;

        public ProdutoController(ExerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var produto = _context.Produto.AsNoTracking().ToList();
            return View(produto);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Produto.Add(produto).State = EntityState.Added;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var produto = _context.Produto.Find(id);
            if(produto is null)
            {
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        [HttpPost]
        public IActionResult Edit(Produto produto)
        {
            var prodBanco = _context.Produto.Find(produto.Id);
            prodBanco.Nome = produto.Nome;
            prodBanco.Preco = produto.Preco;
            prodBanco.Quantidade = produto.Quantidade;

            _context.Entry(prodBanco).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var produto = _context.Produto.Find(id);
            if(produto is null)
            {
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Delete(int id)
        {
            var produto = _context.Produto.Find(id);
            if(produto is null) 
            {
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        [HttpPost]
        public ActionResult Delete(Produto produto)
        {
            var prodBanco = _context.Produto.Find(produto.Id);
            _context.Remove(prodBanco).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

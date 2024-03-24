using ExerMVC.Context;
using ExerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace ExerMVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ExerContext _context;

        public ClienteController(ExerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var clients = _context.Clientes.AsNoTracking().ToList().Take(3);
            return View(clients);
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if(cliente is null)
            {
                NotFound("Cliente não cadastrado no banco de dados");
            }
            return View(cliente);
        }
        public ActionResult Edit(int id)
        {
            var contatoBanco = _context.Clientes.Find(id);
            if(contatoBanco is null)
            {
                return RedirectToAction("Index");
            }
            return View(contatoBanco);
        }
        [HttpPost]
        public ActionResult Edit(Cliente cliente)
        {
            var clienteBanco = _context.Clientes.Find(cliente.Id);
            if(clienteBanco is null)
            {
                return NotFound("Cliente não existe");
            }
            clienteBanco.Name = cliente.Name;
            clienteBanco.LastName = cliente.LastName;
            clienteBanco.Phone = cliente.Phone;
            clienteBanco.Adress = cliente.Adress;

            _context.Entry(clienteBanco).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Cliente cliente)
        {
            var clienteBanco = _context.Clientes.Find(cliente.Id);
            _context.Clientes.Remove(clienteBanco).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

using ExerMVC.Context;
using ExerMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExerMVC.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly ExerContext _context;

        public FuncionarioController(ExerContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var funcionarios = _context.Funcionarios.ToList();
            return View(funcionarios);
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(Funcionario funcionario) 
        {
            if(ModelState.IsValid)
            {
                _context.Funcionarios.Add(funcionario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

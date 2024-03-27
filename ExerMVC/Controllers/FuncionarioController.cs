using ExerMVC.Context;
using ExerMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var funcionarios = _context.Funcionarios.AsNoTracking().ToList().Take(3);
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
        public ActionResult Edit(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if(funcionario is null)
            {
                return NotFound("Funcionario não encontrado!");
            }
            return View(funcionario);
        }
        
        [HttpPost]
        public IActionResult Edit(Funcionario funcionario)
        {
            var funcBanco = _context.Funcionarios.Find(funcionario.Id);
            funcBanco.Name = funcionario.Name;
            funcBanco.LastName = funcionario.LastName;
            funcBanco.Number = funcionario.Number;
            funcBanco.Adress = funcionario.Adress;
            _context.Entry(funcBanco).State = EntityState.Modified;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if (funcionario is null)
            {
                return NotFound("Funcionario não encontrado");
            }
            return View(funcionario);
        }

        public ActionResult Delete(int id)
        {
            var funcionario = _context.Funcionarios.Find(id);
            if( funcionario is null)
            {
                return BadRequest("Funcionario não existe!");
            }
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Delete(Funcionario funcionario)
        {
            var funcBanco = _context.Funcionarios.Find(funcionario.Id);
            _context.Remove(funcBanco).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

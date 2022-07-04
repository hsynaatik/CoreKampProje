using BlogApiDemo.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeList()
        {
            using var context = new Context();
            var values = context.Employes.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployeAdd(Employe employe)
        {
            using var context = new Context();
            context.Add(employe);
            context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult EmployeGet(int id)
        {
            using var context = new Context();
            var employe = context.Employes.Find(id);
            if (employe==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employe);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult EmployeDelete(int id)
        {
            using var context = new Context();
            var employe = context.Employes.Find(id);
            if (employe == null)
            {
                return NotFound();
            }
            else
            {
                context.Remove(employe);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult Employeupdate(Employe employe)
        {
            using var context = new Context();
            var emp = context.Find<Employe>(employe.ID);
            if (emp== null)
            {
                return NotFound();
            }
            else
            {
                emp.Name = employe.Name;
                context.Update(emp);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}

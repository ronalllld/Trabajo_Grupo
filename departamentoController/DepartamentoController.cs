using Microsoft.AspNetCore.Mvc;
using WebApplication2.context;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly ILogger<DepartamentoController> _logger;
        private readonly AplicacionContexto _aplicacionContexto;
        public DepartamentoController(
            ILogger<DepartamentoController> logger,
            AplicacionContexto aplicacionContexto)
        {
            _logger = logger;
            _aplicacionContexto = aplicacionContexto;
        }
        //Create: Crear estudiantes
        //[Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Departamento departamento)
        {
            _aplicacionContexto.Departamentos.Add(departamento);
            _aplicacionContexto.SaveChanges();
            return Ok(departamento);
        }
        //READ: Obtener lista de estudiantes
        //[Route("")]
        [HttpGet]

        public IEnumerable<Departamento> Get()
        {
            return _aplicacionContexto.Departamentos.ToList();
        }

        //Update: Modificar estudiantes
        //[Route("/id")]
        [HttpPut]
        public IActionResult Put([FromBody] Departamento departamento)
        {
            _aplicacionContexto.Departamentos.Update(departamento);
            _aplicacionContexto.SaveChanges();
            return Ok(departamento);

        }
        //Delete: Eliminar estudiantes
        //[Route("/id")]
        [HttpDelete]
        public IActionResult Delete(int departamentoID)
        {
            _aplicacionContexto.Departamentos.Remove(
                _aplicacionContexto.Departamentos.ToList()
                .Where(x => x.IdDepartamento == departamentoID)
                .FirstOrDefault());
            _aplicacionContexto.SaveChanges();
            return Ok(departamentoID);
        }
    }
}
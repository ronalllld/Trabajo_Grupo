using Microsoft.AspNetCore.Mvc;
using Empresa.Context;
using Empresa.Models;

namespace Empresa.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class Salario_Controller : ControllerBase
    {

        private readonly ILogger<Salario_Controller> _logger;
        
        private readonly Aplication_Context _aplication_context;
        public Salario_Controller(
            ILogger<Salario_Controller> logger,


            Aplication_Context aplication_context)
        {
            _logger = logger;


            _aplication_context = aplication_context;

        }
        /*Crear*/
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Salario salario)
        {
            _aplication_context.salario.Add(salario);

            _aplication_context.SaveChanges();
            return Ok(salario);

        }
        /*Obtener lista*/
        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_aplication_context.salario.ToList());

        }
        /*Modificar*/
        [Route("/id")]

        [HttpPut]
        public IActionResult Put(
            [FromBody] Salario salario)
        {
            _aplication_context.salario.Update(salario);
            _aplication_context.SaveChanges();

            return Ok(salario);
        }
        /*Eliminar*/
        [Route("/id")]
        [HttpDelete]
        public IActionResult Delete(int idSalario)
        {
            _aplication_context.salario.Remove( _aplication_context.salario.ToList().Where(x => x.idSalario == idSalario)

                .FirstOrDefault());
            _aplication_context.SaveChanges();

            return Ok(idSalario);
        }
    }
}

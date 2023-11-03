using Empresa.Context;
using Empresa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Empresa.Controllers
{
    [ApiController]

    [Route("[controller]")]
    public class Seguro_Controller : ControllerBase
    {

        private readonly ILogger<Seguro_Controller> _logger;

        private readonly Aplication_Context _aplication_context;
        public Seguro_Controller(
            ILogger<Seguro_Controller> logger,


            Aplication_Context aplication_context)
        {
            _logger = logger;


            _aplication_context = aplication_context;

        }
        /*Crear*/
        [Route("")]
        [HttpPost]
        public IActionResult Post(
            [FromBody] Sure seguro)
        {
            _aplication_context.Seguro.Add(seguro);

            _aplication_context.SaveChanges();
            return Ok(seguro);

        }
        /*Obtener lista*/
        [Route("")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_aplication_context.Seguro.ToList());

        }
        /*Modificar*/
        [Route("{id}")]

        [HttpPut]
        public IActionResult Put(
            [FromBody] Sure Seguro)
        {
            _aplication_context.Seguro.Update(Seguro);
            _aplication_context.SaveChanges();

            return Ok(Seguro);
        }
        /*Eliminar*/
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int Id_seguro)
        {
            _aplication_context.Seguro.Remove(
                _aplication_context.Seguro.ToList()
                .Where(x => x.Id_Sure == Id_seguro)

                .FirstOrDefault());
            _aplication_context.SaveChanges();

            return Ok(Id_seguro);
        }
    }
}

using empresa1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace empresa1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {
        private readonly ILogger<DepartamentoController> _logger;
        private readonly Aplication_Context _aplication_context;

        public DepartamentoController(
            ILogger<DepartamentoController> logger,
            Aplication_Context aplication_context)
        {
            _logger = logger;
            _aplication_context = aplication_context;
        }

        // Crear un nuevo departamento
        [HttpPost]
        public IActionResult Post([FromBody] Departamento departamento)
        {
            try
            {
                _aplication_context.departamento.Add(departamento);
                _aplication_context.SaveChanges();
                return Ok(departamento);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear departamento: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // Obtener lista de departamentos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var departamentos = _aplication_context.departamento.ToList();
                return Ok(departamentos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la lista de departamentos: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // Modificar un departamento por su ID
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departamento departamento)
        {
            try
            {
                var existingDepartamento = _aplication_context.departamento.Find(id);
                if (existingDepartamento == null)
                {
                    return NotFound(); // Departamento no encontrado
                }

                // Actualiza los campos del departamento existente con los valores proporcionados
                existingDepartamento.Nombre = departamento.Nombre; // Reemplaza con los nombres de tus propiedades
                existingDepartamento.Area = departamento.Area;

                _aplication_context.departamento.Update(existingDepartamento);
                _aplication_context.SaveChanges();

                return Ok(existingDepartamento);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al modificar departamento: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        // Eliminar un departamento por su ID
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var departamento = _aplication_context.departamento.Find(id);
                if (departamento == null)
                {
                    return NotFound(); // Departamento no encontrado
                }

                _aplication_context.departamento.Remove(departamento);
                _aplication_context.SaveChanges();

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar departamento: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}

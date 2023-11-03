using empresa1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace empresa1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly ILogger<EmpleadoController> _logger;
        private readonly Aplication_Context _aplication_context;

        public EmpleadoController(
            ILogger<EmpleadoController> logger,
            Aplication_Context aplication_context)
        {
            _logger = logger;
            _aplication_context = aplication_context;
        }

        /* Crear un nuevo empleado */
        [HttpPost]
        public IActionResult Post([FromBody] Empelado empleado)
        {
            try
            {
                _aplication_context.empleado.Add(empleado);
                _aplication_context.SaveChanges();
                return Ok(empleado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear empleado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /* Obtener lista de empleados */
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var empleados = _aplication_context.empleado.ToList();
                return Ok(empleados);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la lista de empleados: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /* Modificar un empleado por su ID */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Empelado empleado)
        {
            try
            {
                var existingEmpleado = _aplication_context.empleado.Find(id);
                if (existingEmpleado == null)
                {
                    return NotFound(); // Empleado no encontrado
                }

                // Actualiza los campos del empleado existente con los valores proporcionados
                existingEmpleado.Nombre = empleado.Nombre;
                existingEmpleado.Apellido = empleado.Apellido;
                existingEmpleado.Genero = empleado.Genero;
                existingEmpleado.FechaNacimiento = empleado.FechaNacimiento;

                _aplication_context.empleado.Update(existingEmpleado);
                _aplication_context.SaveChanges();

                return Ok(existingEmpleado);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al modificar empleado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /* Eliminar un empleado por su ID */
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var empleado = _aplication_context.empleado.Find(id);
                if (empleado == null)
                {
                    return NotFound(); // Empleado no encontrado
                }

                _aplication_context.empleado.Remove(empleado);
                _aplication_context.SaveChanges();

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar empleado: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}

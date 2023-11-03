using empresa1.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace empresa1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloController : ControllerBase
    {
        private readonly ILogger<TituloController> _logger;
        private readonly Aplication_Context _aplication_context;

        public TituloController(
            ILogger<TituloController> logger,
            Aplication_Context aplication_context)
        {
            _logger = logger;
            _aplication_context = aplication_context;
        }

        /* Crear un nuevo t�tulo */
        [HttpPost]
        public IActionResult Post([FromBody] Titulo titulo)
        {
            try
            {
                _aplication_context.titulos.Add(titulo);
                _aplication_context.SaveChanges();
                return Ok(titulo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear t�tulo: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /* Obtener lista de t�tulos */
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var titulos = _aplication_context.titulos.ToList();
                return Ok(titulos);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la lista de t�tulos: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /* Modificar un t�tulo por su ID */
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Titulo titulo)
        {
            try
            {
                var existingTitulo = _aplication_context.titulos.Find(id);
                if (existingTitulo == null)
                {
                    return NotFound(); // T�tulo no encontrado
                }

                // Actualiza los campos del t�tulo existente con los valores proporcionados
                existingTitulo.TITULO = titulo.TITULO;
                existingTitulo.Descripcion = titulo.Descripcion;

                _aplication_context.titulos.Update(existingTitulo);
                _aplication_context.SaveChanges();

                return Ok(existingTitulo);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al modificar t�tulo: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        /* Eliminar un t�tulo por su ID */
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var titulo = _aplication_context.titulos.Find(id);
                if (titulo == null)
                {
                    return NotFound(); // T�tulo no encontrado
                }

                _aplication_context.titulos.Remove(titulo);
                _aplication_context.SaveChanges();

                return Ok(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar t�tulo: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}

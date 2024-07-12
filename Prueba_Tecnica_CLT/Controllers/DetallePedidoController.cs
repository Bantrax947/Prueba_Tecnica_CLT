using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Data;
using PruebaTecnica.Models;

namespace Prueba_Tecnica_CLT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
//    [AllowAnonymous]
    public class DetallePedidoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetallePedidoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/DetallePedido
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallePedido>>> GetDetallesPedido()
        {
          if (_context.DetallesPedido == null)
          {
              return NotFound();
          }
            return await _context.DetallesPedido.ToListAsync();
        }

        // GET: api/DetallePedido/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallePedido>> GetDetallePedido(int id)
        {
          if (_context.DetallesPedido == null)
          {
              return NotFound();
          }
            var detallePedido = await _context.DetallesPedido.FindAsync(id);

            if (detallePedido == null)
            {
                return NotFound();
            }

            return detallePedido;
        }

        // PUT: api/DetallePedido/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallePedido(int id, DetallePedido detallePedido)
        {
            if (id != detallePedido.Id)
            {
                return BadRequest();
            }

            _context.Entry(detallePedido).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallePedidoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DetallePedido
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallePedido>> PostDetallePedido(DetallePedido detallePedido)
        {
          if (_context.DetallesPedido == null)
          {
              return Problem("Entity set 'AppDbContext.DetallesPedido'  is null.");
          }
            _context.DetallesPedido.Add(detallePedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallePedido", new { id = detallePedido.Id }, detallePedido);
        }

        // DELETE: api/DetallePedido/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallePedido(int id)
        {
            if (_context.DetallesPedido == null)
            {
                return NotFound();
            }
            var detallePedido = await _context.DetallesPedido.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            _context.DetallesPedido.Remove(detallePedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallePedidoExists(int id)
        {
            return (_context.DetallesPedido?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

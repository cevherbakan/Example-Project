using DexonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DexonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThicknessController : Controller
    {
        private readonly DatabaseContext _context;

        public ThicknessController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = _context.Thicknesses.ToList();

            return Ok(list);
        }

        [HttpGet("by-tp-id/{tpId}")]
        public async Task<IActionResult> GetByTpId(int tpId)
        {
            var thicknessListWithTp = await (from t in _context.Thicknesses
                                              where t.TpId == tpId
                                              join test in _context.TestPoints on t.TpId equals test.Id
                                              select new
                                              {
                                                  Thicknesses = t,
                                                  TestPoints = test
                                              }).ToListAsync();

            if (thicknessListWithTp.Any())
            {
                return Ok(thicknessListWithTp);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Thickness thickness = new Thickness();
            thickness = await _context.Thicknesses.FindAsync(id);
            return Ok(thickness);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Thickness thickness)
        {
            _context.Update(thickness);
            await _context.SaveChangesAsync();
            return Ok(thickness);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Thickness thickness)
        {
            _context.Update(thickness);
            await _context.SaveChangesAsync();
            return Ok(thickness);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var thickness = await _context.Thicknesses.FindAsync(id);
            _context.Thicknesses.Remove(thickness);
            return Ok(await _context.SaveChangesAsync());
        }
    }
}

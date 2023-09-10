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
    public class TestPointController : Controller
    {
        private readonly DatabaseContext _context;

        public TestPointController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = _context.TestPoints.ToList();

            return Ok(list);
        }

        [HttpGet("by-cml-id/{cmlId}")]
        public async Task<IActionResult> GetByCmlId(int cmlId)
        {
            var testPointListWithCml = await (from t in _context.TestPoints
                                         where t.CmlId == cmlId
                                         join c in _context.Cml on t.CmlId equals c.Id
                                         select new
                                         {
                                             TestPoints = t,
                                             Cml = c
                                         }).ToListAsync();

            if (testPointListWithCml.Any())
            {
                return Ok(testPointListWithCml);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            TestPoint testPoint = new TestPoint();
            testPoint = await _context.TestPoints.FindAsync(id);
            return Ok(testPoint);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TestPoint testPoint)
        {
            _context.Update(testPoint);
            await _context.SaveChangesAsync();
            return Ok(testPoint);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TestPoint testPoint)
        {
            _context.Update(testPoint);
            await _context.SaveChangesAsync();
            return Ok(testPoint);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var testPoint = await _context.TestPoints.FindAsync(id);
            _context.TestPoints.Remove(testPoint);
            return Ok(await _context.SaveChangesAsync());
        }
    }
}

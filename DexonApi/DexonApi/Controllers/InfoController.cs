using DexonApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DexonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : Controller
    {
        private readonly DatabaseContext _context;

        public InfoController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = _context.Info.ToList();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Info info = new Info();
            info = await _context.Info.FindAsync(id);
            return Ok(info);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Info info)
        {
            _context.Update(info);
            await _context.SaveChangesAsync();
            return Ok(info);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Info info)
        {
            _context.Update(info);
            await _context.SaveChangesAsync();
            return Ok(info);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var info = await _context.Info.FindAsync(id);
            _context.Info.Remove(info);
            return Ok(await _context.SaveChangesAsync());
        }
    }
}

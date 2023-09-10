using DexonApi.Models;
using DexonApi.Services;
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
    public class CmlController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly CmlService _cmlService;

        public CmlController(DatabaseContext context, CmlService cmlService)
        {
            _context = context;
            _cmlService = cmlService;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var list = _context.Cml.ToList();

            return Ok(list);
        }

        [HttpGet("by-info-id/{infoId}")]
        public async Task<IActionResult> GetByInfoId(int infoId)
        {
            var cmlListWithInfo = await (from c in _context.Cml
                                         where c.InfoId == infoId
                                         join i in _context.Info on c.InfoId equals i.Id
                                         select new
                                         {
                                             Cml = c,
                                             Info = i
                                         }).ToListAsync();

            if (cmlListWithInfo.Any())
            {
                return Ok(cmlListWithInfo);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cml cml)
        {
            var info = await _context.Info.FindAsync(cml.InfoId);

            if (info != null)
            {
                float pipeSize = info.PipeSize;

                cml.ActualOutsideDiameter = _cmlService.GetAOD(pipeSize);
                cml.StructuralThickness = _cmlService.GetStThickness(pipeSize);
                cml.DesignThickness = _cmlService.GetDesignThickness(info, cml);
                cml.RequiredThickness = Math.Max(cml.DesignThickness, cml.StructuralThickness);

                _context.Update(cml);
                await _context.SaveChangesAsync();
                return Ok(cml);
            }
            else
            {
                return NotFound("Not Found !!");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Cml cml)
        {
            _context.Update(cml);
            await _context.SaveChangesAsync();
            return Ok(cml);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cml = await _context.Cml.FindAsync(id);
            _context.Cml.Remove(cml);
            return Ok(await _context.SaveChangesAsync());
        }
    }
}

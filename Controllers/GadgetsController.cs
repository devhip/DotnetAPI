using webappmssql.Data;
using webappmssql.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace webappmssql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GadgetsController : ControllerBase
    {
        private readonly MyWordDBContext _MyWordDBContext;

        public GadgetsController(MyWordDBContext myWordDBContext)
        {
            _MyWordDBContext = myWordDBContext;
        }

        // การสร้าง Method Get All Gadgest
        // https://localhost:5001/Gadgest/all
        [HttpGet]
        [Route("all")]
        public IActionResult GetAllGadgets()
        {
            var allGadgets = _MyWordDBContext.Gadgets.ToList();
            return Ok(allGadgets);
        }

        // สร้าง Method Add Gadgest
        // https://localhost:5001/Gadgets/add
        [HttpPost]
        [Route("add")]
        public IActionResult CreateGadgets(Gadgets gadgets)
        {
            _MyWordDBContext.Gadgets.Add(gadgets);
            _MyWordDBContext.SaveChanges();
            return Ok(gadgets.Id);
        }

        // สร้าง Method Update Gadgets()
        // https://localhost:5001/Gadgets/update
        [HttpPut]
        [Route("update")]
        public IActionResult UpdateGadget(Gadgets gadgets)
        {
            _MyWordDBContext.Update(gadgets);
            _MyWordDBContext.SaveChanges();
            return NoContent();
        }
        
        // สร้าง Method Delete Gadgets()
        // https://localhost:5001/Gadgets/delete
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult DeleteGadget(int id)
        {
            var gadgetToDelete = _MyWordDBContext.Gadgets.Where(_ => _.Id == id).FirstOrDefault();
            if (gadgetToDelete == null)
            {
                return NotFound();
            }
            _MyWordDBContext.Gadgets.Remove(gadgetToDelete);
            _MyWordDBContext.SaveChanges();
            return NoContent();
        }
    }
}
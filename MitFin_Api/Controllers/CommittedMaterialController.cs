using Microsoft.AspNetCore.Mvc;
using MitFin_Api.Inventory;
using MitFin_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MitFin_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommittedMaterialsController : ControllerBase
    {
        private readonly CommittedMaterialInterface _repo;

        public CommittedMaterialsController(CommittedMaterialInterface repo)
        {
            _repo = repo;
        }
        // GET: api/CommittedMaterials
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommittedMaterial>>> GetAll()
        {
            var items = await _repo.GetAllAsync();

            if (items == null || !items.Any())
                return NotFound("No data returned for your committed‑cost query.");

            return Ok(items);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using MitFin_Api.DBAccess;
using MitFin_Api.Models;
using Oracle.ManagedDataAccess.Client;

namespace MitFin_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialsController : ControllerBase
    {
        private readonly DBConnection _db;

        public MaterialsController(DBConnection db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Material>>> GetActiveMaterials()
        {
            var materials = new List<Material>();

            //Get a  connection
            using var conn = _db.CreateConnection();
            // Define  SQL
            const string sql = @"
                SELECT mat_cd,
                       mat_nm
                  FROM inmatm
                 WHERE status = 2";

            using var cmd = new OracleCommand(sql, conn);

            //  Open and execute
            await conn.OpenAsync();
            using var reader = await cmd.ExecuteReaderAsync();

            //  Map rows to  model
            while (await reader.ReadAsync())
            {
                materials.Add(new Material
                {
                    MatCd = reader.GetString(0),
                    MatNm = reader.GetString(1)
                });
            }

            // return 404 if empty, otherwise 200 + data
            if (materials.Count == 0)
                return NotFound("No materials with status = 2");

            return Ok(materials);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PermissionTypeController : ControllerBase
    {
        private readonly models.ApplicationContext _context;
        public PermissionTypeController(models.ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var lista = await _context.PermissionTypes.ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
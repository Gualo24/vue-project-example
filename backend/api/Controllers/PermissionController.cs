using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly models.ApplicationContext _context;
        public PermissionController(models.ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{Id}")]
        [ApiVersion("1.0")]
        public async Task<IActionResult> get(int Id)
        {
            try
            {
                var lista = await _context.Permissions.Include(x => x.Type).FirstOrDefaultAsync(x => x.Id == Id);

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ApiVersion("1.0")]
        public async Task<IActionResult> getAll()
        {
            try
            {
                var lista = await _context.Permissions.Include(x => x.Type).ToListAsync();

                return Ok(lista);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ApiVersion("1.0")]
        public async Task<IActionResult> post([FromBody] models.mv.Permission.PermissionCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                models.Permission permiso = new models.Permission
                {
                    EmployeeNames = model.EmployeeNames,
                    EmployeeLastName = model.EmployeeLastName,
                    PermissionType = model.PermissionType,
                    PermissionDate = model.PermissionDate
                };

                _context.Permissions.Add(permiso);
                await _context.SaveChangesAsync();
                return Ok(permiso);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [ApiVersion("1.0")]
        public async Task<IActionResult> put([FromBody] models.mv.Permission.PermissionUpdate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(model);

            try
            {
                models.Permission permiso = await _context.Permissions.FirstOrDefaultAsync(x => x.Id == model.Id);

                permiso.EmployeeNames = model.EmployeeNames;
                permiso.EmployeeLastName = model.EmployeeLastName;
                permiso.PermissionType = model.PermissionType;
                permiso.PermissionDate = model.PermissionDate;

                await _context.SaveChangesAsync();
                return Ok(permiso);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [ApiVersion("1.0")]
        public async Task<IActionResult> delete([FromQuery] int Id)
        {
            try
            {
                models.Permission permiso = await _context.Permissions.FirstOrDefaultAsync(x => x.Id == Id);

                _context.Permissions.Remove(permiso);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
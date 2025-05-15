using Microsoft.AspNetCore.Mvc;
using ClassLibTeam03.Business.Entities;
using ClassLibTeam03.Data.Repositories;
using Newtonsoft.Json;
using System.Data;

namespace WebApiTeam03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoulderRoutesController : ControllerBase
    {
        [HttpGet("all")]
        public ActionResult<IEnumerable<BoulderRoute>> GetAllBoulderRoutes()
        {
            try
            {
                var routes = BoulderRouteRepository.GetBoulderRoutesFromDatabase();
                return Ok(routes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("addBoulderRoute")]
        public ActionResult AddUser(BoulderRoute route)
        {
            try
            {
                var result = BoulderRouteRepository.Add(route);

                if (result.Succeeded)
                {
                    return CreatedAtAction(nameof(GetAllBoulderRoutes), new { id = route.Id }, route);
                }
                else
                {
                    return BadRequest(new { errors = result.Errors });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}

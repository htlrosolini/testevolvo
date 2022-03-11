using Microsoft.AspNetCore.Mvc;
using VolvoApp.Models.DataAccess;
using VolvoApp.Models.Entities.Volvo;

namespace VolvoApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaminhaoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Caminhao>> Get()
        {
            try
            {
                if (CaminhaoAccess.Count() > 0)
                    return CaminhaoAccess.GetAll();
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Caminhao> Get(long id)
        {
            try
            {
                if (CaminhaoAccess.Count(id) > 0)
                    return CaminhaoAccess.GetById(id);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Caminhao> Post([FromBody] Caminhao value)
        {
            try
            {
                value.Id = CaminhaoAccess.Save(value);
                return Created($"api/caminhao/{value.Id}", value);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] Caminhao value)
        {
            try
            {
                CaminhaoAccess.Update(value);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                CaminhaoAccess.DeleteById(id);

                return Ok();
            }
            catch(Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

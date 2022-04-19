using Microsoft.AspNetCore.Mvc;
using AFAWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFAWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private GetLatestOcc? _occurance;

        public ValuesController()
        {
            _occurance = new GetLatestOcc();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [ActionName("GetLatestOccResp")]
        public ActionResult GetLatestOccResp()
        {
            //GetLatestOcc test = new GetLatestOcc();
            var res = _occurance?.LatestOccResponse();

            return Ok(res?.Result);

        }

        // GET api/<ValuesController>/5
        [HttpGet (Name = "GetOccCount")]
        [ActionName("GetOccCount")]
        public ActionResult GetOccCountByOrgUnitResp()
        {
            var res = _occurance?.OccCountByOrgUnitResp();

            return Ok(res?.Result);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using AFAWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AFAWebApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly GetOccurrencesAFA _occurrence;
        public ValuesController()
        {
            _occurrence = new GetOccurrencesAFA();
        }

        // GET: api/<ValuesController>/GetLatestOccResp
        [HttpGet]
        [ActionName("GetLatestOccResp")]
        public ActionResult GetLatestOccResp()
        {
            
            var res = _occurrence.LatestOccResponse();

            return Ok(res.Result);
            
        }

        // GET api/<ValuesController>/GetOccCount
        [HttpGet]
        [ActionName("GetOccCount")]
        public ActionResult GetOccCountByOrgUnitResp()
        {
            var res = _occurrence.OccCountByOrgUnitResp();

            return Ok(res?.Result);
        }


        
        /*

        // POST api/<ValuesController>
        [HttpPost]
        

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
        */

    }
}

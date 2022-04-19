using Microsoft.AspNetCore.Mvc;

namespace AFAWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        
        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult GetOccCount()
        {
            IaService.GetOccurrenceCountByOrganizationalUnitRequest reqstCount = new IaService.GetOccurrenceCountByOrganizationalUnitRequest();

            reqstCount.User = new IaService.User();
            reqstCount.User.Name = "timobr2";
            reqstCount.User.PassWord = "Julmust2019";
            
            //when unit, use organizationalunitytpe=employment instead of default occurrence
            
            //Ändra till rullande 12
            reqstCount.PeriodStart = DateTime.Now.AddYears(-1).ToShortDateString();
            reqstCount.PeriodEnd = DateTime.Now.ToShortDateString();
            reqstCount.PeriodType = IaService.DatePeriodType.Occurrence;
            //reqstCount.PeriodTypeSpecified = true;
            reqstCount.IncludeSubUnits = true;
            reqstCount.IncludeContractors = true;
            reqstCount.OrganizationalUnitName = "";


            //clientCount.Credentials = new System.Net.NetworkCredential() { UserName = GetChartAppSetting("BasicAuthenticationUser"), Password = GetChartAppSetting("BasicAuthenticationPass") };
            IaService.IaIntegrationSiClient siClient = new IaService.IaIntegrationSiClient();
            var resultCount = siClient.GetOccurrenceCountByOrganizationalUnitAsync(reqstCount);
            //var resultCount = siClient.GetOccurrenceCountByOrganizationalUnit(reqstCount);

            
            return Ok(resultCount.Result);
           
        }
        
        
        [HttpGet(Name = "GetLatestOccurrenceResp")]

        public IActionResult Get()
        {
            IaService.GetLatestOccurrenceRequest reqLatest = new IaService.GetLatestOccurrenceRequest();

           
            reqLatest.IncludeContractors = true;
            reqLatest.IncludeSubUnits = true;
            reqLatest.OccurrenceType = IaService.OccurrenceSearchType.Environment;


            reqLatest.User = new IaService.User();
            reqLatest.User.Name = "timobr2";
            reqLatest.User.PassWord = "Julmust2019";
            reqLatest.OrganizationalUnitName = "";

            IaService.IaIntegrationSiClient siClient = new IaService.IaIntegrationSiClient();
            var res = siClient.GetLatestOccurrenceAsync(reqLatest);

            return Ok(res.Result);
        }
        
    }
}
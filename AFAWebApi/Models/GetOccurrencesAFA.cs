namespace AFAWebApi.Models
{
    public class GetOccurrencesAFA
    {
        ApiUser user;
        public GetOccurrencesAFA ()
        {
            user = new ApiUser ();
        }

     

        public Task<IaService.GetOccurrenceCountByOrganizationalUnitResponse> OccCountByOrgUnitResp( string unitName ="")
        {
            IaService.GetOccurrenceCountByOrganizationalUnitRequest reqstCount = new IaService.GetOccurrenceCountByOrganizationalUnitRequest();

            reqstCount.User = new IaService.User();
            reqstCount.User.Name = user.Name;
            reqstCount.User.PassWord = user.Password;
            reqstCount.IncludeLight = true;
            if (unitName != "")
                reqstCount.OrganizationalUnitType = IaService.OrganizationalUnitType.Employment;
            reqstCount.PeriodStart = DateTime.Now.AddYears(-1).ToShortDateString();
            reqstCount.PeriodEnd = DateTime.Now.ToShortDateString();
            reqstCount.PeriodType = IaService.DatePeriodType.Occurrence;
            reqstCount.IncludeSubUnits = true;
            reqstCount.IncludeContractors = true;
            reqstCount.OrganizationalUnitName = unitName;

            IaService.IaIntegrationSiClient siClient = new IaService.IaIntegrationSiClient();
            var resultCount = siClient.GetOccurrenceCountByOrganizationalUnitAsync(reqstCount);
            return resultCount;
        }


        public Task<IaService.GetLatestOccurrenceResponse> LatestOccResponse ()
        {
            IaService.GetLatestOccurrenceRequest reqLatest = new IaService.GetLatestOccurrenceRequest();

            reqLatest.IncludeContractors = true;
            reqLatest.IncludeSubUnits = true;
            reqLatest.OccurrenceType = IaService.OccurrenceSearchType.Accident;


            reqLatest.User = new IaService.User();
            reqLatest.User.Name = user.Name;
            reqLatest.User.PassWord = user.Password;
            reqLatest.OrganizationalUnitName = "";

            IaService.IaIntegrationSiClient siClient = new IaService.IaIntegrationSiClient();
            var res = siClient.GetLatestOccurrenceAsync(reqLatest);
            //var test = res.Result;
            
            return res;
        }


    }
}

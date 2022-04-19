namespace AFAWebApi.Models
{
    public class GetLatestOcc
    {
        //public IaService.GetLatestOccurrenceRequest reqLatest;
       
        public GetLatestOcc ()
        {
            
        }

        public Task<IaService.GetOccurrenceCountByOrganizationalUnitResponse> OccCountByOrgUnitResp()
        {
            IaService.GetOccurrenceCountByOrganizationalUnitRequest reqstCount = new IaService.GetOccurrenceCountByOrganizationalUnitRequest();

            reqstCount.User = new IaService.User();
            reqstCount.User.Name = "timobr2";
            reqstCount.User.PassWord = "Julmust2019";
            reqstCount.PeriodStart = DateTime.Now.AddYears(-1).ToShortDateString();
            reqstCount.PeriodEnd = DateTime.Now.ToShortDateString();
            reqstCount.PeriodType = IaService.DatePeriodType.Occurrence;
            reqstCount.IncludeSubUnits = true;
            reqstCount.IncludeContractors = true;
            reqstCount.OrganizationalUnitName = "";

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
            reqLatest.User.Name = "timobr2";
            reqLatest.User.PassWord = "Julmust2019";
            reqLatest.OrganizationalUnitName = "";

            IaService.IaIntegrationSiClient siClient = new IaService.IaIntegrationSiClient();
            var res = siClient.GetLatestOccurrenceAsync(reqLatest);

            return res;
        }
        
        

    }
}

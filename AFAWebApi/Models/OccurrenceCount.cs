namespace AFAWebApi.Models
{
    public class OccurrenceCount
    {
        GetOccurrencesAFA latest;
        public int count { get; set; }
        
        public OccurrenceCount()
        {
            latest = new GetOccurrencesAFA();
        }

        public void Test ()
        {
            
        }

    }
}

namespace AFAWebApi.Models
{
    public class ApiUser
    {
        public string? Name { get; private set; }
        public string? Password { get; private set; }
        public ApiUser ()
        {
            Name = "timobr2";
            Password = "Julmust2019";
        }
    }
}

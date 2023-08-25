using CV.Domain.Command;


namespace CV.Domain
{
    public class Doing : BaseEntityDomein
    {
        public string Title { get; set; }
        public string? Location { get; set; }
        public string Detail { get; set; }
    }
}

namespace PersonCatalog.Domain.ResourceParameters
{
    public class PeopleResourceParameters
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PersonalNumber { get; set; }
        public int PageNumber { get; set; }
        public int ItemPerPage { get; set; }
    }
}

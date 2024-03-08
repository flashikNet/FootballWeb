namespace Api.Football.Request
{
    public class EditPlayerRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string BirthDate { get; set; }
        public string Team { get; set; }
        public string Country { get; set; }
    }
}

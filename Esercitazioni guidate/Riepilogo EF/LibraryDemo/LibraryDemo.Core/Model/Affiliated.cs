namespace LibraryDemo.Core
{
    public class Affiliated
    {
        public int AffiliatedId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + ", " + FirstName;
    }
}
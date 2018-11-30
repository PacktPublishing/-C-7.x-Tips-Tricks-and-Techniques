namespace ReturnByReference
{
    public class Engineer
    {
        public string Forename { get; set; }
        public string Surname { get; set; }

        public Engineer(string forename, string surname)
        {
            Forename = forename;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"{Forename} {Surname}";
        }
    }
}
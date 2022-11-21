namespace LinkProject
{
    internal class Meeting 
    {
        public string Title { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public int OrganizerId { get; set; }
        public TimeSpan Duration { get; set; }

        public Meeting(string title, string address, DateTime date, int organizerId, TimeSpan duration)
        {
            Title = title;
            Address = address;
            Date = date;
            OrganizerId = organizerId;
            Duration = duration;
        }

       public override bool Equals(object? other)
        {
            Meeting? m = other as Meeting;
            return m.Title.Equals(Title) && m.Date==m.Date && m.OrganizerId==OrganizerId;
        }

        public override int GetHashCode()
        {
            return new {Title,Date,OrganizerId}.GetHashCode();
        }

        public override string ToString()=> $"Title: {Title} \nAddress: {Address} \nDate: {Date} " +
                                            $"\nOragazerId:{OrganizerId} \nDuration: {Duration}";
    }
}

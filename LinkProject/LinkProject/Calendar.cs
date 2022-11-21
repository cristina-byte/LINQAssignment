using System.Data;

namespace LinkProject
{
    internal class Calendar
    {

        private IList<Meeting> _meetings;
        public IList<Meeting> Meetings 
        { 
            get { return _meetings.DefaultIfEmpty().ToList<Meeting>();} 
            set { _meetings = value; }
        }
       
        public Calendar()
        {
            _meetings = new List<Meeting>();
        }

       public void GroupMeetingsByOrganizer()
        {
            var groupedMeetings= _meetings.GroupBy(m => m.OrganizerId);

            foreach (var meeting in groupedMeetings)
            {
                Console.WriteLine($"\nMeetings organized by:{meeting.Key}");
                foreach (var m in meeting)
                {
                    Console.WriteLine($"\nTitle:{m.Title} \nAddress:{m.Address} \nDate:{m.Date}");
                }
                Console.WriteLine("-------------------------------------------------");
            }
        }

        public List<Meeting> GetMeetingsOn(DateTime date)=> _meetings.Where(m => m.Date.Year == date.Year && 
        m.Date.Month == date.Month && m.Date.Day == date.Day).OrderBy(m => m.Date).ToList<Meeting>();

        public bool AllOnline()=> _meetings.All(m => m.Address.Equals("online"));

        public bool AnyOffline()=> _meetings.Any(m => !m.Address.Equals("online"));

        public int GetMeetingsNumberOrganizedBy(int userId)=> _meetings.Count(m => m.OrganizerId == userId);

        public void Reschedule(TimeSpan interval, DateTime date)
        {
            _meetings = _meetings.Select(m =>
            {
                if (m.Date.Year == date.Year && m.Date.Month == date.Month && m.Date.Day == date.Day)
                    return new Meeting(m.Title, m.Address, m.Date.Add(interval), m.OrganizerId, m.Duration);
                else return m;
            }).ToList<Meeting>();
        }

        public Meeting GetLastMeetingOn(DateTime date)=> _meetings.Where(m => m.Date.Year == date.Year && m.Date.Month == date.Month && m.Date.Day == date.Day)
                .OrderBy(m => m.Date).Last();
    }
}

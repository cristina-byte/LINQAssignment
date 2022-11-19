

namespace LinkProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create a list of users
            IList<User> users = new List<User>
            {
                new User("Cristina Siscanu",100,"cristinasiscanu30@gmail.com","mypassword"),
                new User("Alina Dumitrascu",1,"alina@gmail.com","alina56"),
                new User("Ana Munteanu",5,"ana@gmail.com","parola"),
                new User("Ion Tutu",2,"ion@gmail.com","icon"),
                new User("Vasile Sfecla",6,"vasile@gmail.com","vasile"),
                new User("Maria Turcan",7,"maria@gmail.com","maria"),
                new User("Eugen Ceban",11,"ceban@gmail.com","mypassword"),
                new User("Oleg Fedco",67,"oleg@gmail.com","icon"),
                new User("Ion Balmus",567,"balmus@gmail.com","balmus"),
                new User("Ioana Dumitrescu",789,"sumi@gmail.com","ioana")
            };
           
           //create Calendar objects
            Calendar calendar = new Calendar();
            Calendar calendar2=new Calendar();

            //add calendar to the first user of the list
            users[0].Calendar = calendar;
            //add calendar 2 to the last user of the list
            users[9].Calendar = calendar2;

            //add Meeting objects to calendar 1
            calendar.Meetings = new List<Meeting>
            {
                new Meeting("Web site restructuring","online",new DateTime(2022,11,23,12,0,0),1,new TimeSpan(2,0,0)),
                new Meeting("Career Expo Event","online",new DateTime(2022,12,2,10,30,0),5,new TimeSpan(1,30,0)),
                new Meeting("Internship Lecture","online",new DateTime(2022,12,2,15,0,0),2,new TimeSpan(2,30,0)),
                new Meeting("Meeting with client","online",new DateTime(2022,12,2,19,45,0),6,new TimeSpan(0,30,0)),
                new Meeting("C# Training","online",new DateTime(2022,12,9,10,15,0),7,new TimeSpan(3,30,0)),
                new Meeting("Java Training","online",new DateTime(2022,12,17,10,0,0),1,new TimeSpan(1,0,0)),
                new Meeting("ASP.NET Lecture","online",new DateTime(2023,1,7,11,0,0),2,new TimeSpan(45,0,0)),
                new Meeting("Solid Principles","str. Mihai Eminescu 1",new DateTime(2023,1,10,13,0,0),11,new TimeSpan(1,0,0)),
                new Meeting("Project Presentation","str. Cluj",new DateTime(2023,1,10,15,0,0),7,new TimeSpan(0,30,0)),
                new Meeting("Agile","online",new DateTime(2022,12,20,10,0,0),67,new TimeSpan(1,30,0))
            };

            //add Meeting objects to calendar 2
            calendar2.Meetings = new List<Meeting>
            {
                new Meeting("Project Presentation","str. Cluj",new DateTime(2023,1,10,15,0,0),100,new TimeSpan(0,30,0)),
                new Meeting("Web site restructuring","online",new DateTime(2022,11,23,12,0,0),1,new TimeSpan(2,0,0)),
                new Meeting("ASP.NET Lecture Part2","online",new DateTime(2025,1,7,11,0,0),2,new TimeSpan(45,0,0)),
                new Meeting("Meeting with partners","online",new DateTime(2022,12,28,15,0,0),567,new TimeSpan(2,0,0)),
                new Meeting("Agile","online",new DateTime(2027,12,20,10,0,0),67,new TimeSpan(1,30,0))
            };

            //print meetings planned for a given date ordered by Date property
            Console.WriteLine("Meetings planned for 20/12/2022 10:00");
            var meetings = calendar.GetMeetingsOn(new DateTime(2022, 12, 2));
            foreach (Meeting meeting in meetings)
                Console.WriteLine($"\n{meeting.ToString()}");

            //group Meetings by organizer
            calendar.GroupMeetingsByOrganizer();

            //check if all meetings will be online
            Console.WriteLine($"Are all meetings online? - {calendar.AllOnline()}");

            //check if there is one meeting offline
            Console.WriteLine($"Are there offline meetings? - {calendar.AnyOffline()}");

            //get the number of meetings that are organized by one user
            Console.WriteLine($"\nNumber of meetings organized by the given user: {calendar.GetMeetingsNumberOrganizedBy(1)}");

            //reschedule the meetings with a given interval later for a given date
            calendar.Reschedule(new TimeSpan(1, 30, 0), new DateTime(2022, 12, 2));

            //print meetings after rescheduling
            Console.WriteLine($"\nMeetings after rescheduling:\n{string.Join('\n', calendar.GetMeetingsOn(new DateTime(2022, 12, 2)))}");

            //get the last meeting planned for a specific date
            Console.WriteLine($"\nThe last meeting planned on given date:\n{calendar.GetLastMeetingOn(new DateTime(2022, 12, 2))}");

            //Get common meetings for 2 calendars objects
            var commonMeetings = calendar.Meetings.Intersect(calendar2.Meetings).ToList<Meeting>();

            Console.WriteLine("\nCoomon meetings of 2 calendars");
            foreach (Meeting meeting in commonMeetings)
                Console.WriteLine('\n' + meeting.ToString());

            //Get meetings present just in the first calendar
            var meetings2 = calendar.Meetings.Except(calendar2.Meetings).ToList<Meeting>();

            Console.WriteLine("\nMeetings present just in the first calendar");
            foreach (Meeting meeting in meetings2)
                Console.WriteLine('\n' + meeting.ToString());

            //////Join operation between Meetings and Users coleections

            var innerJoin = calendar.Meetings.Join(
                users,
                meeting => meeting.OrganizerId,
                user => user.UserId,
                (meeting, user) => new
                {
                    MeetingTitle = meeting.Title,
                    OrganizerName = user.Name
                });

            Console.WriteLine("\nAfter joining\n");
            foreach (var obj in innerJoin)
            {

                Console.WriteLine("{0} - {1}", obj.MeetingTitle, obj.OrganizerName);
            }
        }
    }
}
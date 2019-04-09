using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Algorithms
{

    //A list of users and bikes. Location is known. Assign users to bike. 
    public class AssignmentOfObjects
    {
        public class Location
        {
            public int X { get; set;  }
            public int Y { get; set; }

            public Location(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Double GetDistance(Location l2)
            {
                return Math.Sqrt(Math.Pow((X - l2.X),2) + Math.Pow((Y - l2.Y), 2));
            }
        }

        public class Base
        {
            public int Id { get; set; }
            public Location Location { get; set; }

            public Base(int id, Location l)
            {
                Id = id;
                Location = l;
            }

        }

        public class User : Base
        {
            public User(int id, Location l) : base(id, l)
            {
            }
        }

        public class Bike :Base
        {
            public Bike(int id, Location l) : base(id, l)
            {
            }

        }



        public void Run()
        {
            var users = new List<User>
            {
                new User(1, new Location(0, 0)),
                new User(2, new Location(3, 3)),
                new User(3, new Location(2, 2)),
                new User(4, new Location(1, 1)),
                new User(5, new Location(1, 3)),

            };

            var bikes = new List<Bike>
            {
                new Bike(1, new Location(0, 2)),
                new Bike(2, new Location(1, 1)),
                new Bike(3, new Location(2, 0)),
        

            };

            Assign(users, bikes);
        }

        public class UserAssignment
        {
            public User User { get; set; }
            public Bike Bike { get; set; }
            public Double Distance { get; set; }

            public UserAssignment(User u, Bike b, Double d)
            {
                User = u;
                Bike = b;
                Distance = d;
            }
        }

        private void Assign(List<User> users, List<Bike> bikes)
        {

            var list = new List<UserAssignment>();
            foreach (var b in bikes)
            {
                var curDistance = Double.MaxValue;
                var curUser = users[0];
                foreach (var u in users)
                {
                    var tempD = b.Location.GetDistance(u.Location);
                    
                    if (tempD < curDistance)
                    {
                        curDistance = tempD;
                        curUser = u;
                    }
                }
                list.Add(new UserAssignment(curUser, b, curDistance));
            }

        }
    }
}

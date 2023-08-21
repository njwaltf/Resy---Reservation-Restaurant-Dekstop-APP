using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resy___Reservation_Restaurant.Model
{
    public class User
    {
        static string Username;
        static string Name;
        static int Id;
        public static string username { 
            get
            {
                return Username;
            }
            set 
            {   
                Username = value;
            } 
        }
        public static string name
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public static int id
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }
    }
}

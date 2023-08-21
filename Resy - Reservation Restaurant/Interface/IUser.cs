using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resy___Reservation_Restaurant.Interface
{
    public interface IUser
    {
        int Id { get; }
        string Name { get; }
        string Email { get; }
        string Password { get; }
        string UserName { get; }
    }
}

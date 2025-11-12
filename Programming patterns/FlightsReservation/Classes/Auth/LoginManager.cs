using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightsReservation.classes
{
    internal class LoginManager
    {
        private static LoginManager _instance;
        private LoginManager() { }

        public static LoginManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoginManager();
            }
            return _instance;
        }


    }
}

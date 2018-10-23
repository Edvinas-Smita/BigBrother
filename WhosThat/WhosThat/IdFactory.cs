using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhosThat
{
    public static class IdFactory
    {
        public static int Id
        {
            get
            {
                Id++;
                Properties.Settings.Default["lastId"] = Id;
                return Id;
            }
            private set { Id = value; }
        }

        static IdFactory()
        {
            Id = (int)Properties.Settings.Default["lastId"];
        }

    }
}

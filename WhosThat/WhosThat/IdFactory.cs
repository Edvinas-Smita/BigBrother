using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhosThat
{
    public static class IdFactory
    {
        public static int NextId
        {
            get
            {
                NextId++;
                Properties.Settings.Default["lastId"] = NextId;
                return NextId;
            }
            private set { NextId = value; }
        }

        public static void SetCurrentId(int id)
        {
            Properties.Settings.Default["lastId"] = NextId;
        }

        static IdFactory()
        {
            NextId = (int)Properties.Settings.Default["lastId"];
        }

    }
}

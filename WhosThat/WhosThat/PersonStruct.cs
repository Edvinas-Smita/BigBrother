using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhosThat.Recognition;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace WhosThat
{
    public class Person
    {

        private class TableRow
        {
            private string name, bio, likes;
            public TableRow(string n, string b, string l)
            {
                this.name = n;
                this.bio = b;
                this.likes = l;
            }
        }

        public static string dbname = "../../../../local.sdf";

        private string name;

        private string bio;

        private string likes;


        //Reikia prideti nuotrauku lista kurias vartotojas issaugoja, kad profilyje galetume atvaizduoti

        public List<Face> Photos { get; set; }

        public Person(string name, string bio, string likes)
        {
            this.name = name;
            this.bio = bio;
            this.likes = likes;
        }

        public void AddToDB()
        {
            Northwind db = new Northwind(dbname);
            db.people.InsertOnSubmit(new TableRow(name, bio, likes));
            try { db.SubmitChanges(); } catch
            {
                Console.Write("database error\n");
            }
            finally
            {
                db.Dispose();
            }

        }

        public static List<Person> UpdatePeopleList() // TODO: fix Northwind assemply reference, couldn't figure this out in 3 hours
        {
            Northwind db = new Northwind(dbname);
            var query = from p in db.People
                        select p;
            foreach(People p in query)
            {

            }
        }


        //setteriai getteriai
        public void setBio(string bio)
        {
            this.bio = bio;
        }

        public string getBio()
        {
            return bio;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getName()
        {
            return name;
        }

        public void setLikes(string likes)
        {
            this.likes = likes;
        }

        public string getLikes()
        {
            return likes;
        }

    }
}

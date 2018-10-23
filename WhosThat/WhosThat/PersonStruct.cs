using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhosThat.Recognition;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data;
using Microsoft.Data.Sqlite;

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

        public static void initDB()
        {
            using (SqliteConnection conn = new SqliteConnection("Filename=local.db"))
            {
                conn.Open();

                String tableCommand = "CREATE TABLE IF NOT " +
                    "EXISTS people (Id INTEGER PRIMARY KEY, " +
                    "name NVARCHAR(30) NOT NULL)" +
                    "surname NVARCHAR(30) NOT NULL)" +
                    "bio NVARCHAR(150) NULL)" +
                    "likes NVARCHAR(100) NULL)"
                    ;

                SqliteCommand createTable = new SqliteCommand(tableCommand, conn);

                createTable.ExecuteReader();
            }
        }

        //public static string dbname = "../../../../local.sdf";

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
 

        }

        public static List<Person> UpdatePeopleList() // TODO: fix Northwind assemply reference, couldn't figure this out in 3 hours
        {
            return null;
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

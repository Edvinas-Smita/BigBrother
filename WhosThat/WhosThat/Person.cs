using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhosThat.Recognition;

namespace WhosThat
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        public string Likes { get; set; }

        //Reikia prideti nuotrauku lista kurias vartotojas issaugoja, kad profilyje galetume atvaizduoti

        public List<Face> Photos { get; set; }

        public Person(string name, string bio, string likes)
        {
            Name = name;
            Bio = bio;
            Likes = likes;
        }

    }
}

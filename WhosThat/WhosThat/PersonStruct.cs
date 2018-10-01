using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhosThat
{
    public class Person
    {
        
            private string name;

            private string bio;

            private string likes;


            //Reikia prideti nuotrauku lista kurias vartotojas issaugoja, kad profilyje galetume atvaizduoti

            public Person(string name, string bio, string likes)
            {
                this.name = name;
                this.bio = bio;
                this.likes = likes;
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

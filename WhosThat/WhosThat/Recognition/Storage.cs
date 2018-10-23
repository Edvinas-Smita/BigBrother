﻿using System.Collections.Generic;
using System.ComponentModel;

namespace WhosThat.Recognition
{
    public static class Storage
    {
        public static List<Face> Faces { get; set; } = new List<Face>();
        public static BindingList<Person> People = new BindingList<Person>();

        public static Person FindPersonByID(int id)
        {
            foreach (var person in People)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }


    }
}

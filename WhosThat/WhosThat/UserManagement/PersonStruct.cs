using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhosThat.Recognition;

namespace WhosThat
{
    public class Person : INotifyPropertyChanged
    {
	    public event PropertyChangedEventHandler PropertyChanged = delegate(object sender, PropertyChangedEventArgs args) { };

	    public int id;

        private string name;
        private string bio;
        private string likes;

	    public string Name
	    {
		    get { return name; }
		    set
		    {
			    name = value;
			    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
		    }
		}
	    public string Bio
	    {
		    get { return bio; }
		    set
		    {
			    bio = value;
			    PropertyChanged(this, new PropertyChangedEventArgs("Bio"));
		    }
		}
	    public string Likes
	    {
		    get { return likes; }
		    set
		    {
			    likes = value;
			    PropertyChanged(this, new PropertyChangedEventArgs("Likes"));
		    }
	    }
	    public ObservableCollection<Bitmap> Images = new ObservableCollection<Bitmap>();	//Bitmap for testing purposes

        //Reikia prideti nuotrauku lista kurias vartotojas issaugoja, kad profilyje galetume atvaizduoti

        public List<Face> Photos { get; set; }

	    public Person(string name, string bio, string likes)
	    {
		    this.name = name;
		    this.bio = bio;
		    this.likes = likes;

		    Images.CollectionChanged += (sender, args) =>
		    {
			    switch (args.Action)
			    {
					case NotifyCollectionChangedAction.Add:
					case NotifyCollectionChangedAction.Replace:
						foreach (var newImage in args.NewItems)
						{
							((Bitmap) newImage).Tag = new PersonImageExtra();
						}
						break;
			    }
		    };
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

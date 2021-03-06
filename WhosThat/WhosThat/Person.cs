﻿using System;
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
		public event PropertyChangedEventHandler PropertyChanged = delegate (object sender, PropertyChangedEventArgs args) { };

		public int Id;

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
		public ObservableCollection<Bitmap> Images = new ObservableCollection<Bitmap>();

        public Person(string name, string bio, string likes)
        {
            Name = name;
            Bio = bio;
            Likes = likes;

	        Id = IdFactory.GetCurrentId();
        }

    }
}

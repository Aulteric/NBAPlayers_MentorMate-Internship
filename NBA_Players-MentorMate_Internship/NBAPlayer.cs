using System;
using System.Collections.Generic;
using System.Text;

namespace NBA_Players_MentorMate_Internship
{
    class NBAPlayer
    {
        private string name;
        private int playingSince;
        private string position;
        private int rating;
        private int yearsPlaying;



        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int PlayingSince
        {
            get { return playingSince; }
            set { playingSince = value; }
        }

        public string Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public int YearsPlaying
        {
            get { return yearsPlaying; }
            set { yearsPlaying = value; }
        }

        public NBAPlayer(string Name, int PlayingSince, string Position, int Rating)
        {
            this.Name = Name;
            this.PlayingSince = PlayingSince;
            this.Position = Position;
            this.Rating = Rating;
            YearsPlaying = DateTime.Now.Year - PlayingSince;
        }
    }
}

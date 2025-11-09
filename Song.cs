using System;

namespace ADT_Project_2
{
	public class Song
	{
        public int ID {  get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public double Duration { get; set; }
        public string Genre { get; set; }

        public Song(int id, string title, string artist, string album, double duration, string genre)
		{
            ID = id;
            Title = title;
            Artist = artist;
            Album = album;
            Duration = duration;
            Genre = genre;
		}

        public string displaySong()
        {
            return Title + " by " + Artist + ", " + Album + " - " + Duration;
        }
	}
}

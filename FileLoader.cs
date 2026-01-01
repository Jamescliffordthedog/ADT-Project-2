using System;

namespace ADT_Project_2
{
	public class FileLoader
	{
        public static List<Song> LoadSongs(string filePath)
        {
            var songs = new List<Song>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length < 6)
                    continue;

                double duration = ParseDuration(parts[4]);

                songs.Add(new Song(
                    int.Parse(parts[0]),
                    parts[1],
                    parts[2],
                    parts[3],
                    duration,
                    parts[5]
                ));
            }

            return songs;
        }

        private static double ParseDuration(string time)
        {
            var split = time.Split(':');
            int minutes = int.Parse(split[0]);
            int seconds = int.Parse(split[1]);

            return minutes + (seconds / 60.0);
        }
    }
}

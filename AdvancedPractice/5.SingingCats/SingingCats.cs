using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.SingingCats
{
    class SingingCats
    {
        static void Main()
        {
            string c = Console.ReadLine().Split()[0];
            string s = Console.ReadLine().Split()[0];
            byte catsCount = byte.Parse(c);
            byte songsCount = byte.Parse(s);

            string command = Console.ReadLine();

            var songsNumber = new Dictionary<byte, byte>(); // song -> number of cats that know the song
            var songsAndCats = new Dictionary<byte, List<byte>>(); // song -> cats list
            var catAndSongs = new Dictionary<byte, List<byte>>(); // cat song list

            for (byte song = 0; song < songsCount; song++)
            {
                songsNumber.Add(song, 0);
                songsAndCats.Add(song, new List<byte>());
            }
            for (byte cat = 0; cat < catsCount; cat++)
            {
                catAndSongs.Add(cat, new List<byte>());
            }

            while (command != "Mew!")
            {
                string[] commandArgs = command.Split();

                byte cat = byte.Parse(commandArgs[1]);
                byte song = byte.Parse(commandArgs[4]);

                songsNumber[(byte)(song - 1)]++;
                songsAndCats[(byte)(song - 1)].Add((byte)(cat - 1));
                catAndSongs[(byte)(cat - 1)].Add((byte)(song - 1));

                command = Console.ReadLine();
            }

            foreach (var item in catAndSongs)
            {
                if (item.Value.Count == 0)
                {
                    Console.WriteLine("No concert!");
                    return;
                }
            }
            
            byte catSingig = 0;
            byte count = 0;
            while (true)
            {
                count++;
                var sortedSongs = songsNumber.ToList();
                sortedSongs.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

                byte song = sortedSongs[0].Key;
                HashSet<byte> cats = new HashSet<byte>();

                foreach (var cat in songsAndCats[song])
                {
                    cats.Add(cat);
                    catSingig++;
                }

                foreach (var cat in cats)
                {
                    foreach (var sg in catAndSongs[cat])
                    {
                        songsNumber[sg]--;
                    }
                }

                if (catSingig == catsCount)
                {
                    break;
                }
                if (sortedSongs.Count <= 0)
                {
                    break;
                }
            }

            Console.WriteLine(count);
        }
    }
}
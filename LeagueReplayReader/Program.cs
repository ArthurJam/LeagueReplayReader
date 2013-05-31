﻿using System;
using System.IO;
using LeagueReplayReader.Types;

namespace LeagueReplayReader
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Args: <filepath>");
                return;
            }

            string filepath = args[0];

            if (!File.Exists(filepath))
            {
                Console.WriteLine("Error: file not found: {0}", filepath);
                return;
            }

            // instanciate the replay file
            Replay replay = new Replay(filepath);

            Console.WriteLine(replay);
            Console.WriteLine(replay.Header);
            Console.WriteLine(replay.PayloadHeader);

            // handle the entries within the replay file
            while (replay.ReadEntry())
            {
                Console.WriteLine(replay.PayloadEntry);
            }
        }
    }
}

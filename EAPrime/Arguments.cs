using System;
using System.Collections.Generic;

namespace EAPrime
{
    public class Arguments
    {
        // We access the condition a flag is set to by passing the flag as a key to the dictionary.
        private IDictionary<string, string> argDict = new Dictionary<string, string>();

        public Arguments(string[] args)
        {
            // Initialize dictionary with all possible flags.
            argDict.Add("-d", "empty");
            argDict.Add("-p", "0");
            argDict.Add("-h", "0");

            for (int i = 0; i < args.Length; i++)
            {
                // We only want to take action when we encounter flags (indicated by dash).
                if (args[i][0].Equals('-'))
                {
                    switch (args[i][1])
                    {
                        // Flag "-d" indicates that a filepath is specified.
                        case 'd':
                            // Check that filepath was provided by ensuring that argument follows...
                            if (i + 1 < args.Length)
                            {
                                // and is not a flag.
                                if (args[i + 1][0] != '-')
                                {
                                    argDict["-d"] = args[i + 1];
                                }
                                else
                                {
                                    Console.WriteLine("Error: Malformed file path. Please check arguments.");
                                    argDict["-d"] = "empty";
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error: Malformed file path. Please check arguments.");
                                argDict["-d"] = "empty";
                            }
                            break;
                        // Flag "-p" indicates that title printout is enabled.
                        case 'p':
                            argDict["-p"] = "1";
                            break;
                        // Flag "-h" indicates that user wants help guide.
                        case 'h':
                            argDict["-h"] = "1";
                            break;
                        case 'a': // debug, a,b,c are not real flags.
                        case 'b': // debug
                        case 'c': // debug
                            argDict.Add(args[i], args[i]);
                            break;
                        default:
                            Console.WriteLine("Warning: Unrecognized flag.");
                            break;
                    }
                }
            }
        }

        public int getArgumentCount()
        {
            return argDict.Count;
        }

        public string getFilepath()
        {
            return argDict["-d"];
        }

        public bool printoutEnabled()
        {
            return argDict["-p"].Equals("1");
        }

        public void printTitle()
        {
            Console.WriteLine(" ___  ___  ___       _             ");
            Console.WriteLine("| __|/   \\| _ \\ _ _ (_) _ __   ___ ");
            Console.WriteLine("| _| | - ||  _/| '_|| || '  \\ / -_)");
            Console.WriteLine("|___||_|_||_|  |_|  |_||_|_|_|\\___|\n");
        }

        public bool helpEnabled()
        {
            return argDict["-h"].Equals("1");
        }

        public void printHelp()
        {
            Console.WriteLine("Usage:\n");
            Console.WriteLine("-d [filepath]\tSpecifies file to be read.");
            Console.WriteLine("-p\t\tPrints out fancy title.");
            Console.WriteLine("-h\t\tShows optional flags and their usage.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerApp
{
    class LoggerManagement
    {
        private static string _username;
        public string answer, saveFileName, loadFileName, defaultFileName = "logger.txt";
        public string line;
        public StreamWriter writer;
        public StreamReader reader;
        public string menu = @"[1] Operation ALPHA
[2] Operation BETA
[3] Operation GAMMA
[4] Save Logger
[5] Load Logger
[q] Exit
Choose an option: ";

        public bool running = true;

        public static List<String> loggers = new List<String>();
        public static List<String> LoadLoggers = new List<String>();

        public string Menu()
        {
            return menu;
        }

        public LoggerManagement(string username)
        {

            _username = username;
            loggers.Add(username + " signed in.");
            App();
        }

        public void App()
        {
            while (running)
            {
                try
                {
                    Console.ReadLine();
                    Console.Clear();
                    string m = Menu();
                    Console.Write(m);
                    string option = Console.ReadLine();
                    if (option != "q")
                    {
                        int _option = int.Parse(option);
                        if (_option == 1)
                        {
                            Console.WriteLine("Operation ALPHA was entered.");
                            loggers.Add("Operation ALPHA was entered.");
                        }
                        else if (_option == 2)
                        {
                            Console.WriteLine("Operation BETA was entered.");
                            loggers.Add("Operation BETA was entered.");
                        }
                        else if(_option == 3)
                        {
                            Console.WriteLine("Operation GAMMA was entered.");
                            loggers.Add("Operation GAMMA was entered.");
                        }
                        else if(_option == 4)
                        {
                            Console.Write("Do you want to save it as custom file name [y]es [n]o:");
                            answer = Console.ReadLine();
                            answer = answer.ToLower();
                            loggers.Add("Save file was entered.");
                            if(answer == "y" || answer == "yes")
                            {
                                Console.Write("Please enter the file name: ");
                                saveFileName = Console.ReadLine();
                                loggers.Add($"Custom file name was entered as {saveFileName + ".txt"}.");
                                writer = new StreamWriter(saveFileName + ".txt");
                                foreach(string item in loggers)
                                {
                                    writer.WriteLine(item);
                                }
                                writer.Close();
                            }
                            else if (answer == "n" || answer == "no")
                            {
                                loggers.Add($"Default file name was selected. '{defaultFileName}'");
                                writer = new StreamWriter(defaultFileName);
                                foreach (string item in loggers)
                                {
                                    writer.WriteLine(item);
                                }
                                writer.Close();
                            }
                        }
                        else if (_option == 5)
                        {
                            Console.Write("Do you want to load custom file [y]es [n]o:");
                            answer = Console.ReadLine();
                            answer = answer.ToLower();
                            loggers.Add("Load file was entered.");
                            LoadLoggers.Clear();
                            if (answer == "y" || answer == "yes")
                            {
                                Console.Write("Please enter the file name: ");
                                loadFileName = Console.ReadLine();
                                loggers.Add($"Custom file name was entered as {loadFileName + ".txt"}.");
                                reader = new StreamReader(loadFileName + ".txt");
                                line = reader.ReadLine();
                                while(line != null)
                                {
                                    LoadLoggers.Add(line);
                                    line = reader.ReadLine();
                                }
                                reader.Close();
                            }
                            else if (answer == "n" || answer == "no")
                            {
                                loggers.Add($"Default file name was selected. '{defaultFileName}'");
                                reader = new StreamReader(defaultFileName);
                                line = reader.ReadLine();
                                while (line != null)
                                {
                                    LoadLoggers.Add(line);
                                    line = reader.ReadLine();
                                }
                                reader.Close();
                            }
                            foreach (string item in LoadLoggers)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else { Console.WriteLine("Please enter a optioon from the menu!"); }
                    }
                    else if(option == "q")
                    {
                        Console.WriteLine("See you soon");
                        running = false;
                    }
                    else { Console.WriteLine("Please enter a optioon from the menu!"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

    }
}
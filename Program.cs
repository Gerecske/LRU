namespace LRU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> programs = new List<int>();
            List<int> memory = new List<int>();
            
            
            int[] pages = {0, 0, 0, 0};

            // Open the text file using a stream reader
            using (StreamReader reader = new StreamReader("ProgramList.txt"))
            {
                // Read the stream line by line
                while (!reader.EndOfStream)
                {
                    int line = Convert.ToInt32(reader.ReadLine());
                    programs.Add(line);

                    Console.WriteLine(line);
                }
            }

            // Loop through the list of programs
            foreach (int program in programs)
            {
                Console.WriteLine($"P1 [{pages[0]}] P2 [{pages[1]}] P3 [{pages[2]}] P4 [{pages[3]}]");
                
                foreach (int prog in memory)
                {
                    Console.Write(prog + " ");
                }
                Console.Write("\n");
                //chack if the program is in the pages
                if (!pages.Contains(program))
                {
                    for (int i = 0; i < pages.Length; i++)
                    {
                        //If there is still emty space in the pages
                        if (pages[i] == 0)
                        {
                            pages[i] = program;
                            break;
                        }
                        else
                        {
                            //If there is no space in the pages
                            if (i == pages.Length - 1)
                            {
                                //Remove the first program in the pages
                                pages[0] = pages[1];
                                pages[1] = pages[2];
                                pages[2] = pages[3];
                                pages[3] = program;
                            }
                        }
                    }
                    memory.Add(program);
                    Console.WriteLine("Fault");
                }
            }
        }
    }
}
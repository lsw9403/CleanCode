using System;

namespace ArgsExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Args arg = new Args("l,p#,d*", args);
                bool logging = arg.GetBoolean('l');
                int port = arg.GetInt('p');
                string directory =  arg.GetString('d');
                executeApplication(logging, port, directory);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Argument error: {e.Message}\n");
            }
        }
    }
}

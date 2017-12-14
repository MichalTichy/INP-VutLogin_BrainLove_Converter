using System;

namespace VutLogin_BrainLove_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadejte VUT login:");
            string vutLogin = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(vutLogin))
            {
                Console.WriteLine("Zadali jste prázdný text");
                return;
            }
            if (vutLogin[0] != 'X' && vutLogin[0] != 'x')
            {
                Console.WriteLine("Vut login musí začínat písmenem X");
                return;
            }

            Console.WriteLine(VutLoginTranslator.Translate(vutLogin));
            Console.ReadKey();
        }
    }
}

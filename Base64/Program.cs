using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite o caminho do arquivo:");
        string filePath = Console.ReadLine();

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Arquivo não encontrado!");
            return;
        }

        Console.WriteLine("Escolha a operação:");
        Console.WriteLine("1. Codificar em Base64");
        Console.WriteLine("2. Decodificar de Base64");
        int option = Convert.ToInt32(Console.ReadLine());

        if (option == 1)
        {
            string base64EncodedString = ConvertFileToBase64(filePath);
            Console.WriteLine("Conteúdo codificado em Base64:");
            Console.WriteLine(base64EncodedString);
        }
        else if (option == 2)
        {
            Console.WriteLine("Qualquer string em Base64:");
            string base64EncodedString = Console.ReadLine();
            string decodedString = ConvertBase64ToFile(base64EncodedString, filePath);
            Console.WriteLine("Conteúdo decodificado:");
            Console.WriteLine(decodedString);
        }
        else
        {
            Console.WriteLine("Opção inválida.");
        }
    }

    static string ConvertFileToBase64(string filePath)
    {
        byte[] fileBytes = File.ReadAllBytes(filePath);
        return Convert.ToBase64String(fileBytes);
    }

    static string ConvertBase64ToFile(string base64EncodedString, string outputPath)
    {
        try
        {
            byte[] fileBytes = Convert.FromBase64String(base64EncodedString);
            File.WriteAllBytes(outputPath, fileBytes);
            return "Arquivo decodificado com sucesso.";
        }
        catch (FormatException)
        {
            return "String Base64 inválida.";
        }
    }
}

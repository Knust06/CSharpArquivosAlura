﻿using ByteBankIO;
using System.Text;
partial class Program
{
    static void UsarStreamDeEntrada()
    {
        using(var fluxoDeEntrada = Console.OpenStandardInput())
        using(var fs = new FileStream("entradaConsole.txt", FileMode.Create))
        {
            var buffer = new byte[1024]; //1KB

            while (true)
            {
                var byteslidos = fluxoDeEntrada.Read(buffer, 0, 1024);
                fs.Write(buffer, 0, byteslidos);
                fs.Flush();
                Console.WriteLine($"Bytes lidos na console: {byteslidos}");
            }
            
        }
        
    }
}
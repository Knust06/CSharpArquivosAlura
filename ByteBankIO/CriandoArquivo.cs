using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";
        using var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create);
        var contaComoString = "456, 7895, 5487.09, Lucas Knust";

        var encoding = Encoding.UTF8;

        var bytes = encoding.GetBytes(contaComoString);

        fluxoDeArquivo.Write(bytes, 0, bytes.Length);
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "contasExportadas.csv";

        using var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew);
        using var escritor = new StreamWriter(fluxoDeArquivo);
        escritor.Write("456, 65465, 456.0, Lucas Knust");
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "teste.txt";

        using var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create);
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            for (int i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush(); //Despeja o buffer para o Stream!
                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                Console.ReadLine();
            }                        
        }
        
    }

}

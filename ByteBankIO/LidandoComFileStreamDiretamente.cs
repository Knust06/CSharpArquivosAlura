using ByteBankIO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";

        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open, FileAccess.Read))
        {
            var numeroDeBytesLidos = -1;

            var buffer = new byte[1024]; //1KB

            numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                EscreverBuffer(buffer, numeroDeBytesLidos);
            }
            //public override int Read(byte[] array, int offset, int count);

            fluxoDoArquivo.Close();

            Console.ReadLine();
        }

    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();
        var texto = utf8.GetString(buffer, 0, bytesLidos);
        Console.Write(texto);
        //foreach (var meuByte in buffer)
        //{
        //    Console.Write(meuByte);
        //    Console.Write(" ");
        //}
    }


}
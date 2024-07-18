using ByteBankIO;

partial class Program
{
    static void UsandoStreamReader(string[] args)
    {
        var enderecoDoArquivo = "contas.txt";
        using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDeArquivo);

            //var linha = leitor.ReadLine();
            //var texto = leitor.ReadToEnd();
            //var numero = leitor.Read();
            while (!leitor.EndOfStream)
            {
                var linha = leitor.ReadLine();
                var contaCorrente = ConverterStringContaCorrente(linha);
                var msg = $"Conta número {contaCorrente.Numero}, ag. {contaCorrente.Agencia}, saldo {contaCorrente.Saldo}, titular {contaCorrente.Titular.Nome}";
                Console.WriteLine(msg);
            }
        }
        Console.ReadLine();
    }
    static ContaCorrente ConverterStringContaCorrente(string linha)
    {
        var campos = linha.Split(',');


        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2];
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numeroComInt = int.Parse(numero);
        var saldoComDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
        resultado.Depositar(saldoComDouble);
        resultado.Titular = titular;
        return resultado;
    }



}
using System.Text;

partial class Program
{
    static void EscritaBinaria()
    {
        using var fs = new FileStream("testeBinario.txt", FileMode.Create);
        using (var escritor = new BinaryWriter(fs))
        {
            escritor.Write(123);
            escritor.Write(1987539);
            escritor.Write(10.5);
            escritor.Write("Lucas Knust");
        };

    }
    static void LeituraBinaria()
    {
        using var fs = new FileStream("testeBinario.txt", FileMode.Open);
        using (var leitor = new BinaryReader(fs))
        {
            var inteiro = leitor.ReadInt32();
            var inteiro2 = leitor.ReadInt32();
            var double2 = leitor.ReadDouble();
            var nome = leitor.ReadString();
            Console.WriteLine($"{inteiro} {inteiro2} {double2} {nome}");
        }
    }

}

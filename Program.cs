namespace BiteVM
{
    internal class Program
    {
        static void Main()
        {
            var start = DateTime.Now.Millisecond;
            VM vm = new();
            vm.Run(Parser.Parse("input.bite"));
            Console.WriteLine(DateTime.Now.Millisecond - start);
            Console.ReadLine();
        }
    }
}

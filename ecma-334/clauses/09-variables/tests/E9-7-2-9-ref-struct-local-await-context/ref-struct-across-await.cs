/*
Rules: E9-7-2-9-ref-struct-local-await-context
Authority: ECMA-334 7th ed 9.7.2.9
Version: 7.3
Expected: reject
Mutate: ref struct Cell
Into: struct Cell
Csc: CS8370
*/
ref struct Cell { public int Value; }
class Program
{
    static async void Probe()
    {
        Cell cell = new Cell { Value = 74 };
        await System.Threading.Tasks.Task.FromResult(0);
        System.Console.WriteLine(cell.Value);
    }
    static void Main() { }
}

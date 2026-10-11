/*
Rules: E12-8-13-struct-iterator-async-copy; E12-8-13-struct-iterator-async-value
Authority: ECMA-334 7th ed 12.8.13
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: this = new Cell(Value + 1);
Into: Cell copy = new Cell(Value + 1);
*/
using System;
using System.Threading.Tasks;
struct Cell
{
    public int Value;
    public Cell(int value) { Value = value; }
    public async Task<int> Adjust()
    {
        await Task.FromResult(0);
        this = new Cell(Value + 1);
        return Value;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell(9);
        Task<int> result = cell.Adjust();
        Check(result.GetAwaiter().GetResult() == 10, "async-this-is-assignable-value-parameter");
        Check(cell.Value == 9, "async-this-replacement-does-not-change-original");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

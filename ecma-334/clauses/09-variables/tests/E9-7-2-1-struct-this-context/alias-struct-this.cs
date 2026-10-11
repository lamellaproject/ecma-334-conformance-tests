/*
Rules: E9-7-2-1-struct-this-context; E9-7-2-1-struct-this-field-context
Authority: ECMA-334 7th ed 9.7.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: ref Cell alias = ref this;
Into: Cell alias = this;
*/
using System;
struct Cell
{
    public int Value;
    public void Change()
    {
        ref Cell alias = ref this;
        alias = new Cell { Value = 28 };
        Program.Check(Value == 28, "struct-this-reference-valid-within-function-member");
        ref int field = ref this.Value;
        field = 32;
        Program.Check(Value == 32, "struct-this-field-reference-valid-within-function-member");
    }
}
class Program
{
    static int checks, failures;
    public static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell cell = new Cell();
        cell.Change();
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E18-4-5-indexer-ref-form
Authority: ECMA-334 7th ed 18.4.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public ref int this[int index] { get { return ref values[index]; } }
Into: public ref int this[int index] { get { return ref values[0]; } }
*/
using System;
interface ICells { ref int this[int index] { get; } }
class Cells : ICells
{
    int[] values = new int[] { 113, 127 };
    public ref int this[int index] { get { return ref values[index]; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ICells cells = new Cells();
        ref int value = ref cells[1];
        Check(value == 127, "ref-indexer-result");
        value = 131;
        Check(cells[1] == 131, "ref-indexer-write");
        Check(cells[0] == 113, "other-ref-indexer-slot");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

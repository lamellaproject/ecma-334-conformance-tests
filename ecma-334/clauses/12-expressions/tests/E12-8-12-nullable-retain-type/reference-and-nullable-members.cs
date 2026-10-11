/*
Rules: E12-8-12-nullable-retain-type; E12-8-12-nullable-retain-null; E12-8-12-nullable-retain-present
Authority: ECMA-334 7th ed 12.8.12
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: full?[1]
Into: empty?[1]
*/
using System;
struct Cell
{
    public string this[int index] { get { return "elm"; } }
    public int? this[long index] { get { return 47; } }
}
class Program
{
    static int checks, failures;
    static int Kind(string value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Cell? full = new Cell(), empty = null;
        var text = full?[1];
        Check(Kind(text) == 1 && text == "elm", "nullable-receiver-retains-reference-result-type");
        var absent = empty?[0];
        Check(Kind(absent) == 1 && absent == null, "nullable-receiver-reference-result-null");
        int? number = full?[1L];
        Check(number == 47, "already-nullable-indexer-result-retained");
        number = empty?[1L];
        Check(!number.HasValue, "absent-receiver-already-nullable-result");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

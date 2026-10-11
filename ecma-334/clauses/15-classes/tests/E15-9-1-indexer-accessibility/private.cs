/*
Rules: E15-9-1-indexer-accessibility; E15-9-1-grammar-indexer-modifier-form-5
Authority: ECMA-334 7th ed 15.9.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: private int this[int index]
Into: public private int this[int index]
*/
using System;
class Grid
{
    private int this[int index] => index * 4;
    public class Client { public static int Read(Grid grid) { return grid[3]; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Grid.Client.Read(new Grid()) == 12, "private-indexer-nested-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

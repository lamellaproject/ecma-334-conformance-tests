/*
Rules: E10-3-5-null
Authority: ECMA-334 7th ed 10.3.5
Version: 7.3
Expected: run
Stdout: OK 4
Fixture: {"arguments":["empty"]}
Mutate: object[] references = (object[])source;
Into: object[] references = new object[0];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Convert(object source)
    {
        object[] references = (object[])source;
        int[] integers = (int[])source;
        int[][] jagged = (int[][])source;
        int[,] rectangular = (int[,])source;
        Check(references == null, "null-to-reference-vector");
        Check(integers == null, "null-to-value-vector");
        Check(jagged == null, "null-to-jagged-array");
        Check(rectangular == null, "null-to-rectangular-array");
    }
    static void Main(string[] arguments)
    {
        object source = arguments.Length == 1 ? null : new object();
        Convert(source);
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

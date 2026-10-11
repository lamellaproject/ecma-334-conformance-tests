/*
Rules: E13-9-5-fresh-iteration-variable
Authority: ECMA-334 7th ed 13.9.5
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: foreach (int item in values) { reads[next++] = () => item; }
Into: int item = 0; foreach (int element in values) { item = element; reads[next++] = () => item; }
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int[] values = new int[] { 12, 27 };
        Func<int>[] reads = new Func<int>[2];
        int next = 0;
        foreach (int item in values) { reads[next++] = () => item; }
        Check(reads[0]() == 12, "first-capture-keeps-first-element");
        Check(reads[1]() == 27, "second-capture-keeps-second-element");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

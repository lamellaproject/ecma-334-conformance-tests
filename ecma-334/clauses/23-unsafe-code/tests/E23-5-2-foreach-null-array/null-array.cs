/*
Rules: E23-5-2-foreach-null-array
Authority: ECMA-334 7th ed 23.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int*[] items = null;
Into: int*[] items = new int*[0];
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        int*[] items = null;
        bool correct = false;
        try
        {
            foreach (int* current in items) Check(false, "null-array-body");
        }
        catch (NullReferenceException) { correct = true; }
        catch (Exception) { }
        Check(correct, "null-array-null-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

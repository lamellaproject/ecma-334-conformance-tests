/*
Rules: E21-5-negative-array-index; E21-5-high-array-index
Authority: ECMA-334 7th ed 21.5
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: int negative = -1
Into: int negative = 0
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static bool Outside(int[] values, int index)
    {
        try { int item = values[index]; }
        catch (IndexOutOfRangeException) { return true; }
        catch (Exception) { }
        return false;
    }
    static void Main()
    {
        int[] values = new int[2]; int negative = -1;
        Check(Outside(values, negative), "negative-index-exception");
        Check(Outside(values, 2), "index-at-bound-exception");
        Check(Outside(values, 3), "index-past-bound-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

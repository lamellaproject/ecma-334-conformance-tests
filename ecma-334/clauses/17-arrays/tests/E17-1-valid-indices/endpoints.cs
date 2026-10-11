/*
Rules: E17-1-valid-indices
Authority: ECMA-334 7th ed 17.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: new int[3]
Into: new int[4]
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
        int[] values = new int[3];
        values[0] = 11; values[2] = 31;
        Check(values[0] == 11, "first-valid");
        Check(values[2] == 31, "last-valid");
        Check(Outside(values, -1), "below-zero");
        Check(Outside(values, 3), "at-length");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

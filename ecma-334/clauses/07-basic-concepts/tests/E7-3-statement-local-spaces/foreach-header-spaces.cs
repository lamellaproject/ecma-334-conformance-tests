/*
Rules: E7-3-statement-local-spaces
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: foreach (int item in new int[] { 9 }) total += item;
Into: foreach (int item in new int[] { 9 }) total -= item;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int total = 0;
        foreach (int item in new int[] { 6 }) total += item;
        foreach (int item in new int[] { 9 }) total += item;
        Check(total == 15, "braced-foreach-headers");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

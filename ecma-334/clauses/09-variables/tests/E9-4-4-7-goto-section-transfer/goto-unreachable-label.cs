/*
Rules: E9-4-4-7-goto-section-transfer; E9-4-4-7-unreachable-label-transfer
Authority: ECMA-334 7th ed 9.4.4.7
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: cell = 49;
Into: ;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read()
    {
        int cell;
        switch (0)
        {
            case 0: cell = 49; goto case 1;
            case 1: return cell;
            default: return -1;
        }
    }
    static void Main()
    {
        Check(Read() == 49, "goto-assignment-joins-with-unreachable-label");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

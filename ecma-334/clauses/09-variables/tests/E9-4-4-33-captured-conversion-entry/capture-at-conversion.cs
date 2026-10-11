/*
Rules: E9-4-4-33-captured-conversion-entry; E9-4-4-33-conversion-body-path
Authority: ECMA-334 7th ed 9.4.4.33
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: int cell = 19;
Into: int cell;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int cell = 19;
        int Read() { return cell; }
        Func<int> reader = Read;
        Check(reader() == 19, "capture-assigned-before-conversion");
        cell = 27;
        Check(reader() == 27, "converted-delegate-reads-current-capture");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E10-8-ed3-fresh-method-group-conversion
Authority: ECMA-334 3rd ed 13.6
Version: ISO-2
Expected: run
Stdout: OK 2
Version-Witness: version-witnesses/E10-8-ed3-fresh-method-group-conversion/repeated-static-conversion.cs.part
Mutate: Reader second = Convert();
Into: Reader second = first;
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
    delegate int Reader();
    static int ReadValue() { return 43; }
    static Reader Convert() { return ReadValue; }
    static int Main()
    {
        Reader first = Convert();
        Reader second = Convert();
        Check(first() == 43 && second() == 43, "method-group-target");
        Check(!object.ReferenceEquals(first, second), "fresh-implicit-delegates");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

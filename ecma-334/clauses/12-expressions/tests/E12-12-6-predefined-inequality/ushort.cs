/*
Rules: E12-12-6-predefined-inequality; E12-12-6-underlying-comparison; E12-12-1-predefined-bool; E12-12-1-inequality-result
Authority: ECMA-334 7th ed 12.12.6
Version: 7.3
Expected: run
Stdout: OK 7
Generated: clauses/12-expressions/generators/comparisons.py
*/
using System;
enum E : ushort { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E A(E value) { return value; }
    static int Kind(bool value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check((A((E)(0)) != A((E)(65535))) == true && Kind(A((E)(0)) != A((E)(65535))) == 1, "case-0");
        Check((A((E)(65535)) != A((E)(0))) == true && Kind(A((E)(65535)) != A((E)(0))) == 1, "case-1");
        Check((A((E)(0)) != A((E)(0))) == false && Kind(A((E)(0)) != A((E)(0))) == 1, "case-2");
        Check((A((E)(65535)) != A((E)(65535))) == false && Kind(A((E)(65535)) != A((E)(65535))) == 1, "case-3");
        Check((A((E)(19)) != A((E)(4))) == true && Kind(A((E)(19)) != A((E)(4))) == 1, "case-4");
        Check((A((E)(4)) != A((E)(19))) == true && Kind(A((E)(4)) != A((E)(19))) == 1, "case-5");
        Check((A((E)(4)) != A((E)(4))) == false && Kind(A((E)(4)) != A((E)(4))) == 1, "case-6");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

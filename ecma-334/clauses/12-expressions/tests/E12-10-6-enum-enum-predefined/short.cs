/*
Rules: E12-10-6-enum-enum-predefined; E12-10-6-enum-enum-value; E12-10-6-enum-enum-result-type
Authority: ECMA-334 7th ed 12.10.6
Version: 7.3
Expected: run
Stdout: OK 3
Generated: clauses/12-expressions/generators/arithmetic.py
*/
using System;
enum E : short { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E V(short value) { return (E)value; }
    static short A(short value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(short value) { return 2; }
    static void Main()
    {
        Check((short)unchecked(V(19) - V(4)) == 15 && Kind(unchecked(V(19) - V(4))) == 2, "case-0");
        Check((short)unchecked(V(-32768) - V(1)) == 32767 && Kind(unchecked(V(-32768) - V(1))) == 2, "case-1");
        Check((short)unchecked(V(32767) - V(1)) == 32766 && Kind(unchecked(V(32767) - V(1))) == 2, "case-2");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

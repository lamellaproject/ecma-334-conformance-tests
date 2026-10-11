/*
Rules: E12-13-3-predefined-xor; E12-13-3-underlying-operation
Authority: ECMA-334 7th ed 12.13.3
Version: 7.3
Expected: run
Stdout: OK 12
Generated: clauses/12-expressions/generators/logical.py
*/
using System;
enum E : ushort { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E A(E value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A((E)(0)) ^ A((E)(65535))) == (E)(65535) && Kind(checked(A((E)(0)) ^ A((E)(65535)))) == 1, "case-0");
        Check(checked(A((E)(65535)) ^ A((E)(65535))) == (E)(0) && Kind(checked(A((E)(65535)) ^ A((E)(65535)))) == 1, "case-1");
        Check(checked(A((E)(0)) ^ A((E)(65535))) == (E)(65535) && Kind(checked(A((E)(0)) ^ A((E)(65535)))) == 1, "case-2");
        Check(checked(A((E)(21845)) ^ A((E)(43690))) == (E)(65535) && Kind(checked(A((E)(21845)) ^ A((E)(43690)))) == 1, "case-3");
        Check(checked(A((E)(21845)) ^ A((E)(21845))) == (E)(0) && Kind(checked(A((E)(21845)) ^ A((E)(21845)))) == 1, "case-4");
        Check(checked(A((E)(23)) ^ A((E)(12))) == (E)(27) && Kind(checked(A((E)(23)) ^ A((E)(12)))) == 1, "case-5");
        Check(unchecked(A((E)(0)) ^ A((E)(65535))) == (E)(65535) && Kind(unchecked(A((E)(0)) ^ A((E)(65535)))) == 1, "case-6");
        Check(unchecked(A((E)(65535)) ^ A((E)(65535))) == (E)(0) && Kind(unchecked(A((E)(65535)) ^ A((E)(65535)))) == 1, "case-7");
        Check(unchecked(A((E)(0)) ^ A((E)(65535))) == (E)(65535) && Kind(unchecked(A((E)(0)) ^ A((E)(65535)))) == 1, "case-8");
        Check(unchecked(A((E)(21845)) ^ A((E)(43690))) == (E)(65535) && Kind(unchecked(A((E)(21845)) ^ A((E)(43690)))) == 1, "case-9");
        Check(unchecked(A((E)(21845)) ^ A((E)(21845))) == (E)(0) && Kind(unchecked(A((E)(21845)) ^ A((E)(21845)))) == 1, "case-10");
        Check(unchecked(A((E)(23)) ^ A((E)(12))) == (E)(27) && Kind(unchecked(A((E)(23)) ^ A((E)(12)))) == 1, "case-11");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E12-13-2-predefined-xor; E12-13-2-bitwise-xor; E12-13-2-no-overflow
Authority: ECMA-334 7th ed 12.13.2
Version: 7.3
Expected: run
Stdout: OK 12
Generated: clauses/12-expressions/generators/logical.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static uint A(uint value) { return value; }
    static int Kind(uint value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A(0U) ^ A(4294967295U)) == 4294967295U && Kind(checked(A(0U) ^ A(4294967295U))) == 1, "case-0");
        Check(checked(A(4294967295U) ^ A(4294967295U)) == 0U && Kind(checked(A(4294967295U) ^ A(4294967295U))) == 1, "case-1");
        Check(checked(A(0U) ^ A(4294967295U)) == 4294967295U && Kind(checked(A(0U) ^ A(4294967295U))) == 1, "case-2");
        Check(checked(A(1431655765U) ^ A(2863311530U)) == 4294967295U && Kind(checked(A(1431655765U) ^ A(2863311530U))) == 1, "case-3");
        Check(checked(A(1431655765U) ^ A(1431655765U)) == 0U && Kind(checked(A(1431655765U) ^ A(1431655765U))) == 1, "case-4");
        Check(checked(A(23U) ^ A(12U)) == 27U && Kind(checked(A(23U) ^ A(12U))) == 1, "case-5");
        Check(unchecked(A(0U) ^ A(4294967295U)) == 4294967295U && Kind(unchecked(A(0U) ^ A(4294967295U))) == 1, "case-6");
        Check(unchecked(A(4294967295U) ^ A(4294967295U)) == 0U && Kind(unchecked(A(4294967295U) ^ A(4294967295U))) == 1, "case-7");
        Check(unchecked(A(0U) ^ A(4294967295U)) == 4294967295U && Kind(unchecked(A(0U) ^ A(4294967295U))) == 1, "case-8");
        Check(unchecked(A(1431655765U) ^ A(2863311530U)) == 4294967295U && Kind(unchecked(A(1431655765U) ^ A(2863311530U))) == 1, "case-9");
        Check(unchecked(A(1431655765U) ^ A(1431655765U)) == 0U && Kind(unchecked(A(1431655765U) ^ A(1431655765U))) == 1, "case-10");
        Check(unchecked(A(23U) ^ A(12U)) == 27U && Kind(unchecked(A(23U) ^ A(12U))) == 1, "case-11");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E12-13-2-predefined-and; E12-13-2-bitwise-and; E12-13-2-no-overflow
Authority: ECMA-334 7th ed 12.13.2
Version: 7.3
Expected: run
Stdout: OK 16
Generated: clauses/12-expressions/generators/logical.py
*/
using System;

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int A(int value) { return value; }
    static int Kind(int value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A(-2147483648) & A(2147483647)) == 0 && Kind(checked(A(-2147483648) & A(2147483647))) == 1, "case-0");
        Check(checked(A(2147483647) & A(2147483647)) == 2147483647 && Kind(checked(A(2147483647) & A(2147483647))) == 1, "case-1");
        Check(checked(A(0) & A(2147483647)) == 0 && Kind(checked(A(0) & A(2147483647))) == 1, "case-2");
        Check(checked(A(1431655765) & A(-1431655766)) == 0 && Kind(checked(A(1431655765) & A(-1431655766))) == 1, "case-3");
        Check(checked(A(1431655765) & A(1431655765)) == 1431655765 && Kind(checked(A(1431655765) & A(1431655765))) == 1, "case-4");
        Check(checked(A(23) & A(12)) == 4 && Kind(checked(A(23) & A(12))) == 1, "case-5");
        Check(checked(A(-1) & A(1431655765)) == 1431655765 && Kind(checked(A(-1) & A(1431655765))) == 1, "case-6");
        Check(checked(A(-19) & A(-4)) == -20 && Kind(checked(A(-19) & A(-4))) == 1, "case-7");
        Check(unchecked(A(-2147483648) & A(2147483647)) == 0 && Kind(unchecked(A(-2147483648) & A(2147483647))) == 1, "case-8");
        Check(unchecked(A(2147483647) & A(2147483647)) == 2147483647 && Kind(unchecked(A(2147483647) & A(2147483647))) == 1, "case-9");
        Check(unchecked(A(0) & A(2147483647)) == 0 && Kind(unchecked(A(0) & A(2147483647))) == 1, "case-10");
        Check(unchecked(A(1431655765) & A(-1431655766)) == 0 && Kind(unchecked(A(1431655765) & A(-1431655766))) == 1, "case-11");
        Check(unchecked(A(1431655765) & A(1431655765)) == 1431655765 && Kind(unchecked(A(1431655765) & A(1431655765))) == 1, "case-12");
        Check(unchecked(A(23) & A(12)) == 4 && Kind(unchecked(A(23) & A(12))) == 1, "case-13");
        Check(unchecked(A(-1) & A(1431655765)) == 1431655765 && Kind(unchecked(A(-1) & A(1431655765))) == 1, "case-14");
        Check(unchecked(A(-19) & A(-4)) == -20 && Kind(unchecked(A(-19) & A(-4))) == 1, "case-15");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

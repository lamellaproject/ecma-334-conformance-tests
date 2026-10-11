/*
Rules: E12-13-3-predefined-or; E12-13-3-underlying-operation
Authority: ECMA-334 7th ed 12.13.3
Version: 7.3
Expected: run
Stdout: OK 12
Generated: clauses/12-expressions/generators/logical.py
*/
using System;
enum E : byte { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static E A(E value) { return value; }
    static int Kind(E value) { return 1; }
    static int Kind(object value) { return 2; }
    static void Main()
    {
        Check(checked(A((E)(0)) | A((E)(255))) == (E)(255) && Kind(checked(A((E)(0)) | A((E)(255)))) == 1, "case-0");
        Check(checked(A((E)(255)) | A((E)(255))) == (E)(255) && Kind(checked(A((E)(255)) | A((E)(255)))) == 1, "case-1");
        Check(checked(A((E)(0)) | A((E)(255))) == (E)(255) && Kind(checked(A((E)(0)) | A((E)(255)))) == 1, "case-2");
        Check(checked(A((E)(85)) | A((E)(170))) == (E)(255) && Kind(checked(A((E)(85)) | A((E)(170)))) == 1, "case-3");
        Check(checked(A((E)(85)) | A((E)(85))) == (E)(85) && Kind(checked(A((E)(85)) | A((E)(85)))) == 1, "case-4");
        Check(checked(A((E)(23)) | A((E)(12))) == (E)(31) && Kind(checked(A((E)(23)) | A((E)(12)))) == 1, "case-5");
        Check(unchecked(A((E)(0)) | A((E)(255))) == (E)(255) && Kind(unchecked(A((E)(0)) | A((E)(255)))) == 1, "case-6");
        Check(unchecked(A((E)(255)) | A((E)(255))) == (E)(255) && Kind(unchecked(A((E)(255)) | A((E)(255)))) == 1, "case-7");
        Check(unchecked(A((E)(0)) | A((E)(255))) == (E)(255) && Kind(unchecked(A((E)(0)) | A((E)(255)))) == 1, "case-8");
        Check(unchecked(A((E)(85)) | A((E)(170))) == (E)(255) && Kind(unchecked(A((E)(85)) | A((E)(170)))) == 1, "case-9");
        Check(unchecked(A((E)(85)) | A((E)(85))) == (E)(85) && Kind(unchecked(A((E)(85)) | A((E)(85)))) == 1, "case-10");
        Check(unchecked(A((E)(23)) | A((E)(12))) == (E)(31) && Kind(unchecked(A((E)(23)) | A((E)(12)))) == 1, "case-11");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E9-2-6-reference-parameter-referent; E9-2-6-reference-parameter-category; E9-2-6-reference-parameter-reference-variable; E9-2-6-reference-parameter-lifetime-start; E9-2-6-reference-parameter-initially-assigned; E9-4-2-reference-parameter-assigned
Authority: ECMA-334 7th ed 9.2.6
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: left = 46;
Into: left = 9;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Edit(ref int left, ref int right)
    {
        Check(left == 9 && right == 9, "ref-parameters-read-initial-argument");
        left = 46;
        Check(right == 46, "two-parameters-share-argument-storage");
    }
    static void Main()
    {
        int cell = 9;
        Edit(ref cell, ref cell);
        Check(cell == 46, "referent-update-visible-to-caller");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

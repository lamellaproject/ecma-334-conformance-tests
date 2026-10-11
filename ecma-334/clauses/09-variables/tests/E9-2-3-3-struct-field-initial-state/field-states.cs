/*
Rules: E9-2-3-3-struct-field-initial-state; E9-2-3-3-struct-field-lifetime; E9-4-1-struct-assignment-tracking; E9-4-1-assigned-struct-implies-fields; E9-4-1-assigned-fields-imply-struct; E9-4-1-struct-member-receiver-not-read; E9-4-2-struct-field-assigned
Authority: ECMA-334 7th ed 9.2.3.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: local.Right = 32;
Into: local.Right = 0;
*/
using System;
struct Pair { public int Left, Right; }
class Program
{
    static int checks, failures;
    static Pair shared;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(shared.Left == 0 && shared.Right == 0, "initially-assigned-container-fields");
        Pair local;
        local.Left = 19;
        Check(local.Left == 19, "one-field-assigned-before-other");
        local.Right = 32;
        Pair copy = local;
        Check(copy.Left == 19 && copy.Right == 32, "all-fields-alive-with-container");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

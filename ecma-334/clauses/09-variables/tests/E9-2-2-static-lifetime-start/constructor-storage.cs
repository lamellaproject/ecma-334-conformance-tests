/*
Rules: E9-2-2-static-lifetime-start; E9-2-2-static-field-category; E9-2-2-static-initial-value; E9-2-2-static-initially-assigned; E9-3-static-default-initialization; E9-1-assigned-initial-value; E9-1-initially-assigned-definite; E9-4-2-static-assigned
Authority: ECMA-334 7th ed 9.2.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public static int Cell;
Into: public static int Cell = 9;
*/
using System;
class Store
{
    public static int Cell;
    public static int Before;
    static Store() { Before = Cell; Cell = 38; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Store.Before == 0, "storage-exists-default-before-constructor");
        Check(Store.Cell == 38, "constructor-updates-static-storage");
        Store.Cell = 52;
        Check(Store.Cell == 52, "static-storage-after-constructor");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

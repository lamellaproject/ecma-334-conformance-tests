/*
Rules: E9-2-3-2-class-field-lifetime-start; E9-2-3-1-instance-field-category; E9-2-3-2-class-field-initial-value; E9-2-3-2-class-field-initially-assigned; E9-3-class-field-default-initialization; E9-4-2-class-field-assigned
Authority: ECMA-334 7th ed 9.2.3.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public int Cell;
Into: public int Cell = 11;
*/
using System;
class Store
{
    public int Cell;
    public int Before;
    public Store(int value) { Before = Cell; Cell = value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Store a = new Store(27), b = new Store(64);
        Check(a.Before == 0 && b.Before == 0, "storage-default-before-instance-constructor");
        Check(a.Cell == 27 && b.Cell == 64, "each-instance-has-storage");
        a.Cell = 83;
        Check(b.Cell == 64, "instance-storages-are-independent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

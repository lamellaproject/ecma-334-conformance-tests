/*
Rules: E15-2-6-body-defines-members; E15-2-6-grammar-class-body
Authority: ECMA-334 7th ed 15.2.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Read() { return Number + 2; }
Into: 
*/
using System;
class Record
{
    public int Number = 257;
    public int Read() { return Number + 2; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Record item = new Record();
        Check(item.Number == 257, "class-body-declares-field-member");
        Check(item.Read() == 259, "class-body-declares-method-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

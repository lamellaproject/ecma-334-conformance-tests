/*
Rules: E15-7-2-static-property-classification; E15-7-2-static-property-no-instance
Authority: ECMA-334 7th ed 15.7.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static int Item
Into: public int Item
*/
using System;
class Box
{
    static int stored;
    public static int Item { get { return stored; } set { stored = value; } }
    public void Write(int amount) { Item = amount; }
    public int Read() { return Item; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box a = new Box(), b = new Box();
        a.Write(36);
        Check(Box.Item == 36 && b.Read() == 36, "static-shared-by-instances");
        Box.Item = 47;
        Check(a.Read() == 47 && b.Read() == 47, "static-access-without-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

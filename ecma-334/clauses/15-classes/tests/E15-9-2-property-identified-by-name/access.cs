/*
Rules: E15-9-2-property-identified-by-name; E15-9-2-property-simple-name-access; E15-9-2-property-member-access; E15-9-2-property-get-no-parameters; E15-9-2-property-set-value-parameter
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: set { stored = value + 2; }
Into: set { stored = value + 3; }
*/
using System;
class Box
{
    int stored;
    public int Left { get { return stored; } set { stored = value + 2; } }
    public int Right { get { return 19; } }
    public int Read() { return Left; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Box box = new Box();
        box.Left = 7;
        Check(box.Left == 9, "named-property-member-access-and-value");
        Check(box.Read() == 9, "property-simple-name-get");
        Check(box.Right == 19, "other-property-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

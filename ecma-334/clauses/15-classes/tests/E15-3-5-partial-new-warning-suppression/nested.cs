/*
Rules: E15-3-5-partial-new-warning-suppression
Authority: ECMA-334 7th ed 15.3.5
Version: 7.3
Expected: run
Stdout: OK 2
Diagnostic: none
Mutate: public new partial class Entry { public int Left; }
Into: public partial class Entry { public int Left; }
*/
using System;
// A new modifier on either part suppresses the hiding warning.
class Parent { public class Entry { } }
class Child : Parent
{
    public new partial class Entry { public int Left; }
    public partial class Entry { public int Right; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Child.Entry value = new Child.Entry();
        value.Left = 419;
        value.Right = 421;
        Check(value.Left == 419, "new-part-of-hiding-nested-type");
        Check(value.Right == 421, "other-part-shares-warning-suppression");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

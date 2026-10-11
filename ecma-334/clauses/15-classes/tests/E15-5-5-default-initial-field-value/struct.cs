/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public Pair Value;
Into: public Pair Value = new Pair { Number = 1 };
*/
using System;
struct Pair { public int Number; public object Item; }
class Holder { public Pair Value; public static Pair Global; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Value.Number == 0, "instance-struct-value-member-default");
        Check(value.Value.Item == null, "instance-struct-reference-member-default");
        Check(Holder.Global.Number == 0, "static-struct-value-member-default");
        Check(Holder.Global.Item == null, "static-struct-reference-member-default");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

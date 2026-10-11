/*
Rules: E7-6-byref-matching-distinct
Authority: ECMA-334 7th ed 7.6
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: public int Read(out int value)
Into: public override int Read(out int value)
*/
using System;
class Root { public virtual int Read(ref int value) { value++; return 173; } }
class OutBranch : Root { public int Read(out int value) { value = 179; return 181; } }
class InBranch : Root { public int Read(in int value) { return value + 2; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        OutBranch first = new OutBranch();
        InBranch second = new InBranch();
        int value = 5;
        Check(first.Read(ref value) == 173 && value == 6, "ref-base-member-not-hidden-by-out-member");
        Check(first.Read(out value) == 181 && value == 179, "out-member-in-derived-type");
        value = 7;
        Check(second.Read(ref value) == 173 && value == 8, "ref-base-member-not-hidden-by-in-member");
        Check(second.Read(in value) == 10, "in-member-in-derived-type");
        Check(value == 8, "in-member-preserves-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

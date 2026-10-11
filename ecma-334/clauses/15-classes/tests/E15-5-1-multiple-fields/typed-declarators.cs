/*
Rules: E15-5-1-multiple-fields; E15-5-1-declared-field-type; E15-5-1-declarator-one-field; E15-5-1-grammar-variable-declarators; E15-5-1-grammar-variable-declarator; E15-5-1-optional-initial-value; E15-5-1-field-variable
Authority: ECMA-334 7th ed 15.5.1
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: public long First, Second = 431, Third = 457;
Into: public int First, Second = 431, Third = 457;
*/
using System;
class Holder { public long First, Second = 431, Third = 457; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Kind(long value) { return 1; }
    static int Kind(int value) { return 2; }
    static void Main()
    {
        Holder value = new Holder();
        Check(Kind(value.First) == 1, "first-field-declared-type");
        Check(Kind(value.Second) == 1, "second-field-declared-type");
        Check(Kind(value.Third) == 1, "third-field-declared-type");
        Check(value.First == 0, "field-without-initializer");
        Check(value.Second == 431, "second-field-initial-value");
        Check(value.Third == 457, "third-field-initial-value");
        value.First = 479;
        Check(value.First == 479 && value.Second == 431 && value.Third == 457, "distinct-field-variables");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

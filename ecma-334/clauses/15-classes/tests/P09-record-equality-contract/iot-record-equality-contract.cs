/*
Rules: P09-record-equality-contract
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 5
Mutate: record Tagged(int Id, int Tag) : Datum(Id);
Into: record Tagged(int Id, int Tag) : Datum(Id) { protected override Type EqualityContract { get { return typeof(Datum); } } }
*/
using System;
record Datum(int Id);
record Tagged(int Id, int Tag) : Datum(Id);
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Datum plain = new Datum(11);
        Datum extended = new Tagged(11, 2);
        Check(!plain.Equals(extended), "base-to-derived");
        Check(!extended.Equals(plain), "derived-to-base");
        Check(!extended.Equals(new Tagged(11, 3)), "derived-fields");
        Check(!extended.Equals(new Tagged(12, 2)), "inherited-field");
        Check(extended.Equals(new Tagged(11, 2)), "same-derived-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

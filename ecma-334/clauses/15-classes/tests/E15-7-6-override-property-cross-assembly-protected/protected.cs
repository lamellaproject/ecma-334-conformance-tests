/*
Rules: E15-7-6-override-property-cross-assembly-protected
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: run
Stdout: OK 0
Fixture: {"libraries":[{"name":"ClassesPropertyFixture","units":[{"source":"fixtures/property-base.cs.part"}]}],"program":{"references":[{"library":"ClassesPropertyFixture"}]}}
Mutate: protected override int State
Into: protected internal override int State
*/
using System;
class Derived : ClassesFixture.ExternalBase { protected override int State { get { return 21; } set { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}

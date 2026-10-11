/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: run
Stdout: OK 0
Fixture: {"libraries":[{"name":"ClassesIndexerFixture","units":[{"source":"fixtures/indexer-base.cs.part"}]}],"program":{"references":[{"library":"ClassesIndexerFixture"}]}}
Mutate: protected override int this[int index]
Into: protected internal override int this[int index]
*/
using System;
class Derived : ClassesIndexerFixture.ExternalBase { protected override int this[int index] { get { return index; } set { } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main() { if (failures == 0) Console.WriteLine("OK " + checks); }
}

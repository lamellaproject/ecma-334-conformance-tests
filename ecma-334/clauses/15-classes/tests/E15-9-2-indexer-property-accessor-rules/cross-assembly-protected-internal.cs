/*
Rules: E15-9-2-indexer-property-accessor-rules
Authority: ECMA-334 7th ed 15.9.2
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"ClassesIndexerFixture","units":[{"source":"fixtures/indexer-base.cs.part"}]}],"program":{"references":[{"library":"ClassesIndexerFixture"}]}}
Mutate: protected internal override int this[int index]
Into: protected override int this[int index]
Csc: CS0507
*/
class Derived : ClassesIndexerFixture.ExternalBase { protected internal override int this[int index] { get { return index; } set { } } }
class Program { static void Main() { } }

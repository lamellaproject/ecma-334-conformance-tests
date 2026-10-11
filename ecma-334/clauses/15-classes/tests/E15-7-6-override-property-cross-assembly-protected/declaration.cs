/*
Rules: E15-7-6-override-property-cross-assembly-protected
Authority: ECMA-334 7th ed 15.7.6
Version: 7.3
Expected: reject
Fixture: {"libraries":[{"name":"ClassesPropertyFixture","units":[{"source":"fixtures/property-base.cs.part"}]}],"program":{"references":[{"library":"ClassesPropertyFixture"}]}}
Mutate: protected internal override int State
Into: protected override int State
*/
class Derived : ClassesFixture.ExternalBase { protected internal override int State { get { return 17; } set { } } }
class Program { static void Main() { } }

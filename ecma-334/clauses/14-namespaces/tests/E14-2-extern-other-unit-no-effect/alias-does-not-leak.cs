/*
Rules: E14-2-extern-other-unit-no-effect
Authority: ECMA-334 7th ed 14.2
Version: 7.3
Expected: reject
Fixture: {"program":{"references":[{"alias":"Outside","asset":"System.Runtime.dll"}],"units":[{"source":"self"},{"source":"tests/E14-2-extern-other-unit-no-effect/alias.cs.part"}]}}
Mutate: Outside::System.Int32 value
Into: System.Int32 value
*/
class Program
{
    static void Main() { Outside::System.Int32 value = 29; }
}

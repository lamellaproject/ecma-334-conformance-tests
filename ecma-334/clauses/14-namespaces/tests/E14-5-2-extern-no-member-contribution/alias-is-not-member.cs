/*
Rules: E14-5-2-extern-no-member-contribution
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: reject
Fixture: {"program":{"references":[{"alias":"Outside","asset":"System.Runtime.dll"}]}}
Mutate: global::Outside.System.Int32 value
Into: Outside::System.Int32 value
*/
extern alias Outside;
class Program
{
    static void Main() { global::Outside.System.Int32 value = 29; }
}

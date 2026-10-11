/*
Rules: E14-4-extern-not-global
Authority: ECMA-334 7th ed 14.4
Version: 7.3
Expected: reject
Fixture: {"program":{"references":[{"alias":"External","asset":"System.Runtime.dll"}]}}
Mutate: extern alias global;
Into: extern alias External;
*/
extern alias global;
class Program
{
    static void Main() {  }
}

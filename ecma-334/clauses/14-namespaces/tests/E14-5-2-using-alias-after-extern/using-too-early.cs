/*
Rules: E14-5-2-using-alias-after-extern
Authority: ECMA-334 7th ed 14.5.2
Version: 7.3
Expected: reject
Fixture: {"program":{"references":[{"alias":"Outside","asset":"System.Runtime.dll"}]}}
Mutate: using Value = System.Int32;
Into: // No using precedes the extern.
*/
using Value = System.Int32;
extern alias Outside;
class Program
{
    static void Main() {  }
}

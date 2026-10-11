/*
Rules: E7-7-1-scope-nesting; E7-7-1-scope-definition; E7-7-1-inner-name-redeclaration; E7-7-1-hidden-outer-qualified-access; E7-7-2-1-hidden-entity-definition; E7-7-2-1-visible-entity-definition; E7-7-2-1-hiding-mechanisms; E7-7-2-2-nesting-hiding-sources
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Read(int item)
Into: Read(int renamed)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int item = 17;
    static int Read(int item) { return item + Program.item; }
    static int Local() { int item = 23; return item + Program.item; }
    static int Constant() { const int item = 29; return item + Program.item; }
    static void Main()
    {
        Check(Read(19) == 36, "parameter-hides-member-until-qualified");
        Check(Local() == 40, "local-variable-hides-member-until-qualified");
        Check(Constant() == 46, "local-constant-hides-member-until-qualified");
        Check(item == 17, "outer-member-visible-outside-inner-scopes");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

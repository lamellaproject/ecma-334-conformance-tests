/*
Rules: E22-5-3-3-conditional-class-definition; E22-5-3-1-conditional-classes; E22-5-3-3-conditional-class-symbols; E22-5-3-3-conditional-attribute-include; E22-5-3-3-conditional-attribute-omit
Authority: ECMA-334 7th ed 22.5.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: [System.Diagnostics.Conditional("ABSENT")] class HiddenAttribute
Into: [System.Diagnostics.Conditional("PRESENT")] class HiddenAttribute
*/
#define PRESENT
using System;
[System.Diagnostics.Conditional("ABSENT"), System.Diagnostics.Conditional("PRESENT")]
class VisibleAttribute : Attribute { }
[System.Diagnostics.Conditional("ABSENT")] class HiddenAttribute : Attribute { }
[Visible, Hidden] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Attribute.GetCustomAttribute(typeof(Item), typeof(VisibleAttribute)) != null, "conditional-attribute-included");
        Check(Attribute.GetCustomAttribute(typeof(Item), typeof(HiddenAttribute)) == null, "conditional-attribute-omitted");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

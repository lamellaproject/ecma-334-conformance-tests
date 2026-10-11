/*
Rules: E22-5-4-obsolete-marker
Authority: ECMA-334 7th ed 22.5.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: [Obsolete("retired", false)]
Into: [Obsolete("current", false)]
*/
using System;
[Obsolete("retired", false)] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ObsoleteAttribute a = (ObsoleteAttribute)Attribute.GetCustomAttribute(typeof(Item), typeof(ObsoleteAttribute));
        Check(a.Message == "retired" && !a.IsError, "obsolete-type-marker");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

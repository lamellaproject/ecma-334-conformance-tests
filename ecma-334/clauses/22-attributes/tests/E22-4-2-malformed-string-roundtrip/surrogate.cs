/*
Rules: E22-4-2-malformed-string-roundtrip
Authority: ECMA-334 7th ed 22.4.2
Version: 7.3
Expected: run
Stdout: OK 0
Mutate: [Text("\uD934")]
Into: [Text(7)]
*/
using System;
class TextAttribute : Attribute { public string Value; public TextAttribute(string value) { Value = value; } }
[Text("\uD934")] class Item { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Attribute.GetCustomAttribute(typeof(Item), typeof(TextAttribute));
        // 22.4.2 permits either equality or inequality of the retrieved malformed string.
        // This test requires retrieval to complete and imposes no value oracle.
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

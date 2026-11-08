/*
Rules: E22-4-3-ed1-named-string-value
Authority: ECMA-334 1st ed 24.3.2
Version: ISO-1
Expected: run
Stdout: OK 3
Fixture: {"target_requires":["reflection"]}
Version-Witness: version-witnesses/E22-4-3-ed1-named-string-value/property-code-unit-retention.cs.part
Mutate: [Rune(Text = "m\uD975")]
Into: [Rune(Text = "mz")]
*/
// ECMA-334 1st ed 24.3.2, p. 316 (PDF p. 330).
using System;
class RuneAttribute : Attribute
{
    string stored;
    public string Text { get { return stored; } set { stored = value; } }
}
[Rune(Text = "m\uD975")]
class Panel { }
class AttributeValue
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        RuneAttribute data = (RuneAttribute)Attribute.GetCustomAttribute(typeof(Panel), typeof(RuneAttribute));
        string value = data.Text;
        Check(value.Length == 2, "length");
        Check(value.Length > 0 && value[0] == 'm', "first-unit");
        Check(value.Length > 1 && value[1] == '\uD975', "second-unit");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

/*
Rules: E15-5-6-1-field-initializers
Authority: ECMA-334 7th ed 15.5.6.1
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public int Number = 37;
Into: public int Number;
*/
using System;
class Holder
{
    public int Number = 37;
    public string Label = "field";
    public int[] Items = { 8, 13 };
    public static bool Ready = true;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Number == 37, "expression-initializer");
        Check(value.Label == "field", "reference-initializer");
        Check(value.Items.Length == 2 && value.Items[0] == 8 && value.Items[1] == 13, "array-initializer");
        Check(Holder.Ready, "static-initializer");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

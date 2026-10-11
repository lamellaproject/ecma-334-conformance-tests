/*
Rules: E15-5-5-default-initial-field-value
Authority: ECMA-334 7th ed 15.5.5
Version: 7.3
Expected: run
Stdout: OK 6
Mutate: public object Value;
Into: public object Value = new object();
*/
using System;
class Holder
{
    public object Value;
    public string Text;
    public int[] Items;
    public static object GlobalValue;
    public static string GlobalText;
    public static int[] GlobalItems;
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder value = new Holder();
        Check(value.Value == null, "instance-object-default-null");
        Check(value.Text == null, "instance-string-default-null");
        Check(value.Items == null, "instance-array-default-null");
        Check(Holder.GlobalValue == null, "static-object-default-null");
        Check(Holder.GlobalText == null, "static-string-default-null");
        Check(Holder.GlobalItems == null, "static-array-default-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

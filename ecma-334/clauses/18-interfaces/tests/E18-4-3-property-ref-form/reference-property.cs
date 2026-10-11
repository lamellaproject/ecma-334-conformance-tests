/*
Rules: E18-4-3-property-ref-form; E18-4-3-ref-accessor-get
Authority: ECMA-334 7th ed 18.4.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: public ref int Value { get { return ref cell; } }
Into: public ref int Value { get { return ref other; } }
*/
using System;
class MarkAttribute : Attribute { }
interface ICell { [Mark] ref int Value { [Mark] get; } ref readonly int View { get; } }
class Cell : ICell
{
    int cell = 89, other = -1;
    public ref int Value { get { return ref cell; } }
    public ref readonly int View { get { return ref cell; } }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        ICell cell = new Cell();
        ref int value = ref cell.Value;
        ref readonly int view = ref cell.View;
        Check(value == 89, "reference-property-value");
        value = 97;
        Check(view == 97, "readonly-property-alias");
        Check(cell.Value == 97, "interface-ref-property-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

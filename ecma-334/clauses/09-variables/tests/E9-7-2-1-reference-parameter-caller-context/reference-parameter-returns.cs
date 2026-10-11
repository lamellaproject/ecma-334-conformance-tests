/*
Rules: E9-7-2-1-reference-parameter-caller-context; E9-7-2-1-reference-parameter-field-context; E9-7-2-1-reference-parameter-element-context; E9-7-2-1-class-parameter-field-context; E9-7-2-1-array-parameter-element-context; E9-7-2-1-caller-context-reference-return
Authority: ECMA-334 7th ed 9.7.2.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: ref int direct = ref Scalar(ref value);
Into: int direct = Scalar(ref value);
*/
using System;
struct Cell { public int Value; }
class Holder { public int Value; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static ref int Scalar(ref int value) { return ref value; }
    static ref int Field(ref Cell cell) { return ref cell.Value; }
    static ref int RefElement(ref int[] cells) { return ref cells[0]; }
    static ref int ClassField(Holder holder) { return ref holder.Value; }
    static ref int Element(int[] cells) { return ref cells[1]; }
    static void Main()
    {
        int value = 4;
        ref int direct = ref Scalar(ref value);
        direct = 36;
        Check(value == 36, "reference-parameter-caller-context");
        Cell cell = new Cell();
        Field(ref cell) = 40;
        Check(cell.Value == 40, "reference-parameter-field-caller-context");
        int[] cells = { 7, 11 };
        RefElement(ref cells) = 44;
        Check(cells[0] == 44, "reference-parameter-element-caller-context");
        Holder holder = new Holder();
        ClassField(holder) = 48;
        Check(holder.Value == 48, "class-value-parameter-field-caller-context");
        Element(cells) = 52;
        Check(cells[1] == 52, "array-value-parameter-element-caller-context");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

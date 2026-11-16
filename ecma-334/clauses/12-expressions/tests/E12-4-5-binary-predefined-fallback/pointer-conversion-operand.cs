/*
Rules: E12-4-5-binary-predefined-fallback; E23-6-7-pointer-plus-int-operator
Authority: ECMA-334 5th ed 12.4.5
Version: 5
Expected: run
Stdout: OK 3
Version-Witness: version-witnesses/E12-4-5-binary-predefined-fallback/pointer-conversion-operand.cs.part
Mutate: int* result = address + distance;
Into: int* result = (int*)address - distance;
*/
// 12.4.5, p. 117 (PDF p. 139), selects predefined candidates when the
// user-defined operator set is empty. 23.6.7, p. 420 (PDF p. 442), supplies
// pointer addition; the operand conversion makes that operator applicable.
using System;
unsafe struct Address
{
    public int* Pointer;
    public static implicit operator int*(Address address)
    {
        Program.conversions++;
        return address.Pointer;
    }
}
unsafe class Program
{
    public static int conversions;
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Offset() { return 1; }
    static int Main()
    {
        int* storage = stackalloc int[3];
        storage[0] = 7; storage[1] = 19; storage[2] = 43;
        Address address = new Address();
        address.Pointer = storage + 1;
        int distance = Offset();
        int* result = address + distance;
        Check(conversions == 1, "operand-conversion-once");
        Check(result == storage + 2, "predefined-pointer-addition-candidate");
        Check(*result == 43, "converted-operand-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

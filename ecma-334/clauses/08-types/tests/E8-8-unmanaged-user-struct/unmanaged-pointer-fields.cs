/*
Rules: E8-8-unmanaged-user-struct; E8-8-unmanaged-form-pointer
Authority: ECMA-334 7th ed 8.8
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: state.Value = 52;
Into: state.Value = 53;
*/
using System;
unsafe struct State { public int Value; public int* Address; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe int Read() { State state = new State(); state.Value = 52; int* pointer = &state.Value; int** indirect = &pointer; state.Address = *indirect; return *state.Address; }
    static void Main()
    {
        Check(Read() == 52, "unmanaged-struct-and-pointer-instance-fields");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

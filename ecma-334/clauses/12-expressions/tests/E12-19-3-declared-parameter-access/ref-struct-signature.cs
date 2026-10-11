/*
Rules: E12-19-3-declared-parameter-access; E12-19-3-no-outer-ref-struct-parameter
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: (Frame value) => value.Value
Into: (Frame value) => 0
*/
using System;
ref struct Frame { public int Value; }
delegate int Read(Frame frame);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Read function = (Frame value) => value.Value;
        Frame argument = new Frame();
        argument.Value = 37;
        Check(function(argument) == 37, "nearest-signature-allows-ref-struct-parameter-access");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

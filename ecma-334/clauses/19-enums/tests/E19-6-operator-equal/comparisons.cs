/*
Rules: E19-6-operator-equal; E19-6-operator-not-equal; E19-6-operator-less; E19-6-operator-greater; E19-6-operator-less-equal; E19-6-operator-greater-equal
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 12
Mutate: Code.Low == equal
Into: Code.Low != equal
*/
using System;
enum Code : uint { Low = 1, High = 0x80000000U }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code equal = (Code)1;
        Check(Code.Low == equal, "equal-true");
        Check(!(Code.Low == Code.High), "equal-false");
        Check(Code.Low != Code.High, "not-equal-true");
        Check(!(Code.Low != equal), "not-equal-false");
        Check(Code.Low < Code.High, "unsigned-less-true");
        Check(!(Code.Low < equal), "less-false-on-equality");
        Check(Code.High > Code.Low, "unsigned-greater-true");
        Check(!(Code.Low > equal), "greater-false-on-equality");
        Check(Code.Low <= equal, "less-equal-includes-equality");
        Check(!(Code.High <= Code.Low), "less-equal-false");
        Check(Code.Low >= equal, "greater-equal-includes-equality");
        Check(!(Code.Low >= Code.High), "greater-equal-false");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

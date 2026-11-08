/*
Rules: E10-5-3-encompassed-expression
Authority: ECMA-334 7th ed 10.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Parcel result = 53;
Into: Parcel result = default(Parcel);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Parcel
    {
        public int Number;
        public Parcel(int number) { Number = number; }
        public static implicit operator Parcel(byte value) { return new Parcel(value); }
    }
    static int Main()
    {
        Parcel result = 53;
        Check(result.Number == 53, "constant-byte-operator-input");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

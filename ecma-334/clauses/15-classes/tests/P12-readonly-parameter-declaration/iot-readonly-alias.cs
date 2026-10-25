/*
Rules: P12-readonly-parameter-declaration; P12-readonly-argument-ref; P12-readonly-argument-in; E12-6-2-3-by-reference-location
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 8
Mutate: int afterIn = Observe(in cell, ref cell);
Into: int afterIn = Observe(in other, ref cell);
*/
using System;
class Token { }
class Test
{
    static int checks, failures;
    static readonly int fixedValue = 37;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Observe(ref readonly int read, ref int write) { write += 7; return read; }
    static T Replace<T>(ref readonly T read, ref T write, T replacement) { write = replacement; return read; }
    static ref readonly int Escape(ref readonly int value) { return ref value; }
    static int Read(ref readonly int value) { return value; }
    static int Main()
    {
        int cell = 11;
        int other = 11;
        int afterIn = Observe(in cell, ref cell);
        Check(afterIn == 18, "in-reference-observes-alias-update");
        Check(cell == 18, "in-call-caller-storage");
        int afterRef = Observe(ref cell, ref cell);
        Check(afterRef == 25, "ref-reference-observes-alias-update");
        Check(cell == 25, "ref-call-caller-storage");
        ref readonly int escaped = ref Escape(in cell);
        cell = 41;
        Check(escaped == 41, "returned-readonly-reference-keeps-location");
        Token original = new Token();
        Token replacement = new Token();
        Token observed = Replace(in original, ref original, replacement);
        Check(object.ReferenceEquals(observed, replacement), "generic-reference-alias-read");
        Check(object.ReferenceEquals(original, replacement), "generic-caller-storage");
        Check(Read(in fixedValue) == 37, "readonly-field-in-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

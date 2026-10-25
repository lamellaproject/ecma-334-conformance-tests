/*
Rules: E10-3-2-ed1-unchecked-widening-zero-extension
Authority: ECMA-334 1st ed 13.2.1
Version: ISO-1
Expected: run
Stdout: OK 4
Diagnostic: none
Mutate: uint wide = 4026531841U;
Into: uint wide = 0U;
*/
// ECMA-334 1st ed 13.2.1, p. 116 (PDF p. 130), lines 26-29 also covers zero-extension in
// cast expressions admitted by implicit numeric conversion.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    public static int Main()
    {
        byte narrow = 241;
        ushort middle = 65403;
        uint wide = 4026531841U;
        char character = (char)65241;
        Check(unchecked((ushort)narrow) == 241, "byte-ushort");
        Check(unchecked((uint)middle) == 65403U, "ushort-uint");
        Check(unchecked((ulong)wide) == 4026531841UL, "uint-ulong");
        Check(unchecked((uint)character) == 65241U, "char-uint");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

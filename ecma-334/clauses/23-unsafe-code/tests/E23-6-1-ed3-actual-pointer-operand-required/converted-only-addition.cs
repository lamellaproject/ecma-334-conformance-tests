/*
Rules: E23-6-1-ed3-actual-pointer-operand-required
Authority: ECMA-334 3rd ed 27.5
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E23-6-1-ed3-actual-pointer-operand-required/converted-only-addition.cs.part
Mutate: token + 0
Into: (int*)token + 0
*/
// ECMA-334 3rd ed 27.5, p. 424 (PDF p. 444).
using System;
unsafe struct PointerToken
{
    public static implicit operator int*(PointerToken value) { return null; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        unsafe
        {
            PointerToken token = new PointerToken();
            int* result = token + 0;
            Check(result == null, "pointer");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

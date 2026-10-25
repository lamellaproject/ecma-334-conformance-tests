/*
Rules: E18-2-2-ed1-new-nested-struct-interface
Authority: ECMA-334 1st ed 20.1.1
Version: ISO-1
Expected: run
Stdout: OK 1
Diagnostic: warning
Mutate: public new interface Token
Into: public interface Token
*/
// ECMA-334 1st ed 20.1.1, p. 283 (PDF p. 297), line 28 permits new on a nested interface.
// The 1st edition's 17.2.6 includes struct containers; the 1st edition's 17.2.2 requires a
// warning here. Removing new toggles that warning; no particular warning code is required.
using System;
struct Frame
{
    public new interface Token { int Read(); }
}
class Reader : Frame.Token
{
    public int Read() { return 43; }
}
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    public static int Main()
    {
        Frame.Token token = new Reader();
        Check(token.Read() == 43, "nested-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

/*
Rules: E13-8-3-switch-local-variable-scope; E13-8-3-switch-local-constant-scope; E13-8-3-section-declarations
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: answer = token + offset;
Into: answer = token;
*/
using System;
class Program
{
    static int checks, failures, token = 31;
    const int offset = 17;
    static void Check(bool condition, string label)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + label); }
    }
    static int Main()
    {
        int selector = 2, answer = 0;
        switch (selector)
        {
            case 2:
                int token = 13;
                const int offset = 5;
                goto case 4;
            case 4:
                token = 13;
                answer = token + offset;
                Check(token == 13, "local-visible-in-other-section");
                Check(offset == 5, "constant-visible-in-other-section");
                break;
        }
        Check(answer == 18, "cross-section-values-contribute-to-result");
        Check(Program.token == 31 && Program.offset == 17, "qualified-fields-outside-switch");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

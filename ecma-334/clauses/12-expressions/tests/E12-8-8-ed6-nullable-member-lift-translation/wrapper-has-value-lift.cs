/*
Rules: E12-8-8-ed6-nullable-member-lift-translation
Authority: ECMA-334 6th ed 11.7.7
Version: 6
Expected: run
Stdout: OK 4
Version-Witness: tests/E12-8-8-ed6-nullable-member-lift-translation/wrapper-has-value-lift.witness.cs.part
Mutate: if (present) return new Token();
Into: if (present) return null;
*/
using System;

struct Token
{
    public static int GetterCalls;
    public bool HasValue { get { GetterCalls++; return false; } }
}

class Program
{
    static int reads;
    static Token? Read(bool present)
    {
        reads++;
        if (present) return new Token();
        return null;
    }

    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        bool? present = Read(true)?.HasValue;
        bool? absent = Read(false)?.HasValue;
        Check(present == true, "present-wrapper-has-value");
        Check(!absent.HasValue, "absent-lifted-result");
        Check(reads == 2, "receiver-evaluated-once-per-access");
        Check(Token.GetterCalls == 0, "underlying-getter-unused");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

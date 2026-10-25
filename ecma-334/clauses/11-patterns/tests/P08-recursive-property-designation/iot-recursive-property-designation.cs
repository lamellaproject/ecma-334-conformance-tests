/*
Rules: P08-recursive-property-designation
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: Message { Code: 23 } found
Into: Message { Code: 24 } found
*/
using System;

class Message { public int Code; }
class Program
{
    static int checks, failures, calls;
    static object source;
    static object Take() { calls++; return source; }
    static bool Matches(Message expected)
    {
        if (Take() is Message { Code: 23 } found)
        {
            Message typed = found;
            return ReferenceEquals(typed, expected);
        }
        return false;
    }
    static void Check(bool pass, string name)
    {
        checks++;
        if (!pass) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Message message = new Message { Code = 23 };
        source = message; calls = 0;
        Check(Matches(message) && calls == 1, "designation-typed-identity");
        source = new object(); calls = 0;
        Check(!Matches(message) && calls == 1, "runtime-type-mismatch");
        source = null; calls = 0;
        Check(!Matches(message) && calls == 1, "typed-null");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

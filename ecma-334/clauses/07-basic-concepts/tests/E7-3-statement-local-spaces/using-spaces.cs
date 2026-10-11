/*
Rules: E7-3-statement-local-spaces; E7-3-disjoint-local-name-reuse
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using (Token value = new Token(23))
Into: using (Token sum = new Token(23))
*/
using System;
class Token : IDisposable
{
    public static int Disposals;
    public int Number;
    public Token(int number) { Number = number; }
    public void Dispose() { Disposals++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int sum = 0;
        using (Token value = new Token(17)) sum += value.Number;
        using (Token value = new Token(23)) sum += value.Number;
        Check(sum == 40, "independent-using-spaces");
        Check(Token.Disposals == 2, "both-using-statements-completed");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

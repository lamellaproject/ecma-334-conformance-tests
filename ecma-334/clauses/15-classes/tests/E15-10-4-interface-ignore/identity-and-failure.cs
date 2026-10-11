/*
Rules: E15-10-4-interface-ignore; E15-10-4-conversion-no-interface-transform; E15-10-4-conversion-interface-success-condition
Authority: ECMA-334 7th ed 15.10.4
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: IToken result = (IToken)source;
Into: IToken result = (Token)source;
*/
using System;
interface IToken { int Read(); }
class Token : IToken { public int Read() { return 19; } }
class Gauge<T> { public T Value; public static implicit operator T(Gauge<T> x) { Program.Calls++; return x.Value; } }
class Implementer : Gauge<IToken>, IToken { public int Read() { return 13; } }
class Program
{
    static int checks, failures;
    public static int Calls;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Gauge<IToken> source = new Implementer();
        source.Value = new Token();
        IToken result = (IToken)source;
        Check(object.ReferenceEquals(result, source), "interface-conversion-identity");
        Check(result.Read() == 13 && Calls == 0, "interface-conversion-no-transformation");
        Gauge<IToken> plain = new Gauge<IToken>();
        plain.Value = new Token();
        bool invalid = false;
        try { IToken unused = (IToken)plain; }
        catch (InvalidCastException) { invalid = true; }
        catch (Exception) { }
        Check(invalid, "interface-conversion-needs-implementation");
        Check(Calls == 0, "interface-conversion-failure-no-transformation");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

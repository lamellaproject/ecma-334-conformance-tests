/*
Rules: E16-2-1-declaration; E16-2-1-form; E16-2-1-name; E16-2-1-generic-parameters; E16-2-2-modifier-public; E16-3-member-constructor; E16-4-9-parameterized
Authority: ECMA-334 7th ed 16.2.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: where T : class
Into: where T : struct
*/
using System;
class MarkAttribute : Attribute { }
interface ILabel { }
[Mark] public struct Envelope<T> : ILabel where T : class
{
    public readonly T Payload;
    public Envelope(T value) { Payload = value; }
};
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        string input = new string(new char[] { 'm', 'a', 'p' });
        Envelope<string> item = new Envelope<string>(input);
        Check(item.Payload == input, "generic-constructor-value");
        ILabel contract = item;
        Check(contract != null, "declared-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

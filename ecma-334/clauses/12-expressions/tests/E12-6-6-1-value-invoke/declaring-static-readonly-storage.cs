/*
Rules: E12-6-6-1-value-invoke; E12-6-6-1-value-mutation-observable
Authority: ECMA-334 5th ed 12.6.6.1
Version: 5
Expected: run
Stdout: OK 2
Mutate: balance.Increase(6);
Into: Tally temporary = balance; temporary.Increase(6);
*/
using System;
struct Tally
{
    public int Value;
    public Tally(int value) { Value = value; }
    public void Increase(int amount) { Value += amount; }
}
class Bank
{
    static readonly Tally balance;
    public static readonly int Initial;
    static Bank()
    {
        balance = new Tally(11);
        Initial = balance.Value;
        balance.Increase(6);
    }
    public static int Value { get { return balance.Value; } }
}
class Program
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        Check(Bank.Initial == 11, "field-value-before-method-call");
        Check(Bank.Value == 17, "constructor-method-writes-static-field");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

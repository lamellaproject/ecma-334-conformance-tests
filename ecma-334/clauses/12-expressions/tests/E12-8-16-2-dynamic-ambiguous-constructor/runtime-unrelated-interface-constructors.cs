/*
Rules: E12-8-16-2-dynamic-ambiguous-constructor
Authority: ECMA-334 7th ed 12.8.16.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: new Choice(argument)
Into: new Choice((ILeft)argument)
*/
using System;
public interface ILeft { }
public interface IRight { }
public class Both : ILeft, IRight { }
public class Choice
{
    public static int Bodies;
    public Choice(ILeft left) { Bodies++; }
    public Choice(IRight right) { Bodies++; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic argument = new Both();
        bool error = false;
        try { var value = new Choice(argument); }
        catch (Exception) { error = true; }
        Check(error, "runtime-constructor-ambiguity");
        Check(Choice.Bodies == 0, "ambiguous-constructor-body-not-entered");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

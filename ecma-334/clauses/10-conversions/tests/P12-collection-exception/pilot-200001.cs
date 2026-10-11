/*
Rules: P12-collection-exception
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 2
Mutate: int[] values=[Events.Read(173),Events.Fail(),Events.Read(179)];
Into: int[] values=default(int[]);
*/
using System;

static class Events{public static string Log="";public static int Read(int n){Log+=n+";";return n;}public static int Fail()=>throw new InvalidOperationException();}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        try { int[] values=[Events.Read(173),Events.Fail(),Events.Read(179)];Check(false, "P12-collection-exception-pilot-200001-check-01"); } catch (InvalidOperationException) { Check(true, "P12-collection-exception-pilot-200001-check-01"); } catch (Exception error) { Check(false, "P12-collection-exception-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); } Check(Events.Log=="173;", "P12-collection-exception-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E10-8-instance-exception
Authority: ECMA-334 7th ed 10.8
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Action converted=Trace.Fail().Touch;
Into: Action converted=default(Action);
*/
using System;


class Receiver {public void Touch(){}}
static class Trace {public static int Calls;public static Receiver Fail(){Calls++;throw new InvalidOperationException("receiver");}}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        try { Action converted=Trace.Fail().Touch; Check(false, "E10-8-instance-exception-pilot-001-check-01"); } catch(InvalidOperationException e) {Check(e.Message=="receiver", "E10-8-instance-exception-pilot-001-check-02");} catch (Exception error) { Check(false, "E10-8-instance-exception-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        Check(Trace.Calls==1, "E10-8-instance-exception-pilot-001-check-03");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

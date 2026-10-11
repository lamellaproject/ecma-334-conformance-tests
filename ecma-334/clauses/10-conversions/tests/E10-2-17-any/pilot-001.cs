/*
Rules: E10-2-17-any; E10-2-1-categories
Authority: ECMA-334 7th ed 10.2.17
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: string other=!pick ? throw new InvalidOperationException("branch") : "unused";
Into: string other="unused";
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool pick=false;
        int result=pick ? throw new InvalidOperationException("branch") : 61;
        Check(result==61, "E10-2-17-any-pilot-001-check-01");
        try { string other=!pick ? throw new InvalidOperationException("branch") : "unused"; Check(false, "E10-2-17-any-pilot-001-check-02"); }
        catch (InvalidOperationException e) { Check(e.Message=="branch", "E10-2-17-any-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-2-17-any-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

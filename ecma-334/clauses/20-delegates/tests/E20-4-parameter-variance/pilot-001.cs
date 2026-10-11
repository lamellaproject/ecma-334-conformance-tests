/*
Rules: E20-4-parameter-variance; E20-4-return-variance; E20-4-void
Authority: ECMA-334 7th ed 20.4
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Func<string,object> converted=Bridge.Copy;
Into: Func<string,object> converted=default(Func<string,object>);
*/
using System;

static class Bridge {public static object Last;public static string Copy(object x){return (string)x;} public static void Save(object x){Last=x;} }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Func<string,object> converted=Bridge.Copy; Action<string> voidValue=Bridge.Save;
        object copied=converted("seed"); voidValue("leaf");
        Check(copied.Equals("seed") && Bridge.Last.Equals("leaf"), "E20-4-parameter-variance-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

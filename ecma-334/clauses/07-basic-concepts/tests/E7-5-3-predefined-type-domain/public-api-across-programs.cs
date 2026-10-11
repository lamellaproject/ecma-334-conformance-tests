/*
Rules: E7-5-3-predefined-type-domain
Authority: ECMA-334 7th ed 7.5.3
Version: 7.3
Expected: run
Stdout: OK 3
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: public static int Number = 131;
Into: public static Narrow Number = null;
*/
using System;
#if LIBRARY
public class Api
{
    private class Narrow { }
    public static int Number = 131;
    public static double Read() { return 3.5; }
    public static object Echo(object value) { return value; }
}
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object token = new object();
        Check(Api.Number == 131, "public-int-type-across-programs");
        Check(Api.Read() == 3.5, "public-double-type-across-programs");
        Check(Api.Echo(token) == token, "public-object-type-across-programs");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif

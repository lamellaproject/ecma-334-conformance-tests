/*
Rules: E7-8-1-name-form-alias; E7-8-1-alias-resolution; E7-8-1-qualified-prefix-resolution
Authority: ECMA-334 7th ed 7.8.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: using Route = East;
Into: using Route = West;
*/
using System;
using Route = East;
namespace East { class Token { public int Value = 41; } }
namespace West { class Token { public int Value = 43; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Route::Token aliased = new Route::Token();
        Route.Token dotted = new Route.Token();
        Check(aliased.Value == 41, "qualified-alias-member-form");
        Check(dotted.Value == 41, "namespace-alias-as-prefix");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

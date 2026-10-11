/*
Rules: E14-8-1-alias-scope-search-order
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: using Scope = InnerChoice;
Into: using Scope = MiddleChoice;
*/
using System;
using Scope = OuterChoice;
namespace OuterChoice { class Beacon { public const int Code = 29; } }
namespace MiddleChoice { class Beacon { public const int Code = 31; } }
namespace InnerChoice { class Beacon { public const int Code = 37; } }
namespace Home { using Scope = MiddleChoice; class Reader { public static int Read() { return Scope::Beacon.Code; } } namespace Nested { using Scope = InnerChoice; class Reader { public static int Read() { return Scope::Beacon.Code; } } } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Scope::Beacon.Code == 29, "compilation-unit-alias");
        Check(Home.Reader.Read() == 31, "enclosing-namespace-alias");
        Check(Home.Nested.Reader.Read() == 37, "nearest-namespace-alias");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E14-3-qualified-nested-namespace; E14-3-grammar-namespace-declaration-1; E14-3-grammar-qualified-identifier-1; E14-3-grammar-namespace-body-1; E14-3-top-level-namespace; E14-3-nested-namespace; E14-3-namespace-public; E14-3-namespace-member-contribution; E14-3-open-namespace; E14-6-grammar-namespace-member-declaration-1; E14-6-namespace-member-declaration
Authority: ECMA-334 7th ed 14.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: namespace Harbor.Inner { public class Second
Into: namespace Harbor.Other { public class Second
*/
using System;
namespace Harbor { namespace Inner { public class First { public const int Code = 29; } } }
namespace Harbor.Inner { public class Second { public const int Code = 31; } };
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Harbor.Inner.First.Code == 29, "lexically-nested-member");
        Check(Harbor.Inner.Second.Code == 31, "qualified-open-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

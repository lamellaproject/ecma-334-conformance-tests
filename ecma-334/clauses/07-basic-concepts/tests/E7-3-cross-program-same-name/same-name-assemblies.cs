/*
Rules: E7-3-cross-program-same-name; E7-3-extern-alias-declaration
Authority: ECMA-334 7th ed 7.3
Version: 7.3
Expected: run
Stdout: OK 2
Fixture: {"libraries":[{"name":"One","units":[{"defines":["FIRST"],"source":"self"}]},{"name":"Two","units":[{"defines":["SECOND"],"source":"self"}]}],"program":{"references":[{"alias":"Left","library":"One"},{"alias":"Right","library":"Two"}]}}
Mutate: public static int Read() { return 17; }
Into: public static int Read() { return 23; }
*/
#if !FIRST && !SECOND
extern alias Left;
extern alias Right;
#endif
using System;
#if FIRST
namespace Shared { public class Item { public static int Read() { return 17; } } }
#elif SECOND
namespace Shared { public class Item { public static int Read() { return 23; } } }
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Left::Shared.Item.Read() == 17, "first-program-same-name");
        Check(Right::Shared.Item.Read() == 23, "second-program-same-name");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif

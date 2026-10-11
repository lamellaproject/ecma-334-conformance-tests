/*
Rules: E7-5-2-interface-member-public
Authority: ECMA-334 7th ed 7.5.2
Version: 7.3
Expected: run
Stdout: OK 1
Fixture: {"libraries":[{"name":"Fixture","units":[{"defines":["LIBRARY"],"source":"self"}]}],"program":{"references":[{"library":"Fixture"}]}}
Mutate: int Read();
Into: private int Read();
*/
using System;
#if LIBRARY
public interface IItem { int Read(); }
public class Item : IItem { int IItem.Read() { return 149; } }
#else
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IItem value = new Item();
        Check(value.Read() == 149, "implicit-public-interface-member-across-programs");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}
#endif

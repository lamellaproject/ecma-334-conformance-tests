/*
Rules: E16-3-member-property; E16-4-11-backing-field
Authority: ECMA-334 7th ed 16.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public int Value { get; set; }
Into: public int Value { get { return 0; } set { } }
*/
using System;
struct Entry { public int Value { get; set; } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Entry first = new Entry(); Entry second = new Entry();
        first.Value = 91; second.Value = 26;
        Check(first.Value == 91, "first-property-storage");
        Check(second.Value == 26, "second-property-storage");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

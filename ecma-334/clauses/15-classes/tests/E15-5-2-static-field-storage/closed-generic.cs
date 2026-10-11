/*
Rules: E15-5-2-static-field-storage
Authority: ECMA-334 7th ed 15.5.2
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: public static int Code;
Into: public int Code;
*/
using System;
class Holder<T>
{
    public static int Code;
    public void Store(int code) { Code = code; }
    public int Read() { return Code; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Holder<int> first = new Holder<int>(), second = new Holder<int>();
        Holder<string> other = new Holder<string>();
        first.Store(1061);
        other.Store(1063);
        Check(second.Read() == 1061, "same-closed-type-static-storage-shared");
        Check(other.Read() == 1063, "different-closed-type-static-storage-distinct");
        second.Store(1069);
        Check(first.Read() == 1069, "same-closed-type-static-update-shared");
        Check(other.Read() == 1063, "other-closed-type-static-update-isolated");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E15-3-1-class-declaration-space; E15-3-1-parameter-and-member-names
Authority: ECMA-334 7th ed 15.3.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public T Echo(T value) { return value; }
Into: public object Echo(object value) { return value; }
*/
using System;
class Alpha<T>
{
    public int Number = 181;
    public T Echo(T value) { return value; }
}
class Beta<T> { public int Number = 191; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Alpha<int> first = new Alpha<int>();
        int echoed = first.Echo(193);
        Check(echoed == 193, "type-parameter-name-in-member-declaration");
        Check(first.Number == 181 && new Beta<int>().Number == 191, "separate-class-member-spaces");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

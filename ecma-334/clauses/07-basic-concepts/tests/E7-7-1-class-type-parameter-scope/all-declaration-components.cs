/*
Rules: E7-7-1-class-type-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: class Carrier<T>
Into: class Carrier<U>
*/
using System;
class Root<T> { }
class Carrier<T> : Root<T> where T : class
{
    T value;
    public Carrier(T value) { this.value = value; }
    public T Read() { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(new Carrier<string>("cedar").Read() == "cedar", "type-parameter-in-base-constraint-and-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

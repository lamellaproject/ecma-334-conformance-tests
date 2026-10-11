/*
Rules: E7-7-1-struct-type-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: struct Carrier<T>
Into: struct Carrier<U>
*/
using System;
interface IRead<T> { T Read(); }
struct Carrier<T> : IRead<T> where T : struct
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
        IRead<int> value = new Carrier<int>(59);
        Check(value.Read() == 59, "type-parameter-in-interfaces-constraint-and-body");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

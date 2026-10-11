/*
Rules: E8-4-1-nested-implicit-constructed-type
Authority: ECMA-334 7th ed 8.4.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: return value;
Into: return default(T);
*/
using System;
class Outer<T> { public class Inner { T value; public Inner(T input) { value = input; } public T Read() { return value; } } public Inner Make(T input) { return new Inner(input); } }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Outer<int>.Inner inner = new Outer<int>().Make(57);
        Check(inner.Read() == 57, "nested-type-binds-enclosing-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E7-7-1-interface-type-parameter-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: interface IRead<T, U>
Into: interface IRead<V, U>
*/
using System;
interface IParent<T> { T Echo(T value); }
interface IRead<T, U> : IParent<T> where T : U { T Read(U value); }
class Item : IRead<int, int>
{
    public int Echo(int value) { return value; }
    public int Read(int value) { return value + 1; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IRead<int, int> value = new Item();
        Check(value.Read(61) == 62, "type-parameters-in-constraint-and-member-signature");
        Check(value.Echo(67) == 67, "type-parameter-in-base-interface");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

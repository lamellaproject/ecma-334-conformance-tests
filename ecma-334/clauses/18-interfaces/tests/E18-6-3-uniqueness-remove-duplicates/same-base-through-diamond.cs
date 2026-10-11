/*
Rules: E18-6-3-uniqueness-remove-duplicates
Authority: ECMA-334 7th ed 18.6.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: interface IRight<T> : IRoot<T>
Into: interface IRight<T> : IRoot<int>
*/
using System;
interface IRoot<T> { }
interface ILeft<T> : IRoot<T> { }
interface IRight<T> : IRoot<T> { }
interface IBoth<T> : ILeft<T>, IRight<T> { }
class Both<T> : IBoth<T> { }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        IBoth<string> value = new Both<string>();
        IRoot<string> root = value;
        Check(root == value, "duplicate-base-removed-before-unification");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

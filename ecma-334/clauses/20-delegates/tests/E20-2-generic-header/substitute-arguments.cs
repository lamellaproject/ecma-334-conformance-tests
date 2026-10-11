/*
Rules: E20-2-generic-header; E20-2-generic-own-parameters; E20-2-own-type-parameters; E20-2-constructed-parameter-types; E20-2-constructed-return-type
Authority: ECMA-334 7th ed 20.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: delegate TResult Select<in TInput, out TResult>(TInput value) where TResult : class;
Into: delegate TInput Select<TInput, TResult>(TInput value) where TResult : class;
*/
using System;
delegate TResult Select<in TInput, out TResult>(TInput value) where TResult : class;
class Program
{
    static int checks, failures;
    static int saved;
    static string Read(int value) { saved = value; return "birch"; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Select<int, string> reader = Read;
        string result = reader(23);
        Check(result == "birch", "constructed-result-type");
        Check(saved == 23, "constructed-parameter-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

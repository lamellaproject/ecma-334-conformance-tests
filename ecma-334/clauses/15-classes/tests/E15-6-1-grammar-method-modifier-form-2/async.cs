/*
Rules: E15-6-1-grammar-method-modifier-form-2
Authority: ECMA-334 7th ed 15.6.1
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public static async Task<int> Read()
Into: public static Task<int> Read()
*/
using System;
using System.Threading.Tasks;
class Holder
{
    public static int Calls;
    public static async Task<int> Read() { Calls++; return await Task.FromResult(59); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int value = Holder.Read().GetAwaiter().GetResult();
        Check(value == 59, "async-method-task-result");
        Check(Holder.Calls == 1, "async-method-body-executed-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E12-19-1-async-function; E12-19-1-lambda-form; E12-19-1-anonymous-method-form
Authority: ECMA-334 7th ed 12.19.1
Version: 7.3
Expected: run
Stdout: OK 5
Mutate: async (int value) =>
Into: (int value) =>
*/
using System;
using System.Threading.Tasks;
delegate Task<int> Work(int value);
class Program
{
    static string trace = "";
    static InvalidOperationException fault = new InvalidOperationException();
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Work lambda = async (int value) => { trace += "L"; if (value == 0) throw fault; return value + 7; };
        Work method = async delegate(int value) { trace += "D"; return value + 11; };
        Check(lambda(13).GetAwaiter().GetResult() == 20, "async-lambda-returns-task-result");
        Check(method(13).GetAwaiter().GetResult() == 24, "async-method-returns-task-result");
        Check(trace == "LD", "async-bodies-execute-on-invocation");
        trace = "";
        Task<int> pending = null;
        bool returned = false, caught = false, same = false, other = false;
        try { pending = lambda(0); returned = true; pending.GetAwaiter().GetResult(); }
        catch (InvalidOperationException error) { caught = true; same = object.ReferenceEquals(error, fault); }
        catch (Exception) { other = true; }
        Check(returned && pending != null, "async-exception-is-stored-in-returned-task");
        Check(caught && same && !other && trace == "L", "awaiter-rethrows-original-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

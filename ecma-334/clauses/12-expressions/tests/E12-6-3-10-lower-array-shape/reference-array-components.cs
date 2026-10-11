/*
Rules: E12-6-3-10-lower-array-shape; E12-6-3-10-lower-array-component
Authority: ECMA-334 7th ed 12.6.3.10
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Common(new string[,] { { "a" } }, new object[,] { { token } })
Into: Common(new string[,] { { "a" } }, new string[,] { { "b" } })
*/
using System;
class Result<T> { public T value; }
class Program
{
    static int checks, failures;
    static Result<T> Common<T>(T[,] left, T[,] right) { return new Result<T> { value = right[0, 0] }; }
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object token = new object();
        Result<object> result = Common(new string[,] { { "a" } }, new object[,] { { token } });
        Check(object.ReferenceEquals(result.value, token), "equal-rank-reference-array-elements-infer-common-object");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

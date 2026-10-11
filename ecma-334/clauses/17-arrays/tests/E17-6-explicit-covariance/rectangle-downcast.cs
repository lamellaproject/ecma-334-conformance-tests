/*
Rules: E17-6-explicit-covariance; E17-6-implicit-covariance; E17-6-covariant-instance
Authority: ECMA-334 7th ed 17.6
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: (string[,])erased
Into: erased
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string[,] values = new string[1, 2];
        object[,] erased = values;
        string[,] restored = (string[,])erased;
        Check(restored == values, "same-rank-downcast-identity");
        Check(erased is string[,], "rectangle-actual-type");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

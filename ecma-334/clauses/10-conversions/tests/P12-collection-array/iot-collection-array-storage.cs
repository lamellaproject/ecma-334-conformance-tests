/*
Rules: P12-collection-array; E12-8-16-5-array-instance; E12-8-16-5-array-reference
Authority: csc 5.11.0-1.26425.128 (C# 12.0)
Version: 12.0
Expected: run
Stdout: OK 4
Mutate: object[] second = [item];
Into: object[] second = first;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        object item = new object();
        object[] first = [item];
        object[] second = [item];
        Check(first.Length == 1 && second.Length == 1, "known-length-arrays");
        Check(!object.ReferenceEquals(first, second), "nonempty-distinct-array-storage");
        Check(object.ReferenceEquals(first[0], item) && object.ReferenceEquals(second[0], item), "reference-element-identity");
        first[0] = new object();
        Check(object.ReferenceEquals(second[0], item), "array-write-isolated");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

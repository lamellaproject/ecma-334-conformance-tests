/*
Rules: E15-3-3-semantic-substitution
Authority: ECMA-334 7th ed 15.3.3
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: public T Echo<T>(T value) { return value; }
Into: public T Echo<U>(T value) { return value; }
*/
using System;
class Bucket<T>
{
    public T Read(T value) { return value; }
    public T Echo<T>(T value) { return value; }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Bucket<int> value = new Bucket<int>();
        int number = value.Read(269);
        string text = value.Echo<string>("inner");
        Check(number == 269, "outer-parameter-substituted");
        Check(text == "inner", "method-parameter-shadows-same-spelled-class-parameter");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

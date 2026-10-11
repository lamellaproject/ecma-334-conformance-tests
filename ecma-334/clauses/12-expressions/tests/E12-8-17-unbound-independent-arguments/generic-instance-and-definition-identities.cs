/*
Rules: E12-8-17-unbound-independent-arguments; E12-8-17-constructed-operand; E12-8-17-unbound-generic-operand; E12-8-17-unbound-instance-distinction; E12-8-17-instance-closed-type; E12-8-17-instance-runtime-arguments; E12-8-17-unbound-no-arguments
Authority: ECMA-334 7th ed 12.8.17
Version: 7.3
Expected: run
Stdout: OK 7
Mutate: static Type Definition() { return typeof(Family<>); }
Into: static Type Definition() { return typeof(Family<T>); }
*/
using System;
class Family<T>
{
    public static Type Instance() { return typeof(Family<T>); }
    public static Type Definition() { return typeof(Family<>); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Type integer = Family<int>.Instance();
        Type text = Family<string>.Instance();
        Type open = Family<int>.Definition();
        Check(integer == typeof(Family<int>), "instance-type-bound-int-argument");
        Check(text == typeof(Family<string>), "instance-type-bound-string-argument");
        Check(integer != text, "instance-type-depends-on-runtime-arguments");
        Check(object.ReferenceEquals(open, Family<string>.Definition()), "unbound-type-independent-of-runtime-arguments");
        Check(open != integer && open != text, "unbound-type-distinct-from-instances");
        Check(!integer.ContainsGenericParameters && !text.ContainsGenericParameters, "runtime-instance-types-closed");
        Type[] parameters = open.GetGenericArguments();
        Check(open.IsGenericTypeDefinition && parameters.Length == 1 && parameters[0].IsGenericParameter, "unbound-type-has-parameters-without-arguments");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

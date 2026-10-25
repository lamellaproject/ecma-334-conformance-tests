/*
Rules: P10-natural-action; P10-natural-lambda; P10-natural-var; E10-7-2-capture
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 5
Mutate: var adjust = (Parcel item) =>
Into: var adjust = (object item) =>
*/
using System;
class Parcel { public int Value; }
class Program
{
    static int checks, failures;
    static bool IsParcelAction<T>(T action) { return typeof(T) == typeof(Action<Parcel>); }
    static void Check(bool value, string name)
    {
        checks++;
        if (!value) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int Main()
    {
        int offset = 7, calls = 0;
        var adjust = (Parcel item) =>
        {
            Parcel value = (Parcel)item;
            calls++;
            value.Value += offset;
        };
        Action<Parcel> typed = adjust;
        Parcel parcel = new Parcel();
        Check(IsParcelAction(adjust), "natural-action-type");
        Check(calls == 0 && parcel.Value == 0, "creation-defers-body");
        offset = 11;
        adjust(parcel);
        Check(calls == 1 && parcel.Value == 11, "natural-invoke-captures-current-local");
        typed(parcel);
        Check(calls == 2 && parcel.Value == 22, "typed-alias-invokes-same-capture");
        Check(Object.ReferenceEquals(adjust, typed), "delegate-assignment-identity");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

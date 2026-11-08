/*
Rules: E10-5-3-pre; E10-4-2-categories; E10-6-1-wrap; E10-5-4-pre; E10-5-5-pre
Authority: ECMA-334 7th ed 10.5.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: result.Value = value;
Into: result.Value = null;
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    static int calls;
    struct Stamp
    {
        public int Mark;
        public Stamp(int value) { Mark = value; }
    }
    struct Bundle<T> where T : struct
    {
        public T? Value;
        public static implicit operator Bundle<T>(Nullable<T> value)
        {
            calls++;
            Bundle<T> result = new Bundle<T>();
            result.Value = value;
            return result;
        }
    }
    static Bundle<T> Assign<T>(T value) where T : struct
    {
        Bundle<T> result = value;
        return result;
    }
    static Bundle<T> Cast<T>(T value) where T : struct { return (Bundle<T>)value; }
    static int Main()
    {
        Bundle<int> first = Assign<int>(29);
        Check(first.Value.HasValue && first.Value.Value == 29 && calls == 1, "parameter-nullable-prefix-assignment");
        Bundle<int> second = Cast<int>(31);
        Check(second.Value.HasValue && second.Value.Value == 31 && calls == 2, "parameter-nullable-prefix-cast");
        Bundle<Stamp> third = Assign<Stamp>(new Stamp(43));
        Check(third.Value.HasValue && third.Value.Value.Mark == 43 && calls == 3, "user-value-nullable-prefix-assignment");
        Bundle<Stamp> fourth = Cast<Stamp>(new Stamp(47));
        Check(fourth.Value.HasValue && fourth.Value.Value.Mark == 47 && calls == 4, "user-value-nullable-prefix-cast");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

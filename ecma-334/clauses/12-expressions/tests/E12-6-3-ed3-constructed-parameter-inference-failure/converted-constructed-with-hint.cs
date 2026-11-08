/*
Rules: E12-6-3-ed3-constructed-parameter-inference-failure
Authority: ECMA-334 3rd ed 25.6.4
Version: ISO-2
Expected: reject
Version-Witness: version-witnesses/E12-6-3-ed3-constructed-parameter-inference-failure/converted-constructed-with-hint.cs.part
Mutate: Read(source, hint)
Into: Read<int>(source, hint)
*/
// ECMA-334 3rd ed 25.6.4, p. 398 (PDF p. 418).
using System;
class Slot<T>
{
    public T Item;
    public Slot(T item) { Item = item; }
}
struct Packet
{
    public static implicit operator Slot<int>(Packet source) { return new Slot<int>(83); }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static T Read<T>(Slot<T> source, T hint) { return source.Item; }
    static int Main()
    {
        Packet source = new Packet();
        int hint = 32;
        int value = Read(source, hint);
        Check(value == 83, "constructed-conversion");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

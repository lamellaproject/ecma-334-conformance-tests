/*
Rules: E23-8-3-reference-simple-name; E23-8-3-reference-member-access; E23-8-3-reference-element-access; E23-8-3-simple-name-this
Authority: ECMA-334 7th ed 23.8.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: int first = Values[0];
Into: int first = Values[1];
*/
using System;
unsafe struct Item
{
    public fixed int Values[2];
    public int Read()
    {
        int first = Values[0];
        int second = this.Values[0];
        return first + second;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static unsafe void Main()
    {
        Item value = new Item();
        value.Values[0] = 19; value.Values[1] = 5;
        Check(value.Read() == 38, "simple-buffer-name-is-this-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

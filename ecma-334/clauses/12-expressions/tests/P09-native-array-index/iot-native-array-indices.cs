/*
Rules: P09-native-array-index
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: items[index++] += 4;
Into: items[index--] += 4;
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
    static int Main()
    {
        int[] items = new int[] { 10, 20, 30 };
        nuint index = 1;
        items[index++] += 4;
        Check(index == 2 && items[1] == 24, "unsigned-index-side-effect-once");
        nint last = 2;
        Check(items[last] == 30, "signed-native-array-index");
        bool low = false, high = false;
        nint negative = -1;
        nuint outside = 3;
        try { int value = items[negative]; }
        catch (IndexOutOfRangeException) { low = true; }
        try { int value = items[outside]; }
        catch (IndexOutOfRangeException) { high = true; }
        Check(low, "negative-native-index-bounds");
        Check(high, "unsigned-native-index-bounds");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

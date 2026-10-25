/*
Rules: P10-record-struct-type; E16-4-4-assignment-copy; E16-4-6-boxing-copy
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 4
Mutate: readonly record struct Archive
Into: record class Archive
*/
using System;
readonly record struct Archive
{
    public readonly int Code;
    public readonly int[] Marks;
    public Archive(int code, int[] marks) { Code = code; Marks = marks; }
}
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
        Archive first = new Archive(37, new int[] { 11 });
        Archive second = first;
        object box = second;
        Check(box is ValueType, "record-is-value-type");
        Check(!object.ReferenceEquals((object)first, (object)second), "boxing-distinct-copies");
        first = new Archive(41, new int[] { 13 });
        Check(second.Code == 37 && ((Archive)box).Code == 37, "assignment-snapshot");
        second.Marks[0] = 17;
        Check(((Archive)box).Marks[0] == 17, "copy-retains-referent");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

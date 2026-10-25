/*
Rules: P08-interface-explicit-public-member
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: public int Value { get; set; }
Into: internal int Value { get; set; }
*/
using System;
using System.Reflection;

interface IValue
{
    public int Value { get; set; }
}
class ValueBox : IValue
{
    int stored;
    public int Gets, Sets;
    int IValue.Value
    {
        get { Gets++; return stored; }
        set { Sets++; stored = value; }
    }
}
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
        PropertyInfo property = typeof(IValue).GetProperty("Value", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        ValueBox box = new ValueBox();
        IValue view = box;
        view.Value = 71;
        int value = view.Value;
        Check(property.GetGetMethod(true).IsPublic, "explicit-public-getter-access-flag");
        Check(property.GetSetMethod(true).IsPublic, "explicit-public-setter-access-flag");
        Check(value == 71, "explicit-public-property-storage");
        Check(box.Gets == 1 && box.Sets == 1, "explicit-public-property-effects-once");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

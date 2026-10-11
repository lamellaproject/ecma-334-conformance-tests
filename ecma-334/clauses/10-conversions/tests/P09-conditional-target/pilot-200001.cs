/*
Rules: P09-conditional-target
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 1
Mutate: bool choose=DateTime.UtcNow.Ticks>=0;
Into: bool choose=default(bool);
*/
using System;

interface IUnit {int Value{get;}} class LeftUnit:IUnit{public int Value=>281;} class RightUnit:IUnit{public int Value=>283;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        bool choose=DateTime.UtcNow.Ticks>=0; IUnit unit=choose ? new LeftUnit() : new RightUnit(); Check(unit.Value==281, "P09-conditional-target-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

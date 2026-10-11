/*
Rules: P08-switch-common; P08-switch-target; P08-switch-selected
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 4
Mutate: short bounded=selector switch
Into: short bounded=(short)0; short unused=selector switch
*/
using System;


interface IRecord {int Code {get;}}
class FirstRecord:IRecord {public int Code=>31;}
class SecondRecord:IRecord {public int Code=>47;}
static class Log {public static int Count;}
struct Input {public static implicit operator Destination(Input x){Log.Count++;return new Destination(73);}}
struct Destination {public int Code;public Destination(int x){Code=x;}}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int selector=2;
        short bounded=selector switch { 0 => 113, _ => 227 };
        long widened=selector switch { 0 => (byte)17, _ => 229L };
        IRecord record=selector switch { 0 => new FirstRecord(), _ => new SecondRecord() };
        Check(bounded==227 && widened==229 && record.Code==47, "P08-switch-common-pilot-200001-check-01");
        Check(Log.Count==0, "P08-switch-common-pilot-200001-check-02"); // conversions occur only in the selected arm
        Destination selected=selector switch {0 => new Input(), _ => new Destination(61)};
        Check(selected.Code==61 && Log.Count==0, "P08-switch-common-pilot-200001-check-03");
        selector=0; selected=selector switch {0 => new Input(), _ => new Destination(61)};
        Check(selected.Code==73 && Log.Count==1, "P08-switch-common-pilot-200001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

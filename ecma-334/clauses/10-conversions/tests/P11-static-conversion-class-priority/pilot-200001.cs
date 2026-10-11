/*
Rules: P11-static-conversion-class-priority
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 1
Mutate: where T:Base,IConvert<T>
Into: where T:IConvert<T>
*/
using System;


interface IConvert<T> where T:IConvert<T>{static abstract implicit operator long(T x);}
class Base{public static implicit operator int(Base x)=>827;}
class Derived:Base,IConvert<Derived>{public static implicit operator long(Derived x)=>829;}
static class Convert{public static long Read<T>(T x) where T:Base,IConvert<T> =>x;}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Check(Convert.Read(new Derived())==827L, "P11-static-conversion-class-priority-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

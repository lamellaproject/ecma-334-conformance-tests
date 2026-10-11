/*
Rules: P15-union15-execute
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: run
Stdout: OK 1
Mutate: FactoryUnion value=727;
Into: FactoryUnion value=default(FactoryUnion);
*/
using System;


[System.Runtime.CompilerServices.Union]
struct FactoryUnion:FactoryUnion.IUnionMembers{
    object stored;public static int Calls;
    object IUnionMembers.Value=>stored;
    public interface IUnionMembers{object Value{get;}public static FactoryUnion Create(int n){Calls++;return new FactoryUnion{stored=n};}}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        FactoryUnion value=727;Check((int)((FactoryUnion.IUnionMembers)value).Value==727 && FactoryUnion.Calls==1, "P15-union15-execute-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

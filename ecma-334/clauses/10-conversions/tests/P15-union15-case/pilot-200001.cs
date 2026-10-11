/*
Rules: P15-union15-case; P15-union15-nullable; P15-union15-execute
Authority: csc 5.11.0-1.26425.128 (C# 15.0)
Version: 15.0
Expected: run
Stdout: OK 2
Mutate: UnionValue numeric=n;
Into: UnionValue numeric=default;
*/
using System;


    [System.Runtime.CompilerServices.Union]
    struct UnionValue{
        public object Value{get;} public static int Calls;
        public UnionValue(long value){Calls++;Value=value;}
        public UnionValue(string value){Calls++;Value=value;}
    }
class LeftCase{public int Code;public LeftCase(int n){Code=n;}}class RightCase{}union NamedUnion(LeftCase,RightCase);
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        UnionValue.Calls=0;short n=709;UnionValue numeric=n;UnionValue text="chalk";
        UnionValue? wrapped="tuff";
        Check((long)numeric.Value==709 && (string)text.Value=="chalk" && wrapped.HasValue && (string)wrapped.Value.Value=="tuff" && UnionValue.Calls==3, "P15-union15-case-pilot-200001-check-01");
        NamedUnion simple=new LeftCase(719);Check(((LeftCase)simple.Value).Code==719, "P15-union15-case-pilot-200001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

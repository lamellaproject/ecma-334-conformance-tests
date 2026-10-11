/*
Rules: P08-nrt-annotations; P08-nrt-suppression; P08-nrt-constraints
Authority: csc 5.11.0-1.26425.128 (C# 8.0)
Version: 8.0
Expected: run
Stdout: OK 3
Mutate: object? target=text;
Into: object? target=default(object?);
*/
using System;
#nullable enable
static class Annotation { public static T Echo<T>(T x) where T:class => x; }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        string? absent=null; string forced=absent!; Check(forced==null, "P08-nrt-annotations-pilot-200001-check-01");
        string? text="anvil"; object? target=text; string restored=(string)target!;
        string?[] array=new string?[]{text,null}; string[] unannotated=array!;
        System.Collections.Generic.List<string?> a=new System.Collections.Generic.List<string?>(){text};
        System.Collections.Generic.List<string> b=a;
        Check(ReferenceEquals(text,restored) && ReferenceEquals(array,unannotated) && ReferenceEquals(a,b), "P08-nrt-annotations-pilot-200001-check-02");
        Check(Annotation.Echo<string?>(null)==null, "P08-nrt-annotations-pilot-200001-check-03");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

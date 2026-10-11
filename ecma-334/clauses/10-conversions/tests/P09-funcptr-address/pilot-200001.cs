/*
Rules: P09-funcptr-address; P09-funcptr-overload; P09-funcptr-void; P09-funcptr-parameter; P09-funcptr-return
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 3
Mutate: void* raw=pointer;
Into: void* raw=default(void*);
*/
using System;

static class Address {public static int Apply(int x)=>x+17;public static long Apply(long x)=>x+23;}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe {
            delegate*<int,int> pointer=&Address.Apply; Check(pointer(151)==168, "P09-funcptr-address-pilot-200001-check-01");
            delegate*<int,int> identity=pointer; Check(identity(157)==174, "P09-funcptr-address-pilot-200001-check-02");
            void* raw=pointer; delegate*<int,int> restored=(delegate*<int,int>)raw;
            Check(restored(163)==180, "P09-funcptr-address-pilot-200001-check-03");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: P10-handler-arguments
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 1
Mutate: Receiver r=new Receiver();
Into: Receiver r=default(Receiver);
*/
using System;


class Receiver {public int Code=337;public int Send(int value,[System.Runtime.CompilerServices.InterpolatedStringHandlerArgument("","value")] Routed h)=>h.Total;}
[System.Runtime.CompilerServices.InterpolatedStringHandler]
struct Routed {
    public int Total;
    public Routed(int l,int c,Receiver receiver,int value){Total=receiver.Code+value;}
    public void AppendFormatted(int value){}
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Receiver r=new Receiver(); int n=337; Check(r.Send(n,$"{n}")==674, "P10-handler-arguments-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

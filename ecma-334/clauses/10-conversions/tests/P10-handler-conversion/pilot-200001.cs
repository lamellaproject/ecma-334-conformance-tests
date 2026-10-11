/*
Rules: P10-handler-conversion; P10-handler-concatenation; P10-handler-ref; P10-handler-preference; P10-handler-constructor; P10-handler-literal; P10-handler-formatted; P10-handler-result
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: run
Stdout: OK 3
Mutate: Handler h=$"p{{{data,4:x}}}q";
Into: Handler h=new Handler(0,0);
*/
using System;


[System.Runtime.CompilerServices.InterpolatedStringHandler]
struct Handler {
    public int Length,Count; public string Text;
    public Handler(int length,int count){Length=length;Count=count;Text="";}
    public void AppendLiteral(string text){Text+=text;}
    public void AppendFormatted<T>(T value,int alignment=0,string format=null){Text+=value.ToString()+":"+alignment+":"+format;}
}
static class Sink {
    public static int Read(ref Handler h)=>h.Count;
    public static int Pick(Handler h)=>1;
    public static int Pick(string h)=>2;
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int data=317;
        Handler h=$"p{{{data,4:x}}}q";
        Check(h.Length==4 && h.Count==1 && h.Text=="p{317:4:x}q", "P10-handler-conversion-pilot-200001-check-01");
        Handler combined=$"r{data}"+$"s{data+2}";
        Check(combined.Count==2 && combined.Length==2 && combined.Text=="r317:0:s319:0:", "P10-handler-conversion-pilot-200001-check-02");
        Check(Sink.Read($"{data}")==1 && Sink.Pick($"{data}")==1 && Sink.Pick($"spruce")==2, "P10-handler-conversion-pilot-200001-check-03");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

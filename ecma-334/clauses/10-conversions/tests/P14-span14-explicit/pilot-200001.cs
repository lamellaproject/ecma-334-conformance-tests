/*
Rules: P14-span14-explicit
Authority: csc 5.11.0-1.26425.128 (C# 14.0)
Version: 14.0
Expected: run
Stdout: OK 2
Mutate: Span<string> mutable=(Span<string>)source;
Into: Span<string> mutable=default(Span<string>);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        object[] source=new string[]{"gabbro","diorite"}; Span<string> mutable=(Span<string>)source;
        ReadOnlySpan<string> readonly_=(ReadOnlySpan<string>)source; Check(mutable[1]=="diorite" && readonly_[0]=="gabbro", "P14-span14-explicit-pilot-200001-check-01");
        source=new object[]{"gabbro"};try{ReadOnlySpan<string> invalid=(ReadOnlySpan<string>)source;Check(false, "P14-span14-explicit-pilot-200001-check-02");}catch (InvalidCastException) { Check(true, "P14-span14-explicit-pilot-200001-check-02"); } catch (Exception error) { Check(false, "P14-span14-explicit-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

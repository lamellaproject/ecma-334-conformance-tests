/*
Rules: E10-7-2-capture; E10-7-2-creation-syntax; E10-7-2-single-entry; E10-7-2-target; E10-7-2-reuse
Authority: ECMA-334 7th ed 10.7.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: captured=new Func<int>(()=>++state);
Into: captured=new Func<int>(()=>state);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int state=61; Func<int> captured=new Func<int>(()=>++state);
        Func<int>[] entries=new Func<int>[2]; for(int i=0;i<2;i++){int local=i;entries[i]=()=>local;}
        Check(captured()==62 && state==62 && entries[0]()==0 && entries[1]()==1 && captured.GetInvocationList().Length==1, "E10-7-2-capture-pilot-001-check-01");
        Func<int> a=()=>state, b=()=>state;
        Check(a()==62 && b()==62 && a.GetInvocationList().Length==1 && b.GetInvocationList().Length==1, "E10-7-2-capture-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E10-5-5-identity-once; E10-5-4-identity-once
Authority: ECMA-334 7th ed 10.5.5
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Second implicitValue=source;
Into: Second implicitValue=default(Second);
*/
using System;


class Root<T> {public static int Calls;public static implicit operator T(Root<T> x){Calls++;return (T)(object)new Second();}}
class First:Root<Second> {} class Second:Root<Second> {}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        First source=new First(); Second implicitValue=source; Second explicitValue=(Second)source;
        Check(implicitValue!=null && explicitValue!=null && Root<Second>.Calls==2, "E10-5-5-identity-once-pilot-001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

/*
Rules: E10-3-8-any; E10-3-8-lookup; E10-3-8-failure; E10-3-8-object-first; E10-3-1-categories
Authority: ECMA-334 7th ed 10.3.8
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: byte narrow=unchecked((byte)source);
Into: byte narrow=default(byte);
*/
using System;

struct Packet {public int Value; public static int Calls; public static explicit operator int(Packet x){Calls++;return x.Value;} }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        dynamic source=317; byte narrow=unchecked((byte)source); object staticSource=(object)source;
        Check(narrow==61, "E10-3-8-any-pilot-001-check-01");
        dynamic user=new Packet {Value=82}; int converted=(int)user;
        Check(converted==82 && Packet.Calls==1, "E10-3-8-any-pilot-001-check-02");
        dynamic missing=new DateTime(); try { int fail=(int)missing; Check(false, "E10-3-8-any-pilot-001-check-03"); } catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { Check(true, "E10-3-8-any-pilot-001-check-03"); } catch (Exception error) { Check(false, "E10-3-8-any-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        try { byte fail=(byte)staticSource; Check(false, "E10-3-8-any-pilot-001-check-04"); } catch (InvalidCastException) { Check(true, "E10-3-8-any-pilot-001-check-04"); } catch (Exception error) { Check(false, "E10-3-8-any-unexpected-exception-2"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

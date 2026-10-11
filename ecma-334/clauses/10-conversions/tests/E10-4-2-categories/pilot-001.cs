/*
Rules: E10-4-2-categories; E10-4-1-standard; E10-5-1-class-struct
Authority: ECMA-334 7th ed 10.4.2
Version: 7.3
Expected: run
Stdout: OK 2
Mutate: Envelope<object> boxed=61;
Into: Envelope<object> boxed=default(Envelope<object>);
*/
using System;


struct Envelope<T> {public T Value;public static implicit operator Envelope<T>(T x){return new Envelope<T> {Value=x};}}
class ClassEnvelope {public int Number;public static int Calls;public static implicit operator ClassEnvelope(int x){Calls++;return new ClassEnvelope {Number=x};}}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Envelope<object> boxed=61; Envelope<long?> wrapped=82; Envelope<string> nullValue=null;
        ClassEnvelope reference=93;
        Check(boxed.Value.GetType()==typeof(int) && (int)boxed.Value==61 && wrapped.Value.Value==82 && nullValue.Value==null, "E10-4-2-categories-pilot-001-check-01");
        Check(reference.Number==93 && ClassEnvelope.Calls==1, "E10-4-2-categories-pilot-001-check-02");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

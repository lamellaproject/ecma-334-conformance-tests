/*
Rules: P11-static-conversion-declare; P11-static-conversion-implicit; P11-static-conversion-explicit
Authority: csc 5.11.0-1.26425.128 (C# 11.0)
Version: 11.0
Expected: run
Stdout: OK 1
Mutate: Amount a=Convert.From<Amount>(281);
Into: Amount a=default(Amount);
*/
using System;


interface IConvert<T> where T:IConvert<T> {
    static abstract implicit operator T(int x);
    static abstract explicit operator int(T x);
}
struct Amount:IConvert<Amount> {
    public int Code;
    public static implicit operator Amount(int x)=>new Amount{Code=x+89};
    public static explicit operator int(Amount x)=>x.Code+97;
}
static class Convert {
    public static T From<T>(int x) where T:IConvert<T> => x;
    public static int To<T>(T x) where T:IConvert<T> => (int)x;
}

class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Amount a=Convert.From<Amount>(281);Check(a.Code==370 && Convert.To(a)==467, "P11-static-conversion-declare-pilot-200001-check-01");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

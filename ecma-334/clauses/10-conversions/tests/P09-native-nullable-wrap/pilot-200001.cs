/*
Rules: P09-native-nullable-wrap; P09-native-nullable-lift; P09-native-nullable-unwrap
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: nint? wrapped=x;
Into: nint? wrapped=default(nint?);
*/
using System;


class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        int x=173; nint? wrapped=x; nint? input=(nint)173; long? widened=input;
        Check((long)wrapped.Value==173 && widened.Value==173, "P09-native-nullable-wrap-pilot-200001-check-01");
        input=null; widened=input; Check(!widened.HasValue, "P09-native-nullable-wrap-pilot-200001-check-02");
        try { long value=(long)input; Check(false, "P09-native-nullable-wrap-pilot-200001-check-03"); } catch (InvalidOperationException) { Check(true, "P09-native-nullable-wrap-pilot-200001-check-03"); } catch (Exception error) { Check(false, "P09-native-nullable-wrap-unexpected-exception-1"); Console.WriteLine("EXCEPTION " + error.GetType().FullName); }
        nuint? unsigned=(nuint)193; ulong? other=unsigned; Check(other.Value==193, "P09-native-nullable-wrap-pilot-200001-check-04");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

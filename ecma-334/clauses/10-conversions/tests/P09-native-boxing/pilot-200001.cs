/*
Rules: P09-native-boxing; P09-native-enumeration; P09-native-pointer
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: run
Stdout: OK 4
Mutate: object boxed=value;
Into: object boxed=default(object);
*/
using System;

enum Badge : long { Unused=0 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        nint value=(nint)149; object boxed=value; Check(boxed.GetType()==typeof(IntPtr) && (nint)boxed==value, "P09-native-boxing-pilot-200001-check-01");
        Badge badge=(Badge)value; Check((nint)badge==value, "P09-native-boxing-pilot-200001-check-02");
        nuint u=(nuint)157; Badge other=(Badge)u; Check((nuint)other==u, "P09-native-boxing-pilot-200001-check-03");
        unsafe { void* pointer=(void*)value; Check((nint)pointer==value, "P09-native-boxing-pilot-200001-check-04"); }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

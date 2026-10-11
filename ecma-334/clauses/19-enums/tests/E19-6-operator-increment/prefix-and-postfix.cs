/*
Rules: E19-6-operator-increment; E19-6-operator-decrement
Authority: ECMA-334 7th ed 19.6
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: Code oldIncrement = value++
Into: Code oldIncrement = ++value
*/
using System;
enum Code : byte { Start = 2 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Code value = Code.Start;
        Code oldIncrement = value++;
        Check((byte)oldIncrement == 2 && (byte)value == 3, "postincrement-old-value-and-store");
        Code newIncrement = ++value;
        Check((byte)newIncrement == 4 && (byte)value == 4, "preincrement-new-value-and-store");
        Code oldDecrement = value--;
        Check((byte)oldDecrement == 4 && (byte)value == 3, "postdecrement-old-value-and-store");
        Code newDecrement = --value;
        Check((byte)newDecrement == 2 && (byte)value == 2, "predecrement-new-value-and-store");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

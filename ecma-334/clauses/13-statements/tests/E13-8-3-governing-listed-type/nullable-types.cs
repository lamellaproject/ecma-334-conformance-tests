/*
Rules: E13-8-3-governing-listed-type
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 11
Mutate: switch (signed8)
Into: switch ((int?)signed8)
*/
using System;
enum Shade { Amber = 4 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        sbyte? signed8 = -4;
        byte? unsigned8 = 204;
        short? signed16 = -304;
        ushort? unsigned16 = 504;
        int? signed32 = -704;
        uint? unsigned32 = 904U;
        long? signed64 = -1104L;
        ulong? unsigned64 = 1304UL;
        char? letter = 'Q';
        bool? flag = true;
        Shade? shade = Shade.Amber;
        switch (signed8) { case sbyte value: Check(value == -4, "nullable-sbyte-governing-type"); break; }
        switch (unsigned8) { case byte value: Check(value == 204, "nullable-byte-governing-type"); break; }
        switch (signed16) { case short value: Check(value == -304, "nullable-short-governing-type"); break; }
        switch (unsigned16) { case ushort value: Check(value == 504, "nullable-ushort-governing-type"); break; }
        switch (signed32) { case int value: Check(value == -704, "nullable-int-governing-type"); break; }
        switch (unsigned32) { case uint value: Check(value == 904U, "nullable-uint-governing-type"); break; }
        switch (signed64) { case long value: Check(value == -1104L, "nullable-long-governing-type"); break; }
        switch (unsigned64) { case ulong value: Check(value == 1304UL, "nullable-ulong-governing-type"); break; }
        switch (letter) { case char value: Check(value == 'Q', "nullable-char-governing-type"); break; }
        switch (flag) { case bool value: Check(value, "nullable-bool-governing-type"); break; }
        switch (shade) { case Shade value: Check(value == Shade.Amber, "nullable-enum-governing-type"); break; }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

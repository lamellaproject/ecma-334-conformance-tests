/*
Rules: E13-8-3-governing-listed-type
Authority: ECMA-334 7th ed 13.8.3
Version: 7.3
Expected: run
Stdout: OK 12
Mutate: switch (flag)
Into: switch (number)
*/
using System;
enum Tone { Bright = 17 }
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static int Read() { return 17; }
    static void Main()
    {
        int number = Read();
        sbyte signed8 = (sbyte)number;
        byte unsigned8 = (byte)number;
        short signed16 = (short)number;
        ushort unsigned16 = (ushort)number;
        int signed32 = (int)number;
        uint unsigned32 = (uint)number;
        long signed64 = (long)number;
        ulong unsigned64 = (ulong)number;
        char letter = (char)number;
        bool flag = number == 17;
        Tone tone = (Tone)number;
        string text = number == 17 ? "bright" : "dim";
        switch (signed8) { case 17: Check(signed8 == 17, "sbyte"); break; }
        switch (unsigned8) { case 17: Check(unsigned8 == 17, "byte"); break; }
        switch (signed16) { case 17: Check(signed16 == 17, "short"); break; }
        switch (unsigned16) { case 17: Check(unsigned16 == 17, "ushort"); break; }
        switch (signed32) { case 17: Check(signed32 == 17, "int"); break; }
        switch (unsigned32) { case 17: Check(unsigned32 == 17, "uint"); break; }
        switch (signed64) { case 17: Check(signed64 == 17, "long"); break; }
        switch (unsigned64) { case 17: Check(unsigned64 == 17, "ulong"); break; }
        switch (letter) { case '\u0011': Check(letter == '\u0011', "char"); break; }
        switch (flag) { case true: Check(flag == true, "bool"); break; }
        switch (tone) { case Tone.Bright: Check(tone == Tone.Bright, "Tone"); break; }
        switch (text) { case "bright": Check(text == "bright", "string"); break; }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

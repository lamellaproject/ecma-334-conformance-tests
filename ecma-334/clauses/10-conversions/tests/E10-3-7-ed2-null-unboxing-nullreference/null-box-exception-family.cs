/*
Rules: E10-3-7-ed2-null-unboxing-nullreference; E10-3-7-type-failure
Authority: ECMA-334 2nd ed 11.3.2
Version: ISO-1
Expected: run
Stdout: OK 4
Mutate: (int)vacant
Into: (int)(object)5
*/
using System;
interface IChannel { }
struct Channel : IChannel { }
struct BackupChannel : IChannel { }
class NullBoxException
{
    static int checks;
    static int failures;
    static void Check(bool condition, string name)
    {
        checks++;
        if (!condition)
        {
            failures++;
            Console.WriteLine("FAIL " + name);
        }
    }
    static int Main()
    {
        object vacant = null;
        bool expected = false;
        try { int recovered = (int)vacant; expected = recovered == 0 && false; }
        catch (System.NullReferenceException) { expected = true; }
        catch (System.Exception) { expected = false; }
        Check(expected, "null-unboxing-exception");

        IChannel vacantChannel = null;
        expected = false;
        try { Channel recovered = (Channel)vacantChannel; }
        catch (System.NullReferenceException) { expected = true; }
        catch (System.Exception) { }
        Check(expected, "null-interface-unboxing-exception");

        object wrongNumber = (short)17;
        expected = false;
        try { int recovered = (int)wrongNumber; }
        catch (System.InvalidCastException) { expected = true; }
        catch (System.Exception) { }
        Check(expected, "incompatible-object-unboxing-exception");

        IChannel backup = new BackupChannel();
        expected = false;
        try { Channel recovered = (Channel)backup; }
        catch (System.InvalidCastException) { expected = true; }
        catch (System.Exception) { }
        Check(expected, "incompatible-interface-unboxing-exception");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

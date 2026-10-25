/*
Rules: E13-9-5-ed1-array-enumerator-object
Authority: ECMA-334 1st ed 15.8.4
Version: ISO-1
Expected: run
Stdout: OK 3
Version-Witness: tests/E13-9-5-ed1-array-enumerator-object/array-string-iteration.witness.cs.part
Mutate: foreach (string value in values)
Into: foreach (object value in values)
*/
// ECMA-334 1st ed 15.8.4, p. 191 (PDF p. 205), lines 15-20 and 28-40. An array foreach
// uses System.Array enumeration and casts its object-valued Current directly to the
// iteration type.
using System;
class Entry
{
    static int checks;
    static int failures;
    static void Check(bool result, string label)
    {
        checks++;
        if (!result)
        {
            failures++;
            Console.WriteLine("FAIL " + label);
        }
    }
    static int Main()
    {
        int[] values = new int[] {5, 8};
        int entered = 0;
        bool cast = false;
        try
        {
            foreach (string value in values)
            {
                if (value != null) entered++;
            }
        }
        catch (InvalidCastException) { cast = true; }
        Check(cast, "object-current-cast");
        Check(entered == 0, "no-body-before-cast");
        int sum = 0;
        foreach (int item in values) sum += item;
        Check(sum == 13, "int-iteration-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

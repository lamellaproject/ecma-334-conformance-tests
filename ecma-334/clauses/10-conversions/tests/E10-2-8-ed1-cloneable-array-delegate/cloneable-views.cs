/*
Rules: E10-2-8-ed1-cloneable-array-delegate
Authority: ECMA-334 1st ed 13.1.4
Version: ISO-1
Expected: run
Stdout: OK 2
Mutate: ICloneable arrayView = array;
Into: ICloneable arrayView = (int[])array.Clone();
*/
// ECMA-334 1st ed 13.1.4, p. 114 (PDF p. 128), line 30. Any array type or delegate type
// implicitly converts to System.ICloneable, preserving the referential identity of its
// source.
using System;

delegate void Signal();

class Entry
{
    static int checks;
    static int failures;
    static void Notify() { }

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
        int[] array = new int[1];
        Signal callback = new Signal(Notify);
        ICloneable arrayView = array;
        ICloneable delegateView = callback;
        Check(object.ReferenceEquals(arrayView, array), "array-reference");
        Check(object.ReferenceEquals(delegateView, callback), "delegate-reference");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

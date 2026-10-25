/*
Rules: E18-6-2-ed1-explicit-new-modifier
Authority: ECMA-334 1st ed 20.4.1
Version: ISO-1
Expected: run
Stdout: OK 1
Diagnostic: warning
Version-Witness: tests/E18-6-2-ed1-explicit-new-modifier/explicit-new-modifier.witness.cs.part
Mutate: new int IReader.Read()
Into: public int IReader.Read()
*/
// ECMA-334 1st ed 20.4.1, p. 289 (PDF p. 303), lines 51-52. An explicit interface member
// implementation may include new: the forbidden-modifier list excludes it.
using System;
interface IReader { int Read(); }
class Sensor : IReader
{
    new int IReader.Read() { return 827; }
}
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
        IReader reader = new Sensor();
        Check(reader.Read() == 827, "explicit-new-implementation");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

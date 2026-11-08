/*
Rules: E15-2-4-2-ed1-immediate-class-dependency
Authority: ECMA-334 1st ed 17.1.2.1
Version: ISO-1
Expected: run
Stdout: OK 1
Version-Witness: version-witnesses/E15-2-4-2-ed1-immediate-class-dependency/inherited-member-through-struct.cs.part
Mutate: public struct Coupling
Into: public class Coupling
*/
// ECMA-334 1st ed 17.1.2.1, p. 213 (PDF p. 227).
using System;
class Backup
{
    public int Read() { return 43; }
}
class Vehicle : Vehicle.Coupling.Base
{
    public struct Coupling
    {
        public class Base
        {
            public int Read() { return 43; }
        }
    }
}
class Dependency
{
    static int checks, failures;
    static void Check(bool ok, string id)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + id); }
    }
    static int Main()
    {
        Check(new Vehicle().Read() == 43, "inherited-member");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

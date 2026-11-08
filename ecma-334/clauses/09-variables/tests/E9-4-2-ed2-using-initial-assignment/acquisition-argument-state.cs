/*
Rules: E9-4-2-ed2-using-initial-assignment
Authority: ECMA-334 2nd ed 12.1.7
Version: ISO-1
Expected: reject
Version-Witness: version-witnesses/E9-4-2-ed2-using-initial-assignment/acquisition-argument-state.cs.part
Mutate: Select(candidate)
Into: Select(new Permit())
*/
// ECMA-334 2nd ed 12.1.7, p. 101 (PDF p. 117); 12.3.1 and 12.3.2, p. 103 (PDF p. 119).
using System;
sealed class Permit : IDisposable
{
    public void Dispose() { }
}
class Acquisition
{
    static Permit Select(Permit value) { return value; }
    static void Main()
    {
        using (Permit candidate = Select(candidate))
        {
            Console.WriteLine("OK 1");
        }
    }
}

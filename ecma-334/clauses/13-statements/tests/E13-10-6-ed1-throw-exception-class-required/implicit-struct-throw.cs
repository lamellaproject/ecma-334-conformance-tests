/*
Rules: E13-10-6-ed1-throw-exception-class-required
Authority: ECMA-334 1st ed 15.9.5
Version: ISO-1
Expected: reject
Mutate: throw notice;
Into: throw (Exception)notice;
*/
// ECMA-334 1st ed 15.9.5, p. 196 (PDF p. 210), lines 11-14 restricts this operand to an
// Exception class.
using System;
struct Notice
{
    public static implicit operator Exception(Notice value)
    {
        return new InvalidOperationException("notice");
    }
}
class Entry
{
    public static int Main()
    {
        Notice notice = new Notice();
        try { throw notice; }
        catch (InvalidOperationException) { return 0; }
    }
}

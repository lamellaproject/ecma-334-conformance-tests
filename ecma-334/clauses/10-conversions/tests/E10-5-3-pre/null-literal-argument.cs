/*
Rules: E10-5-3-pre; E10-4-2-categories; E10-2-7-nullable
Authority: ECMA-334 7th ed 10.5.3
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: Read(null)
Into: Read((short?)1)
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string name)
    {
        checks++;
        if (!ok) { failures++; Console.WriteLine("FAIL " + name); }
    }
    struct Bundle
    {
        public int Mark;
        public static implicit operator Bundle(short? value)
        {
            Bundle result = new Bundle();
            result.Mark = value.HasValue ? 13 : 23;
            return result;
        }
    }
    static int Read(Bundle value) { return value.Mark; }
    static int Main()
    {
        Check(Read(null) == 23, "null-literal-user-conversion-argument");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

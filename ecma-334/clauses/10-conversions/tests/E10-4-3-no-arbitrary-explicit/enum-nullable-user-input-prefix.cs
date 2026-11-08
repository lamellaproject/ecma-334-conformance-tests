/*
Rules: E10-4-3-no-arbitrary-explicit; E10-5-5-empty
Authority: ECMA-334 7th ed 10.4.3
Version: 7.3
Expected: reject
Version-Witness: version-witnesses/E10-4-3-no-arbitrary-explicit/enum-nullable-user-input-prefix.cs.part
Mutate: (Bundle)source
Into: (Bundle)(int)source
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
    enum Signal { Marked = 37 }
    struct Bundle
    {
        public int Mark;
        public static implicit operator Bundle(int? value)
        {
            Bundle result = new Bundle();
            result.Mark = value.HasValue ? value.Value : 19;
            return result;
        }
    }
    static int Main()
    {
        Signal source = Signal.Marked;
        Bundle result = (Bundle)source;
        Check(result.Mark == 37, "separate-enum-and-user-cast-control");
        if (failures == 0) Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

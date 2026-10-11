/*
Rules: E7-7-1-expanded-construct-variable-scope
Authority: ECMA-334 7th ed 7.7.1
Version: 7.3
Expected: run
Stdout: OK 1
Mutate: from value in source
Into: from renamed in source
*/
using System;
delegate int Mapper(int input);
class Values
{
    public int[] Items;
    public int[] Select(Mapper operation)
    {
        int[] result = new int[Items.Length];
        for (int index = 0; index < result.Length; index++) result[index] = operation(Items[index]);
        return result;
    }
}
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Values source = new Values { Items = new int[] { 2, 4 } };
        int[] result = from value in source select value + 1;
        Check(result[0] == 3 && result[1] == 5, "range-variable-visible-in-expanded-select-lambda");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

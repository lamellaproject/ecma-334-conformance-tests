/*
Rules: E12-8-9-2-ed3-constraints-after-selection
Authority: ECMA-334 3rd ed 14.5.5.1
Version: ISO-2
Expected: reject
Version-Witness: tests/E12-8-9-2-ed3-constraints-after-selection/explicit-argument-constraint.witness.cs.part
Mutate: where T : struct
Into: where T : class
*/
class Program
{
    static int Route<T>(T item) where T : struct { return 17; }
    static int Route<T>(object item) { return 29; }
    static int Main()
    {
        int checks = 0;
        int failures = 0;
        checks++;
        if (!(Route<string>("fern") == 17))
        {
            failures++;
            System.Console.WriteLine("FAIL selected-generic-overload");
        }
        if (failures == 0) System.Console.WriteLine("OK " + checks);
        return failures == 0 ? 0 : 1;
    }
}

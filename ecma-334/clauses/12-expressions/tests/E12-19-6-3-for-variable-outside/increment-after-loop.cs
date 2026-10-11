/*
Rules: E12-19-6-3-for-variable-outside
Authority: ECMA-334 7th ed 12.19.6.3
Version: 7.3
Expected: run
Stdout: OK 3
Mutate: functions[(4 - turn) / 2] = () => ++turn;
Into: int copy = turn; functions[(4 - turn) / 2] = () => ++copy;
*/
using System;
delegate int Result();
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        Result[] functions = new Result[2];
        for (int turn = 4; turn > 0; turn -= 2)
        {
            functions[(4 - turn) / 2] = () => ++turn;
        }
        Check(functions[0]() == 1, "first-capture-sees-post-loop-iteration-variable");
        Check(functions[1]() == 2, "second-capture-shares-iteration-variable");
        Check(functions[0]() == 3, "updates-share-one-outside-loop-instance");
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

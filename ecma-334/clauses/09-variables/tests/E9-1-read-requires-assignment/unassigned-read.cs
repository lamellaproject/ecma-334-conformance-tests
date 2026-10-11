/*
Rules: E9-1-read-requires-assignment; E9-1-unassigned-no-initial-value; E9-2-9-declared-local-no-default; E9-2-9-declared-local-initially-unassigned; E9-4-1-read-requires-assignment; E9-4-3-local-variable-unassigned; E9-4-4-1-not-definitely-assigned-state
Authority: ECMA-334 7th ed 9.1
Version: 7.3
Expected: reject
Mutate: int cell;
Into: int cell = 23;
Csc: CS0165
*/
class Program
{
    static void Main()
    {
        int cell;
        System.Console.WriteLine(cell);
    }
}

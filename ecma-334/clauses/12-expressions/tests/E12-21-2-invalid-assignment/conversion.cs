/*
Rules: E12-21-2-invalid-assignment
Authority: ECMA-334 7th ed 12.21.2
Version: 7.3
Expected: reject
Mutate: target = "text"
Into: target = 3
Csc: CS0029
*/
class Program
{
    static void Main() { int target; target = "text"; }
}

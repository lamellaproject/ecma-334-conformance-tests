/*
Rules: E12-21-3-out-left-definitely-assigned
Authority: ECMA-334 7th ed 12.21.3
Version: 7.3
Expected: reject
Mutate: output = ref other;
Into: output = 0; output = ref other;
Csc: CS0177
*/
class Program
{
    // Writing the new referent does not initialize the caller's original out location.
    static void Move(out int output, ref int other) { output = ref other; output = 3; }
    static void Main() { int other = 4; int output; Move(out output, ref other); }
}

/*
Rules: E12-21-4-invalid-compound
Authority: ECMA-334 7th ed 12.21.4
Version: 7.3
Expected: reject
Mutate: int right = 4;
Into: byte right = 4;
Csc: CS0266
*/
class Program
{
    static void Main() { byte left = 3; int right = 4; left += right; }
}

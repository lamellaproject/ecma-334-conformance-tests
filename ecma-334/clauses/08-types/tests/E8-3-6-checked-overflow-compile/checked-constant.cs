/*
Rules: E8-3-6-checked-overflow-compile
Authority: ECMA-334 7th ed 8.3.6
Version: 7.3
Expected: reject
Mutate: checked(2147483647 + 1)
Into: unchecked(2147483647 + 1)
*/
class Program { static void Main() { const int value = checked(2147483647 + 1); } }

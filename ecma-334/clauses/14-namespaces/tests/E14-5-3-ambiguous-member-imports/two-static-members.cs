/*
Rules: E14-5-3-ambiguous-member-imports
Authority: ECMA-334 7th ed 14.5.3
Version: 7.3
Expected: reject
Mutate: int value = Code;
Into: int value = First.Code;
*/
using static First;
using static Second;
class First { public const int Code = 29; }
class Second { public const int Code = 31; }
class Program
{
    static void Main() { int value = Code; }
}

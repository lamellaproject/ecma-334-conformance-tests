/*
Rules: E14-5-4-no-inherited-member-import
Authority: ECMA-334 7th ed 14.5.4
Version: 7.3
Expected: reject
Mutate: int value = Code;
Into: int value = Parent.Code;
*/
using static Child;
class Parent { public const int Code = 29; }
class Child : Parent { }
class Program
{
    static void Main() { int value = Code; }
}

/*
Rules: E14-5-4-no-inherited-type-import
Authority: ECMA-334 7th ed 14.5.4
Version: 7.3
Expected: reject
Mutate: Nested value
Into: Parent.Nested value
*/
using static Child;
class Parent { public class Nested { } }
class Child : Parent { }
class Program
{
    static void Main() { Nested value = null; }
}

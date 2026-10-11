/*
Rules: E14-8-1-missing-left-alias
Authority: ECMA-334 7th ed 14.8.1
Version: 7.3
Expected: reject
Mutate: Scope::Beacon.Code
Into: Scope.Beacon.Code
*/
class Scope { public class Beacon { public const int Code = 29; } }
class Program
{
    static void Main() { int value = Scope::Beacon.Code; }
}

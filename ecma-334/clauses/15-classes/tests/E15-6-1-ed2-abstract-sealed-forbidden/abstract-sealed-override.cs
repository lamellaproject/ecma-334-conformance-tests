/*
Rules: E15-6-1-ed2-abstract-sealed-forbidden
Authority: ECMA-334 2nd ed 17.5
Version: ISO-1
Expected: reject
Mutate: sealed abstract override
Into: abstract override
*/
abstract class RouteBase
{
    public virtual void Depart() {}
}
abstract class RouteBranch : RouteBase
{
    public sealed abstract override void Depart();
}
class RouteEntry { static void Main() {} }

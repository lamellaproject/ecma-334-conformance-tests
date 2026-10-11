/*
Rules: E12-14-1-unique-best
Authority: ECMA-334 7th ed 12.14.1
Version: 7.3
Expected: reject
Mutate: x && y
Into: x && (A)y
*/
class A
{
    public static implicit operator B(A x) { return new B(); }
    public static bool operator true(A x) { return true; }
    public static bool operator false(A x) { return false; }
    public static A operator &(A x, A y) { return x; }
}
class B
{
    public static implicit operator A(B x) { return new A(); }
    public static bool operator true(B x) { return true; }
    public static bool operator false(B x) { return false; }
    public static B operator &(B x, B y) { return x; }
}
class Program { static void Main() { A x = new A(); B y = new B(); var result = x && y; } }

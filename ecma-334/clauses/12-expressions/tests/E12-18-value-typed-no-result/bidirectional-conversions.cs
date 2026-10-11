/*
Rules: E12-18-value-typed-no-result
Authority: ECMA-334 7th ed 12.18
Version: 7.3
Expected: reject
Mutate: condition ? left : right
Into: condition ? left : (Left)right
*/
class Left { public static implicit operator Right(Left value) { return new Right(); } }
class Right { public static implicit operator Left(Right value) { return new Left(); } }
class Program
{
    static void Main()
    {
        bool condition = true;
        Left left = new Left();
        Right right = new Right();
        var result = condition ? left : right;
    }
}

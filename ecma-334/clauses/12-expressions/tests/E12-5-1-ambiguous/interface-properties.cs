/*
Rules: E12-5-1-ambiguous
Authority: ECMA-334 7th ed 12.5.1
Version: 7.3
Expected: reject
Mutate: receiver.Value
Into: ((ILeft)receiver).Value
*/
interface ILeft { int Value { get; } }
interface IRight { int Value { get; } }
interface IBoth : ILeft, IRight { }
class Box : IBoth
{
    int ILeft.Value { get { return 11; } }
    int IRight.Value { get { return 17; } }
}
class Program { static void Main() { IBoth receiver = new Box(); int value = receiver.Value; } }

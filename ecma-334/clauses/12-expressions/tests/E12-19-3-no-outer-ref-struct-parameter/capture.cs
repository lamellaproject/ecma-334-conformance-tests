/*
Rules: E12-19-3-no-outer-ref-struct-parameter
Authority: ECMA-334 7th ed 12.19.3
Version: 7.3
Expected: reject
Mutate: () => frame.Value
Into: () => 23
*/
ref struct Frame { public int Value; }
delegate int Result();
class Program
{
    static Result Make(Frame frame) { return () => frame.Value; }
    static void Main() { }
}

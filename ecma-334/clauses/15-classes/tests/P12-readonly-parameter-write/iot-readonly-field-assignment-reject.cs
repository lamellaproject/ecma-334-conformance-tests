/*
Rules: P12-readonly-parameter-write
Authority: csc 5.12.0-1.26529.118 (C# 12.0)
Version: 12.0
Expected: reject
Mutate: ref readonly State value
Into: ref State value
Csc: CS8332
*/
struct State { public int Number; }
class Test
{
    static void Write(ref readonly State value) { value.Number = 19; }
    static void Main() { State cell = new State(); Write(ref cell); }
}

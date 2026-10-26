/*
Rules: E7-6-ed2-ref-out-only-overloads
Authority: ECMA-334 2nd ed 10.6
Version: ISO-1
Expected: reject
Mutate: Stamp(out short mark)
Into: Stamp(out int mark)
*/
struct MethodBin
{
    public void Stamp(ref short mark) {}
    public void Stamp(out short mark) { mark = 12; }
}
class MethodBinEntry { static void Main() {} }

/*
Rules: E7-6-ed2-ref-out-only-overloads
Authority: ECMA-334 2nd ed 10.6
Version: ISO-1
Expected: reject
Mutate: PaintMark(out byte amount)
Into: PaintMark(out short amount)
*/
struct PaintMark
{
    public PaintMark(ref byte amount) {}
    public PaintMark(out byte amount) { amount = 18; }
}
class PaintEntry { static void Main() {} }

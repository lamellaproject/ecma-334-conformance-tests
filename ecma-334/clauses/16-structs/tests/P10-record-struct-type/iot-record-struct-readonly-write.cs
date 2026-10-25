/*
Rules: P10-record-struct-type; E16-2-2-readonly-no-write
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: public void Reset() { code = 0; }
Into: public int Reset() { return code; }
*/
readonly record struct Fixed
{
    readonly int code;
    public Fixed(int code) { this.code = code; }
    public void Reset() { code = 0; }
}
class Program { static void Main() { } }

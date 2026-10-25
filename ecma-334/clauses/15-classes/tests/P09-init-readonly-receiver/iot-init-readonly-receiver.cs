/*
Rules: P09-init-readonly-receiver
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: other.code = value;
Into: this.code = value;
*/
class Packet
{
    readonly int code;
    public int Code
    {
        get { return code; }
        init { Packet other = new Packet(); other.code = value; }
    }
}
class Program { static int Main() { return 0; } }

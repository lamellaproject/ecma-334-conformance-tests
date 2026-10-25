/*
Rules: P09-record-reserved-clone
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: public int Clone() { return 2; }
Into: public int CopyValue() { return 2; }
*/
readonly record struct Entry
{
    public int Clone() { return 2; }
}
class Program { static void Main() { } }

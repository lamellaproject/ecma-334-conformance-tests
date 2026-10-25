/*
Rules: P09-record-derived-kind; P10-record-class-spelling
Authority: csc 5.11.0-1.26425.128 (C# 10.0)
Version: 10.0
Expected: reject
Mutate: class Child : Parent { }
Into: record class Child : Parent { }
*/
record class Parent { }
class Child : Parent { }
class Program
{
    static int Main() { new Child(); return 0; }
}

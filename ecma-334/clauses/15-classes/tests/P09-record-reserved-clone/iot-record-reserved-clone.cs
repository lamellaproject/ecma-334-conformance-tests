/*
Rules: P09-record-reserved-clone
Authority: csc 5.11.0-1.26425.128 (C# 9.0)
Version: 9.0
Expected: reject
Mutate: public void Clone()
Into: public void Copy()
Csc: CS8859
*/
record Folio { public void Clone() { } }
class Program { static void Main() { } }

/*
Rules: Ppreview-unsafe-preview-delegate-context
Authority: csc 5.11.0-1.26425.128 (C# preview)
Version: preview
Expected: reject
Requirements: updated-memory-safety
Mutate: Func<int> callable=Source.Read;
Into: Func<int> callable=default(Func<int>);
*/
using System;

static class Source{public static unsafe int Read()=>797;}
class Program
{
    static void Main()
    {
        Func<int> callable=Source.Read;
    }
}

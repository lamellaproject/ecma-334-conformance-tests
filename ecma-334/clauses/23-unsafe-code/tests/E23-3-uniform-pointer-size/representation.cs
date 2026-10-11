/*
Rules: E23-3-uniform-pointer-size; E23-3-uniform-pointer-representation; E23-3-pointer-value-address; E23-3-null-pointer; E23-3-null-representation
Authority: ECMA-334 7th ed 23.3
Version: 7.3
Expected: run
Stdout: OK 4
Mutate: byte* b = (byte*)p;
Into: byte* b = (byte*)(p + 1);
*/
using System;
class Program
{
    static int checks, failures;
    static void Check(bool ok, string id) { checks++; if (!ok) { failures++; Console.WriteLine("FAIL " + id); } }
    static void Main()
    {
        unsafe
        {
            int value = 61;
            int* p = &value;
            byte* b = (byte*)p;
            void* v = p;
            int* zero = null;
            Check(sizeof(int*) == sizeof(byte*) && sizeof(int*) == sizeof(void*) && sizeof(int*) == sizeof(int**), "uniform-pointer-size");
            byte* first = (byte*)&p;
            byte* second = (byte*)&b;
            byte* third = (byte*)&v;
            byte* nullBytes = (byte*)&zero;
            bool same = true, zeros = true;
            for (int i = 0; i < sizeof(int*); i++)
            {
                if (first[i] != second[i] || first[i] != third[i]) same = false;
                if (nullBytes[i] != 0) zeros = false;
            }
            Check(same, "uniform-address-representation");
            Check(zeros, "null-all-bits-zero");
            Check(*p == value, "value-represents-variable-address");
        }
        if (failures == 0) Console.WriteLine("OK " + checks);
    }
}

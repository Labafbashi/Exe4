using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
internal class MyInt
{
    public int myValue;

    public MyInt AddTen(int InputInt)
    {
        MyInt resault = new MyInt();
        resault.myValue = InputInt + 5;
        return resault;
    }
    public int ReturnValue()
    {
        int x = new int();
        x = 3;
        int y = new int();
        y = x;
        y = 4;
        return x;
    }
    public int ReturnValue2()
    {
        MyInt x = new MyInt();
        x.myValue = 3;
        MyInt y = new MyInt();
        y = x;
        y.myValue = 4;
        return x.myValue;
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        /*
         * Theory and facts
         * 1. Stack like a qeueu and it's LIFO (Last Input First Output) data structure, that means access to data only from the top part. 
         * Each datatype that work as stack, automatically remove from memory. for example:
         * STACK => [bool type][integer][double][][][][][][][]
         * Heap => [      string         classProgram            Object   ]
         * 
         * 2. Value type always hold a value that declar inandvanced for example int num=5, it's means num is integer number and hold value 5.
         * If call the num it's return 5 until change the value. But, Reference type refer/point to other place of memory or object. For example
         * Car car = new Car("BENZ") 
         */
        int num = 5;
        Console.WriteLine("Value Type num: " + num);
        Object obj = new object();
        Console.WriteLine("Reference Type obj: " + obj.GetType());
        /*
         * 3. The First method using a Value Type and it's Stack, so the variables x and y has a exact integer number.
         * But in the second method we are using an object and refer to a place of Heap (Reference Type).
         * 
         * Debug of Return Value                        Debug of Return Value 2
         * line     x     y    return                   line     x      x.myValue   y       y.myValue       return
         * ----    ---   ---  --------                  ----    ---     ---------  ---      ---------       -------
         * 15     null    -     -                       24      23f4a    null       -       -               -
         * 16       3     -     -                       25      23f4a      3        -       -               -
         * 17       3    null   -                       26      23f4a      3        65CD3   null            -
         * 18       3     3     -                       27      23f4a      3        23f4a   3               -
         * 19       3     4     -                       28      23f4a      3        23f4a   4               -
         * 20       3     4     3                       29      23f4a      4        23f4a   4               4
         * 
         */
        Console.WriteLine("Return Value (First Method): " + new MyInt().ReturnValue());
        Console.WriteLine("Return Value 2 (Second Method): " + new MyInt().ReturnValue2());
        
    }
    
}

using Exe4;
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
         * 1. Stack is like a queue and it's FILO (First Input Last Output) data structure, which means access to data only from the top part. Each datatype that works as a stack automatically removes from memory. for example:
         * STACK => [bool type][integer][double][][][][][][][]
         * Heap => [      string         classProgram            Object   ]
         * 
         * Heap is a place in the memory, any place in memory can sit and we can refer to this type of variable with a memory address. This type of variable needs a Garbage collector to remove it from memory.
         * 
         * 2. Value type always holds a value that declaration in advance for example int num=5, which means num is an integer number and holds the value 5. If we call the num it returns 5 until it changes the value. But, Reference type refers/points to another place of memory or object. For example:
         * Car car = new Car("BENZ") 
         */
        int num = 5;
        Console.WriteLine("Value Type num: " + num);
        Object obj = new object();
        Console.WriteLine("Reference Type obj: " + obj.GetType());
        /*
         * 3. The first method uses a Value Type and its Stack, so the variables x and y have an exact integer number. But in the second method, we are using an object and refer to a place of Heap (Reference Type).
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

        /* Exercise1: ExamineList()
         * 2. When a list definition, we can define a list with elements or without elements. Then in the code, with Add method, we can add an element to the list. 
         * 3. As a default when we add an element to the list at first, it automatically creates binary series (4,8,16,32,...) blocks of memory space  when they are full then it adds more new spaces again.
         * 4. It helps to speed up memory allocation, if one by one adding a new space of memory it needs a longer time to work till is created one time and used.
         * 5. When we remove element/s from the list, it couldn't release the block of memory that was allocated. Unless you have a very low amount of memory, this is a micro-optimization. Normally, there is no need to change the capacity of a List, but we can using a method TrimExcess to release a places after remove element.
         * 6.An array is a method of organizing data in a memory device. A list is a data structure that supports several operations. An array is a collection of homogenous parts, while a list consists of heterogeneous elements. Array has a static elements but List has a felexible elements.
         */
        List<int> num2 = new List<int>(); // This is a list with zero element then capacity and count is 0
        List<int> num3 = new List<int>(1) { 1, 2 }; // This is a list with two element then capacity and count is 2
        Console.WriteLine("List Size Num2: " + num2.Count() + " and the capacity of the list is: " + num2.Capacity);
        Console.WriteLine("List Size Num3: " + num3.Count() + " and the capacity of the list is: " + num3.Capacity);
        num2.Add(525); // Add new element to the num2 list and now the capacity is 4 and count is 2 
        num3.Add(52);  // Add new element to the num3 list and now the capacity is 4 and count is 3
        num3.Add(3);   // Add new element to the num3 list and now the capacity is 4 and count is 4
        num3.Add(5);   // Add new element to the num3 list and now the capacity is 8 and count is 5
        num3.Add(6);   // Add new element to the num3 list and now the capacity is 8 and count is 6
        num3.Add(7);   // Add new element to the num3 list and now the capacity is 8 and count is 7
        num3.Add(8);   // Add new element to the num3 list and now the capacity is 8 and count is 8
        num3.Add(9);   // Add new element to the num3 list and now the capacity is 16 and count is 9
        Console.WriteLine("List Size Num2 after add method: " + num2.Count() + " and the capacity of the list is: " + num2.Capacity);
        Console.WriteLine("List Size Num3 after add method: " + num3.Count() + " and the capacity of the list is: " + num3.Capacity);
        for(int i = 0; i < 32; i++) { num3.Add(i); num2.Add(i + 30); }
        // Add new 32 element to the num2 list and now the capacity is 64 and count is 33
        // Add new 32 element to the num3 list and now the capacity is 64 and count is 41
        Console.WriteLine("List Size Num2 after add method: " + num2.Count() + " and the capacity of the list is: " + num2.Capacity);
        Console.WriteLine("List Size Num3 after add method: " + num3.Count() + " and the capacity of the list is: " + num3.Capacity);
        num3.Remove(9);// Remove 1 element from the num3 list and now the capacity is 64 and count is 40
        Console.WriteLine("List Size Num3 after add method: " + num3.Count() + " and the capacity of the list is: " + num3.Capacity);
        for (var i = 0; i < 25; i++) { num3.Remove(i); }
        // Remove 24 element from the num3 list and now the capacity is 64 and count is 15
        Console.WriteLine("List Size Num3 after add method: " + num3.Count() + " and the capacity of the list is: " + num3.Capacity);
        num3.TrimExcess(); // To release a free capacity after remove elemet and now the capacity is 15 and count is 15
        Console.WriteLine("List Size Num3 after add method: " + num3.Count() + " and the capacity of the list is: " + num3.Capacity);

        /*
         * Exercise2: ExamineQueue()
         * 
         */
        ExamineQueue ica = new ExamineQueue();
        ica.AddToQueue("Kalle");
        ica.AddToQueue("Greta");
        Console.WriteLine("=========================== Add ====================================");
        ica.PrintQueue();
        ica.RemoveFromQueue();
        Console.WriteLine("============================ Remove ===================================");
        ica.PrintQueue();
        ica.AddToQueue("Stina");
        Console.WriteLine("============================ Add ===================================");
        ica.PrintQueue();
        ica.RemoveFromQueue();
        Console.WriteLine("============================ Remove ===================================");
        ica.PrintQueue();
        ica.AddToQueue("Olle");
        Console.WriteLine("============================ Add ===================================");
        ica.PrintQueue();


        /*
         * Exercise3: ExamineStack()
         * 1. Because we need a queue and first role of the queue is a FIFO (First input first output).
         * 2. 
         */
        Console.WriteLine("\n===============================================================");
        Console.Write("Please enter a String:");
        String userInput = Console.ReadLine();
        ReverseText(userInput);

        /*
         * Exercise4: CheckParenthesis()
         * 1. I using a String, because it is a array of charachter.
         */
        Console.WriteLine("\n===============================================================");
        Console.Write("Please enter a String to chech is it well formed or not add paranteses:");
        CheckParenthesis(Console.ReadLine());

    }

    private static void CheckParenthesis(string userInput)
    {
        
    }

    private static void ReverseText(string userInput)
    {
        for (int i = userInput.Length-1; i >= 0; i--)
        {
            Console.Write(userInput[i]);
        }

    }
}

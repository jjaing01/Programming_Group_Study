using System;
using System.Collections.Generic;

/*
 * iterator
 */
class iterator02
{
    static void Main()
    {
        foreach (var value in Fibonacci())
        {
            Console.WriteLine(value);
            if (value > 1000)
            {
                break;
            }
        }

        foreach (string value in Iterator())
        {
            Console.WriteLine("Received value: {0}", value);
        }

        foreach (string value in Iterator())
        {
            Console.WriteLine("Received value: {0}", value);
            if (value != null)
            {
                break;
            }
        }

        IEnumerable<string> enumerable = Iterator();
        using (IEnumerator<string> enumerator = enumerable.GetEnumerator())
        {
            while(enumerator.MoveNext())
            {
                string value = enumerator.Current;
                Console.WriteLine("Received value : {0}", value);
                if (value != null)
                {
                    break;
                }
            }
        }
    }

    static IEnumerable<int> Fibonacci()
    {
        int current = 0;
        int next = 1;

        while (true)
        {
            yield return current;
            int oldCurrent = current;
            current = next;
            next = next + oldCurrent;
        }
    }

    static IEnumerable<string> Iterator()
    {
        // return 이후에도 계속 진행
        try
        {
            Console.WriteLine("Before first yield");
            yield return "first";
            Console.WriteLine("Between yields");
            yield return "second";
            Console.WriteLine("After second yield");
        }
        finally
        {
            Console.WriteLine("In finally block");
        }
    }
}
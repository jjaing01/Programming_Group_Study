using System;
using System.Collections.Generic;
using System.Linq;

/*
 1. 다음 리스트에서 짝수만 필터링하여 출력하는 LINQ 쿼리를 작성하세요.
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

2.다음 문자열 배열에서 문자열의 길이가 5 이상인 문자열만 선택하여 대문자로 변환한 후 출력하는 LINQ 쿼리를 작성하세요
string[] words = { "apple", "banana", "grape", "orange", "watermelon" };

3. 다음 학생 객체 리스트에서 학생의 평균 나이를 계산하는 LINQ 쿼리를 작성하세요.
List<Student> students = new List<Student>
{
    new Student { Name = "Alice", Age = 20 },
    new Student { Name = "Bob", Age = 21 },

    new Student { Name = "Charlie", Age = 19 },
    new Student { Name = "David", Age = 22 },
    new Student { Name = "Eve", Age = 20 }
};

4. 다음 주어진 문자열 배열에서 각 문자열에 대해 첫 번째 문자를 선택하여 중복을 제거한 후 출력하는 LINQ 쿼리를 작성하세요.
string[] words = { "apple", "banana", "orange", "avocado", "blueberry" };

5. 다음 주어진 숫자 배열에서 최댓값을 선택하는 LINQ 쿼리를 작성하세요.
int[] numbers = { 10, 5, 8, 20, 15 };

 */

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Select a problem to solve (1-5):");
        int problemNumber;
        while (!int.TryParse(Console.ReadLine(), out problemNumber) || problemNumber < 1 || problemNumber > 5)
        {
            Console.WriteLine("Invalid input. Please enter a number between 1 and 5:");
        }

        switch (problemNumber)
        {
            case 1:
                Problem1();
                break;
            case 2:
                Problem2();
                break;
            case 3:
                Problem3();
                break;
            case 4:
                Problem4();
                break;
            case 5:
                Problem5();
                break;
        }
    }

    // Problem 1: Filter even numbers
    private static void Problem1()
    {
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var result = numbers.Where(n => n % 2 == 0);
        PrintResult(result);
    }

    // Problem 2: Filter words with length >= 5, convert to uppercase
    private static void Problem2()
    {
        string[] words = { "apple", "banana", "grape", "orange", "watermelon" };
        var result = words.Where(n => n.Length >= 5)
            .Select(n => n.ToUpper());
        PrintResult(result);
    }

    // Problem 3: Calculate average age of students
    private static void Problem3()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Alice", Age = 20 },
            new Student { Name = "Bob", Age = 21 },
            new Student { Name = "Charlie", Age = 19 },
            new Student { Name = "David", Age = 22 },
            new Student { Name = "Eve", Age = 20 }
        };

        var result = students.Where(student => student.Age >= students.Average(s => s.Age)).ToList();
        foreach (var res in result)
            Console.WriteLine(res);
    }

    // Problem 4: Select first character of each word, remove duplicates
    private static void Problem4()
    {
        string[] words = { "apple", "banana", "orange", "avocado", "blueberry" };
        var result = words.Select(n => n[0])
            .Distinct();
        PrintResult(result);
    }

    // Problem 5: Find maximum number
    private static void Problem5()
    {
        int[] numbers = { 10, 5, 8, 20, 15 };
        var result = numbers.Max();
        Console.WriteLine($"Maximum Number: {result}");
    }

    // Print result of LINQ query
    private static void PrintResult<T>(IEnumerable<T> result)
    {
        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    // Student class
    private class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return Name + (Age.ToString());
        }
    }
}

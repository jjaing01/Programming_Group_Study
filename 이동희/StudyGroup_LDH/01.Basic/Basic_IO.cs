using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    public static void Main()
    {
        int n = 10;
        double d = 3.4;

        // 1. 변수 값만 출력
        Console.WriteLine(n); // 10

        // 2. 서식에 맞추어서 출력
        Console.WriteLine("n = {0}, d = {1}", n, d);
        Console.WriteLine($"n = {n}, d = {d}");

        // 3. C# 문자열
        // regular string: "Hello"
        // 보간 문자열 (interpolated string): $"n={n}"
        // 축자 문자열 (verbatim string): @"C:\"
        Console.WriteLine("C:\\AAA\\BBB\\a.txt");
        Console.WriteLine(@"C:\AAA\BBB\a.txt");

        // 4. 입력 버퍼에서 한 문장을 입력
        string s = Console.ReadLine();

        // 5. 정수 또는 실수로 입력
        int n1 = Convert.ToInt32(s);

        // 6. 입력 버퍼에서 문자 한 개만 입력
        int n2 = Console.Read();

        // 7. Console.Read();Console.ReadLine(); 입력을 종료하려면 엔터키 눌러야 한다.
        // Console.ReadKey() -> 입력 버퍼가 아닌 키보드로 부터 직접 입력

        ConsoleKeyInfo cki = Console.ReadKey(); // 입력값을 화면에 출력
        ConsoleKeyInfo cki2 = Console.ReadKey(true); // 입력값을 화면에 출력하지 않음.
    }
}

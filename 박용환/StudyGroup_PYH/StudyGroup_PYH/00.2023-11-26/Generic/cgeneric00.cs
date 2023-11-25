using System;
using System.Collections.Generic;
using System.Linq;

// .net 7.0 부터는 다르게 사용 public enum class Season
public enum cEnum
{
    None,
    Max
}
public class myList<T> : List<T> // <T> : 타입 매개변수
{
    public void Method<TFirst>() { }

    // public void EnumMethod<cEnum>() { }
    // public void Method<TSecond>() { } // 컴파일 에러, 타입 매개변수의 이름만으로 오버로드 불가

    // public void Method<T, T>() { } // 컴파일 에러, 동일한 타입 매개변수 
}

class cgeneric00
{
    static void Main()
    {
        myList<string> mylist = new myList<string>(); // <string> : 타입 인수
        mylist.Add("PYH");

        List<int> lists = new List<int>(5); // IEnumerable<T> 를 상속받는다. 이거 말고도 상속 받는게 많은데 이건 타고 들어가서 확인
        lists.Add(6);

        foreach(int list in lists) // IEnumerable<T> 기능
        {
            Console.WriteLine(list);
        }

        var result = lists.Where(n => n > 5); // Linq 기능
        Console.WriteLine(result);
    }
}

// 제네릭이 될 수 있는 것 아닌것? 잘 이해 x
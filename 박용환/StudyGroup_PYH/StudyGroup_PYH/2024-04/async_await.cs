using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_PYH._2024_04
{
    internal class async_await
    {
        public static string BoilWater()
        {
            System.Console.WriteLine("물 끓이기 시작");
            System.Console.WriteLine("기다리는 중....");
            System.Console.WriteLine("물 끓이기 완료");

            string ret = "끓인 물";
            return ret;
        }
        public static string MakeCoffe()
        {
            // 물 끓이기
            var water = BoilWater();

            // 컵 꺼내기
            System.Console.WriteLine("컵을 꺼낸다");

            // 원두를 컵에 넣기
            System.Console.WriteLine("원두를 컵에 넣는다");

            string ret = "컵에 물을 부으면 된다.";
            return ret;
        }

        public static async Task<string> MakeCoffeAsync()
        {
            var boilingWater = BoilWaterAsync();

            System.Console.WriteLine("컵을 꺼낸다.");

            // 오버헤드를 직접 부여한다.
            var a = 0;
            for(int i = 0; i< 100_000_000;++i)
            {
                a += i;
            }

            System.Console.WriteLine("원두를 컵에 넣는다.");

            var water = await boilingWater;
            System.Console.WriteLine("물 끊임");

            return "끓인 물 붓기";
        }

        public static async Task<string> BoilWaterAsync()
        {
            System.Console.WriteLine("물 끓이기 시작");
            System.Console.WriteLine("기다리는 중....");

            // 강제로 delay
            await Task.Delay(2000);

            System.Console.WriteLine("물 끓이기 완료");

            var ret = "끓인 물";
            return ret;
        }

        // 커피 만들기
        public static void main()
        {
            var result = MakeCoffe();
            Console.WriteLine(result);

            System.Console.WriteLine(MakeCoffeAsync().Result);


            Console.WriteLine("커피 완성");
        }
    }
}

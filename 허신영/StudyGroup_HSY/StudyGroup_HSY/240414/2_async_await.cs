using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyGroup_HSY._240414
{
    internal class Program
    {
        public static string BoilWater()
        {
            System.Console.WriteLine("물 끓이기 시작");
            System.Console.WriteLine("기다리는 중...");

            // 강제 딜레이 2초.
            Task.Delay(2000).GetAwaiter().GetResult();

            System.Console.WriteLine("물 끓이기 완료");

            string ret = "끓인 물";
            return ret;
        }

        public static string MakeCoffee()
        {
            // 물 끓이기
            var water = BoilWater();

            // 컵 꺼내기
            System.Console.WriteLine("컵을 꺼낸다");

            // 원두를 컵에 넣기
            var ret = "컵에 물을 부으면 된다.";
            return ret;
        }


        public static async Task<string> MakeCoffeeAsync()
        {
            var boilingWater = BoilWaterAsync();

            System.Console.WriteLine("컵을 꺼낸다");

            // 오버헤드를 직접 부여한다.
            int a = 0;
            for (int i = 0; i < 100_000_000; ++i)
            {
                a += i;
            }

            System.Console.WriteLine("원드를 컵에 넣는다.");

            // await 거는 시점이 중요!! 함수 호출부에 걸면 동기방식과 다를 바 없다.
            var water = await boilingWater;
            return "끓인 물 붓기";
        }

        public static async Task<string> BoilWaterAsync()
        {
            System.Console.WriteLine("물 끓이기 시작");
            System.Console.WriteLine("기다리는 중...");

            // 강제 딜레이 2초.
            await Task.Delay(2000);

            System.Console.WriteLine("물 끓이기 완료");

            string ret = "끓인 물";
            return ret;
        }

        // 커피 만들기
        public static void Main(string[] args)
        {
            // 동기 방식의 커피 만들기.
            //var result = MakeCoffee();
            //Console.WriteLine(result);

            var result = MakeCoffeeAsync();
            Console.WriteLine(result.Result);

            Console.WriteLine("커피 완성");
        }
    }
}

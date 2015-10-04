/*
ゲームのキャラとかアイテムとかなんかいろんなものをクラスで表現する。
たとえば人間がいて、体力、攻撃力、防御力があるとする。
アイテムに回復薬があるとすると、こんなコードになる。
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pattern01
{

    public class Human
    {
        public int Life { get; set; }
        public int Kougeki { get; set; }
        public int Bougyo { get; set; }
    }

    public class KaifukuItem
    {
        public void Apply(Human human) { human.Life += 100; }
    }

    public class App
    {
        public static void Test()
        {
            var human = new Human();// 人間を生成
            var kaifukuItem = new KaifukuItem();//アイテム生成
            Console.WriteLine(human.Life);//回復前。0
            kaifukuItem.Apply(human);
            Console.WriteLine(human.Life);//回復した。100
        }
    }


}
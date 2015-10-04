// クラスを生成するパラメータ。
// 2015/10/04 yamaya takeshi

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

namespace ClassParam
{
    // 人間
    class Human
    {
        public int Life { get; set; }
        public int Kougeki { get; set; }
        public int Bougyo { get; set; }
        public override string ToString()
        {
            return 
                "Life:" + Life + "," +
                "Kougeki:" + Kougeki + "," +
                "Bougyo:" + Bougyo;
        }
    }

    // 回復アイテム
    class KaifukuItem
    {
        public void Apply(Human human) { human.Life += 100; }
    }


    // テスト
    class Program
    {
        static void Log( string message )
        {
            Console.WriteLine( message );
        }
        static void Main(string[] args)
        {
            Log( "人間を生成" );
            var human = new Human();
            Log( human.ToString() );
            Log( "回復アイテム生成" );
            var kaifukuItem = new KaifukuItem();
            Log( "回復アイテム使用" );
            kaifukuItem.Apply(human);
            Log( human.ToString() );
        }

    }
}



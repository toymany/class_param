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

        // アイテムを保持
        private List<Item> items = new List<Item>();
        public void AddItem(Item item) { items.Add(item); }

        // アイテムを使う
        public void UseItem(int index)
        {
            items[index].Apply(this);
            items.Remove(items[index]);
        }

        // ダンプ
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append( "Life:" + Life + "," );
            sb.Append( "Kougeki:" + Kougeki + "," );
            sb.Append( "Bougyo:" + Bougyo + "\n" );

            if (items.Any() ) {
                sb.Append( "Items\n" );
                foreach( var i in items ) {
                    sb.Append( i.ToString() + "\n" );
                }
            }
            return sb.ToString();
        }

    }

    // アイテム抽象
    abstract class Item
    {
        public abstract void Apply(Human human);
    }

    // 回復アイテム
    class KaifukuItem : Item
    {
        public override void Apply(Human human) { human.Life += 100; }
    }
    // 攻撃力アップ
    class KougekiItem : Item
    {
        public override void Apply(Human human) { human.Kougeki += 100; }
    }

    // 防御力アップ
    class BougyoItem : Item
    {
        public override void Apply(Human human) { human.Bougyo += 100; }
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

            {
                Log( "回復" );
                var item = new KaifukuItem();
                Log( item.ToString() + ".Apply" );
                item.Apply(human);
                Log( human.ToString() );
            }

            {
                Log( "攻撃UP" );
                var item = new KougekiItem();
                Log( item.ToString() + ".Apply" );
                item.Apply(human);
                Log( human.ToString() );
            }

            {
                Log( "防御UP" );
                var item = new BougyoItem();
                Log( item.ToString() + ".Apply" );
                item.Apply(human);
                Log( human.ToString() );
            }

            //アイテム取得
            Log( "回復アイテム取得" );
            human.AddItem(new KaifukuItem());//回復
            Log( human.ToString() );

            Log( "攻撃Upアイテム取得" );
            human.AddItem(new KougekiItem());//
            Log( human.ToString() );

            Log( "防御Upアイテム取得" );
            human.AddItem(new BougyoItem()); //防御
            Log( human.ToString() );


            Log( "回復薬を使う" );
            human.UseItem(0);//
            Log( human.ToString() );

            Log( "攻撃薬を使う" );
            human.UseItem(0);//
            Log( human.ToString() );

            Log( "防御薬を使う" );
            human.UseItem(0);//
            Log( human.ToString() );


        }

    }
}



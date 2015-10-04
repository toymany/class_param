//回復薬はさらに3種類あったとする。単純にクラスを増やすとこうなる。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pattern06
{
     abstract class Item
    {
        public abstract void Apply(Human human);
    }

     class Human
    {
        public int Life { get; set; }
        public int Kougeki { get; set; }
        public int Bougyo { get; set; }

        private List<Item> items = new List<Item>();

        public void AddItem(Item item) { items.Add(item); }
        public void UseItem(int index)
        {
            items[index].Apply(this);
            items.Remove(items[index]);
        }

    }

    //だいぶ長くなってきたし、クラスをいちいち作るのはしんどいのでコンストラクタにパラメータを渡す。

    class KaifukuItem : Item
    {
        private int value;
        public KaifukuItem(int value)
        {
            this.value = value;
        }
        public override void Apply(Human human) { human.Life += value; }
    }

    class KougekiItem : Item
    {
        public override void Apply(Human human) { human.Kougeki += 100; }
    }

    class BougyoItem : Item
    {
        public override void Apply(Human human) { human.Bougyo += 100; }
    }



    // アイテムをマップ上に配置することになったので、enumで指定する。
    enum ItemKind
    {
        KaifukuA,
        KaifukuB,
        KaifukuC,

        Kougeki,
        Bougyo,
    }

    // アイテムのEnumでインスタンスを生成するファクトリーが欲しくなる
    class ItemFactory
    {
        public Item CreateItem(ItemKind kind)
        {
            Item item = null;
            switch (kind)
            {
                case ItemKind.KaifukuA: item = new KaifukuItem(100); break;
                case ItemKind.KaifukuB: item = new KaifukuItem(200); break;
                case ItemKind.KaifukuC: item = new KaifukuItem(300); break;
                case ItemKind.Kougeki: item = new KougekiItem(); break;
                case ItemKind.Bougyo: item = new BougyoItem(); break;
            }
            return item;
        }
    }


    public class App
    {
        public static void Test()
        {
            var human = new Human();// 人間を生成
            var itemFactory = new ItemFactory();
            human.AddItem(itemFactory.CreateItem(ItemKind.KaifukuA));
            human.AddItem(itemFactory.CreateItem(ItemKind.KaifukuB));
            human.AddItem(itemFactory.CreateItem(ItemKind.KaifukuC));
            human.AddItem(itemFactory.CreateItem(ItemKind.Kougeki));
            human.AddItem(itemFactory.CreateItem(ItemKind.Bougyo));

            human.UseItem(0);
            human.UseItem(0);
            human.UseItem(0);
            human.UseItem(0);
            human.UseItem(0);

        }
    }



}//Pattern06

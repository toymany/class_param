//回復薬はさらに3種類あったとする。単純にクラスを増やすとこうなる。
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pattern05
{
    public abstract class Item
    {
        public abstract void Apply(Human human);
    }

    public class Human
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

    class KaifukuItem : Item
    {
        public override void Apply(Human human) { human.Life += 100; }
    }

    class KougekiItem : Item
    {
        public override void Apply(Human human) { human.Kougeki += 100; }
    }

    class BougyoItem : Item
    {
        public override void Apply(Human human) { human.Bougyo += 100; }
    }

    class App
    {
        public static void Test()
        {
            var human = new Human();

            //アイテム取得
            human.AddItem(new KaifukuItem());//回復
            human.AddItem(new KougekiItem());//攻撃
            human.AddItem(new BougyoItem()); //防御

            //使う
            human.UseItem(0);//回復薬を使う
            human.UseItem(0);//攻撃薬を使う
            human.UseItem(0);//防御薬を使う
        }
    }

}//Pattern05

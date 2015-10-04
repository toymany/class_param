//さらに攻撃力アップと、防御力アップのアイテムが追加された
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Pattern02
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

    public class KougekiItem
    {
        public void Apply(Human human) { human.Kougeki += 100; }
    }

    public class BougyoItem
    {
        public void Apply(Human human) { human.Bougyo += 100; }
    }

    public class App
    {
        public static void Test()
        {
            var human = new Human();
            var kaifukuItem = new KaifukuItem();
            kaifukuItem.Apply(human);
            Console.WriteLine(human.Life);//回復した。100

            var kougekiItem = new KougekiItem();
            kougekiItem.Apply(human);

            var bougyoItem = new BougyoItem();
            bougyoItem.Apply(human);
        }
    }

}//Pattern02
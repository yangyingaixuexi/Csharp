using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class CangKu
    {
        //存储货物
        //1、不易于添加
        //List<SamSung> listSam = new List<SamSung>();
        //2、不易于查找
        //List<ProductFather> list = new List<ProductFather>();
        //3、先创建货架，再在货架上添加货物 
        List<List<ProductFather>> list = new List<List<ProductFather>>();
        //list[0]添加电脑
        //list[0]添加手机
        //list[0]添加香蕉
        //list[0]添加酱油
        //特别多的时候用循环，反正都一样的
        /// <summary>
        /// 在创建仓库对象的时候，向仓库中添加货架
        /// </summary>
        public CangKu()
        {   //添加泛型集合类型
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());
            list.Add(new List<ProductFather>());

        }
        /// <summary>
        /// 进货
        /// </summary>
        /// <param name="strType">货物的类型</param>
        /// <param name="count">货物的数量</param>
        public void JinPros(string strType, int count)
        {
            for (int i = 0; i < count; i++)
            {
                switch (strType)
                {
                    case "Acer":
                        list[0].Add(new Acer(Guid.NewGuid().ToString(), 3000, "弘基电脑"));
                        break;
                    case "SamSung":
                        list[1].Add(new SamSung(Guid.NewGuid().ToString(), 4000, "棒子手机"));
                        break;
                    case "JiangYou":
                        list[2].Add(new JiangYou(Guid.NewGuid().ToString(), 15, "酱油"));
                        break;
                    case "Banana":
                        list[3].Add(new Banana(Guid.NewGuid().ToString(), 4, "香蕉"));
                        break;

                }
            }
        }

        /// <summary>
        /// 取货
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="count"></param>
        public ProductFather[] QuPros(string strType, int count)
        {
            //List<ProductFather> list1 = new List<ProductFather>();

            //因为数量确定为count，所以用数组
            ProductFather[] pros = new ProductFather[count];
            for (int i = 0; i < count; i++)
            {
                switch (strType)
                {
                    case "Acer":
                        if (list[0].Count != 0)
                        {
                            pros[i] = list[0][0];//每次都拿货架list[0]的第一个，取后自动补偿（只是读取，后面需要删除）
                            list[0].RemoveAt(0);//删除第一个
                            //list1.Add(list[0][0]);
                        }
                        break;
                    case "SamSung":
                        if (list[1].Count != 0)
                        {
                            pros[i] = list[1][0];
                            list[1].RemoveAt(0);
                        }
                        break;
                    case "JiangYou":
                        if (list[2].Count != 0)
                        {
                            pros[i] = list[2][0];
                            list[2].RemoveAt(0);
                        }
                        break;
                    case "Banana":
                        if (list[3].Count != 0)
                        {
                            pros[i] = list[3][0];
                            list[3].RemoveAt(0);
                        }
                        break;
                }
            }
            return pros;
        }

        /// <summary>
        /// 向用户展示货物
        /// </summary>
        public void ShowPros()
        {
            //item表示货架
            foreach(var item in list)
            {
                //item表示货架，item[0]表示商品，因此可以调用item[0].Name商品的名字和价格
                //item[0].Name每个货架上第一个货品的名字（因为每个货架上物品的名字都是一样的，所以取了第一个）
                //item.Count表示每个货架上的数量，即同一种商品的数量，需要注意的是物品中已经没有count属性了
                Console.WriteLine("我们超市有{0}，数量是{1}个，每个{2}元", item[0].Name,item.Count,item[0].Price);
            }
        }
    }
}

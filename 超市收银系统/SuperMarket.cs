using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class SuperMarket
    {
        //通过创建对象，添加货架
        CangKu ck = new CangKu();
        //用于存储小票信息
        List<object> list1 = new List<object>();
        /// <summary>
        /// 创建超市对象，给货架添加物品
        /// </summary>
        public SuperMarket()
        {
            ck.JinPros("Acer", 1000);
            ck.JinPros("SamSung", 1000);
            ck.JinPros("JiangYou", 1000);
            ck.JinPros("Banana", 1000);
        }
        /// <summary>
        /// 与用户交互的过程
        /// </summary>
        public void AskBuying()
        {
            string strType = null;
            int count = 0;
            bool flag = false;
            List<ProductFather[]> list = new List<ProductFather[]>();
            ProductFather[] pros = null;
            Console.WriteLine("欢迎光临，请问需要什么\r\n我们有Acer、SamSung、JiangYou、Banana");
            do
            {
                if (flag)
                {
                    Console.WriteLine("请继续输入\r\n我们有Acer、SamSung、JiangYou、Banana");
                }
                strType = Console.ReadLine();
                Console.WriteLine("您需要多少");
                count = Convert.ToInt32(Console.ReadLine());
                //去仓库取货
                pros = ck.QuPros(strType, count);
                list.Add(pros);
                flag = true;
                Console.WriteLine("是否结束输入：是/否");
                strType = Console.ReadLine();
            } while (strType != "是");
            //计算价钱
            double realMoney = GetMoney(list);
            Console.WriteLine("应付{0}元", realMoney);
            Console.WriteLine("请选择打折方式：1-不打折，2-打九折，3-满300减50");
            string input = Console.ReadLine();
            //通过简单那工厂的设计模式，获得一个打折对象
            Discount discount = GetTotalMoney(input);
            double totalMoney = discount.GetTotalMoney(realMoney);
            Console.WriteLine("实际应付{0}元", totalMoney);
            //List<object> list = new List<object>();
            list1.Add("您购买的商品是：" + strType);
            list1.Add("您购买的数量是：" + count);
            list1.Add("应付：" + realMoney);
            list1.Add("实付：" + totalMoney);
            string path = @"C:\Users\13729\Desktop\123.txt";
            using (FileStream fswrite = new FileStream(path, FileMode.Append, FileAccess.Write))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    byte[] buffer = Encoding.Default.GetBytes(list[i].ToString() + "\r\n");
                    fswrite.Write(buffer, 0, buffer.Length);
                }
            }
            Console.WriteLine("OK");
            Console.ReadKey();

        }
        /// <summary>
        /// 计算总价钱，因为货物可能有很多种，所以不能用单价乘以数量
        /// </summary>
        /// <param name="list"></param>
        /// <param name="pros"></param>
        /// <returns></returns>
        public double GetMoney(List<ProductFather[]> list)
        {
            double realMoney = 0;
            //realMoney=pros[0].price*pros.length//只能适用于买一种物品
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list[i].Length; j++)
                {
                    realMoney += list[i][j].Price;
                }
            }
            return realMoney;
        }
        /// <summary>
        /// 根据用户的选择返回一个打折对象
        /// </summary>
        /// <param name="realMoney">用户的选择</param>
        /// <returns>返回父类对象，但是里面装的是子类对象</returns>
        public Discount GetTotalMoney(string input)
        {
            Discount dc = null;
            switch (input)
            {
                case "1":
                    dc = new DiscountNone();
                    break;
                //此时需要GET
                case "2":
                    dc = new Discount1(0.9);
                    break;
                case "3":
                    dc = new Discount2(300, 50);
                    break;
            }
            return dc;
        }
        public void ShowPros()
        {
            ck.ShowPros();
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建超市对象
            SuperMarket sm = new SuperMarket();
            //查看仓库
            sm.ShowPros();
            //与用户交互
            sm.AskBuying();
            //string s = "你好呀";
            //string path = @"C:\Users\13729\Desktop\123.txt";
            //using (FileStream fswrite = new FileStream(path, FileMode.Append, FileAccess.Write))
            //{
            //    byte[] buffer = Encoding.Default.GetBytes(s);
            //    fswrite.Write(buffer, 0, buffer.Length);

            //}
            //Console.WriteLine("OK");
            //Console.ReadKey();
            Console.ReadKey();

        }
        
    }
}

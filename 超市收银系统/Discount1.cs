using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    /// <summary>
    /// 按折扣率打折
    /// </summary>
    class Discount1:Discount
    {
        //每次的打折率可能不一样，这里定义为Rate
        //自动属性
        public double Rate
        {
            get;
            set;
        }
        //构造函数，新建对象的时候传入0.95
        public Discount1(double rate)
        {
            this.Rate = rate;
        }
        /// <summary>
        /// 按照一定的折扣率打折
        /// </summary>
        /// <param name="realMoney"></param>
        /// <returns></returns>
        public override double GetTotalMoney(double realMoney)
        {
            return realMoney * this.Rate;
        }
    }
}

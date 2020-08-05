using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    abstract class Discount
    {
        /// <summary>
        /// 计算打折后应付多少钱
        /// </summary>
        /// <param name="realMoney">折前价</param>
        /// <returns>折后价</returns>
        public abstract double GetTotalMoney(double realMoney);
    }
}

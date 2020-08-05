using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超市收银系统
{
    class Discount2 : Discount
    {
        //满m送n

        //满的钱数
        private double m;
        public double M
        {
            get
            {
                return m;
            }

            set
            {
                m = value;
            }
        }
        //减的钱数
        public double N
        {
            get
            {
                return n;
            }

            set
            {
                n = value;
            }
        }

        private double n;
        public Discount2(double m,double n)
        {
            this.M = m;
            this.N= n;
        }
        /// <summary>
        /// 满减，注意满了多少个500，要强转
        /// </summary>
        /// <param name="realMoney"></param>
        /// <returns></returns>

        public override double GetTotalMoney(double realMoney)
        {
            //
            if (realMoney >= this.M)
            {
                return realMoney - (int)(realMoney/this.M)*this.N;
            }else
            {
                return realMoney - (int)(realMoney / this.M)*this.N;
            }
        }
    }
}

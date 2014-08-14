using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nPOSProj.Conf
{
    class Rgx
    {
        private String reg;
        public Rgx() { }
        public String Visa()
        {
            reg = "^(?:(?<Visa>4\\d{3})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<Amex>3[47]\\d{2}))([ -]?)(?(DinersClub)(?:\\d{6}\\1\\d{4})|(?(Amex)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";
            return reg;
        }
        public String Mastercard()
        {
            reg = "^(?:(?<MasterCard>5[1-5]\\d{2})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<Amex>3[47]\\d{2}))([ -]?)(?(DinersClub)(?:\\d{6}\\1\\d{4})|(?(Amex)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";
            return reg;
        }
        public String Amount()
        {
            reg = "^\\$?(\\d{1,3},?(\\d{3},?)*\\d{3}(.\\d{0,3})?|\\d{1,3}(.\\d{2})?)$"; //BINGO
            return reg;
        }
    }
}
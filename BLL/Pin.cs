using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Pin
    {
        private int pinNo;

        public int getPin()
        {
            //add validation logic if needed
            return pinNo;
        }
       
        public void setPin(int pinNo)
        {
            
            this.pinNo = pinNo;
        }



    }
}

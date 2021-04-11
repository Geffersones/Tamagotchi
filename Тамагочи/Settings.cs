using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Тамагочи
{
    class Settings
    {
        public static Scale eat;
        public static Scale sleep;
        public static Scale happy;
        public static Scale clear;
        public static Scale HP;
        
        public static int add;
        public static int dif;

        public Settings()
        {
            eat = new Scale (100);
            sleep = new Scale (100);
            happy = new Scale (100);
            clear = new Scale (100);
            HP = new Scale (100);
            
            add = 16;
            dif = 8;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
   public static class Manager  
    {
        

        public static void AddSubToList(Model.Subscriber Obj)
        {
            Test.MainWindow.AddToList(Obj);
        }

        public static void RemoveFromList(Model.Subscriber Obj)
        {
            Test.MainWindow.RemoveFromList(Obj);
        }

        public static void EditSub(Model.Subscriber Obj)
        { 
        
        
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
   public class Manager  
    {
         List<Subscriber> SubscribersList = new List<Subscriber>();

        public void AddSubToList(Subscriber Obj)
        {
            SubscribersList.Add(Obj);
            //Test.MainWindow.AddToList(Obj);
        }

        public void RemoveFromList(int index)
        {
            SubscribersList.RemoveAt(index);
           // Test.MainWindow.RemoveFromList(Obj);
        }

        public List<Subscriber> getSubscribersList()
        {
            return this.SubscribersList;
        }

        public static void EditSub(Model.Subscriber Obj)
        { 
        
        
        }



    }
}

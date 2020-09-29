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
        }

        public void RemoveFromList(int index)
        {
            SubscribersList.RemoveAt(index);
        }

        public List<Subscriber> getSubscribersList()
        {
            return SubscribersList;
        }

        public static void EditSub(Model.Subscriber Obj)
        { 
        
        
        }



    }
}

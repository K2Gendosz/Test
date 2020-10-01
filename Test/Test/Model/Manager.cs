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

        public void EditSub(int index, Subscriber obj)
        {
            SubscribersList[index] = obj;
        }

        public void setSubscriberList(List<Subscriber> newSubList)
        {
            this.SubscribersList = newSubList;
        }



    }
}

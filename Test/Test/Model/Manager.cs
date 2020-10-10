using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Model
{
    public class Manager
    {
       private List<Subscriber> SubscribersList = new List<Subscriber>();
       

        public void AddSubToList(Subscriber Obj)
        {
            SubscribersList.Add(Obj);
        }

        public void RemoveFromList(Subscriber sub)
        {
            SubscribersList.Remove(sub);
            MainWindow.BackToList();
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
            SubscribersList.Clear();
            this.SubscribersList = newSubList;
        }

        public List<Subscriber> Search(string text)
        {
            if (text != "Search" || text != "")
            {
                List<Subscriber> FoundSubs = new List<Subscriber>();
                foreach (Subscriber item in SubscribersList)
                {

                    if (item.FirstName.ToUpper().Contains(text.ToUpper()))
                    {
                        FoundSubs.Add(item);
                        continue;
                    }
                    else if (item.SecondName.ToUpper().Contains(text.ToUpper()))
                    {
                        FoundSubs.Add(item);
                        continue;           
                    }

                    else if (item.City.ToUpper().Contains(text.ToUpper()))
                    {
                        FoundSubs.Add(item);
                        continue;
                    }
                    else if (item.PostalCode.ToUpper().Contains(text.ToUpper()))
                    {
                        FoundSubs.Add(item);
                        continue;
                    }
                    else if (item.StreetAddress.ToUpper().Contains(text.ToUpper()))
                    {
                        FoundSubs.Add(item);
                        continue;
                    }
                    else if (item.Sex.ToUpper() == text.ToUpper())
                    {
                        FoundSubs.Add(item);
                        continue;
                    }
                    else if (item.HouseNumber.ToUpper().Contains(text.ToUpper()))
                    {
                        FoundSubs.Add(item);
                        continue;
                    }
                    else if (item.Age.ToString().Contains(text))
                    {
                        FoundSubs.Add(item);
                        continue;
                    }


                }
                return FoundSubs;
            }
            return SubscribersList;
        }

    }
}
            
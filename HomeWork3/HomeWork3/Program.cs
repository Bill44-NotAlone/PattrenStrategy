using System;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionClass collection = new CollectionClass();
            collection.Add(1);
            collection.Add(2);
            collection.Add(3);
            collection.Add(4);
            Console.WriteLine(collection.GetIndex(4));
        }
    }

    class CollectionClass
    {
        class Collection
        {
            public int content;
            public Collection NextCollection;
        }
        Collection initialvalue = null;
        
        public void Add(int element)
        {
            Collection collection = new Collection();
            collection.content = element;
            if(initialvalue == null)
            {
                initialvalue = collection;
                return;
            }
            Collection initialvalue1 = initialvalue;
            while (initialvalue1.NextCollection != null)
            {
                initialvalue1 = initialvalue1.NextCollection;
            }
            initialvalue1.NextCollection = collection;
            return;
        }
        public int GetIndex(int element)
        {
            Collection initialvalue1 = initialvalue;
            int i = 0;
            while(element != initialvalue1.content)
            {
                if(initialvalue1.NextCollection == null)
                {
                    return (-1);
                }
                initialvalue1 = initialvalue1.NextCollection;
                i = i + 1;
            }
            return (i);
        }
        //public int
    }
}

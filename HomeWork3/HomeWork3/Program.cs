using System;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionClass collection = new CollectionClass();
            for (int i = 0; i < 16; i++) collection.Add(i + 1);
            Console.WriteLine(collection.GetIndex(4));
            Console.WriteLine(collection.GetElement(14));

            for (int i = 0; i < 16; i++) Console.Write(collection.GetElement(i));
            collection.RemoveAt(5);
            Console.WriteLine();
            for (int i = 0; i < 15; i++) Console.Write(collection.GetElement(i));
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
        public int GetElement(int index)
        {
            Collection initialvalue1 = initialvalue;
            for (int i = 0; i < index; i++)
            {
                initialvalue1 = initialvalue1.NextCollection;
            }
            return (initialvalue1.content);
        }
        public void RemoveAt(int index)
        {
            Collection initialvalue1 = initialvalue;
            for (int i = 0; i < index - 1; i++) initialvalue1 = initialvalue1.NextCollection;
            Collection initialvalue2 = initialvalue1.NextCollection;
            Collection initialvalue3 = initialvalue2.NextCollection;
            initialvalue1.NextCollection = initialvalue3;
        }
    }
}

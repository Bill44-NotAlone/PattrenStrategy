using System;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionClass<string> collection = new CollectionClass<string>();
            collection.Add("w");
            collection.Add("w");
            collection.Add("s");
            collection.Add("3");
            Console.WriteLine(collection.GetElement(0));
            Console.WriteLine(collection.GetElement(1));
            Console.WriteLine(collection.GetElement(2));
        }
    }

    class CollectionClass<Type>
    {
        class Collection
        {
            public Type content;
            public Collection NextCollection;
        }
        Collection initialvalue;
        public void Add(Type value)
        {
            Collection collection = new Collection();
            collection.content = value;
            if (initialvalue == null) 
            {
                initialvalue = collection;
                return;
            }
            while (initialvalue.NextCollection != null) initialvalue = initialvalue.NextCollection;
            initialvalue.NextCollection = collection;
        }
        public Type GetElement(int index)
        {
            Collection initialvalue1 = initialvalue;
                for (int i = 0; i < index; i++)
                {
                    if (initialvalue1.NextCollection != null)
                    {
                        initialvalue1 = initialvalue1.NextCollection;
                    }
                }
                return (initialvalue1.content);
        }
        public void RemoveAt(int index)
        {
            Collection initialvalue1 = initialvalue;
            for (int i = 0; i < index -1 ; i++)
            {
                if (initialvalue1.NextCollection != null)
                {
                    initialvalue1 = initialvalue1.NextCollection;
                }
            }
            Collection initialvalue2 = initialvalue1.NextCollection;
            initialvalue1.NextCollection = initialvalue1.NextCollection.NextCollection;
            initialvalue2.NextCollection = null;
        }
    }
}

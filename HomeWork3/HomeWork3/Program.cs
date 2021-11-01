using System;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionClass<int> collection1 = new CollectionClass<int>();
            for (int i = 0; i < 16; i++) collection1.Add(i + 1);
            Console.WriteLine(collection1.GetIndex(3));
            for (int i = 0; i < 16; i++) Console.Write(collection1.GetElement(i));
            collection1.RemoveAt(0);
            Console.WriteLine();
            Console.WriteLine(collection1.GetElement(3).GetType());
            for (int i = 0; i < 15; i++) Console.Write(collection1.GetElement(i));

            CollectionClass<string> collection2 = new CollectionClass<string>();
            for (int i = 0; i < 16; i++) collection2.Add((i + 1).ToString());
            Console.WriteLine(collection2.GetIndex(6.ToString()) + " ");
            Console.WriteLine(collection2.GetElement(14));
            for (int i = 0; i < 16; i++) Console.Write(collection2.GetElement(i));
            collection2.RemoveAt(15);
            Console.WriteLine();
            Console.WriteLine(collection2.GetElement(3).GetType());
            for (int i = 0; i < 15; i++) Console.Write(collection2.GetElement(i));
        }
    }

    class CollectionClass<Type>
    {
        class Collection
        {
            public Type content;
            public Collection NextCollection;
        }
        Collection initialvalue = null;
        
        public void Add(Type element)
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
        public int GetIndex(Type element)
        {
            Collection initialvalue1 = initialvalue;
            int i = 0;
            while(element.GetType() != initialvalue1.content.GetType())
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
        public Type GetElement(int index)
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
            if (index == 0) initialvalue = initialvalue.NextCollection;
            else
            {
                Collection initialvalue1 = initialvalue;
                for (int i = 0; i < index - 1; i++) initialvalue1 = initialvalue1.NextCollection;
                Collection initialvalue2 = initialvalue1.NextCollection;
                Collection initialvalue3 = initialvalue2.NextCollection;
                initialvalue1.NextCollection = initialvalue3;
            }
        }
    }
}

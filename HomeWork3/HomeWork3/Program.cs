using System;

namespace HomeWork3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            CollectionClass<int> collection1 = new CollectionClass<int>();
            //for (int i = 0; i < 16; i++) collection1.Add(i + 1);
            Console.WriteLine(collection1.Length);
            //Console.WriteLine(collection1.GetElement(3));
            //Console.WriteLine(collection1.GetIndex(12));
            collection1.RemoveAt(random.Next(32));
            //for (int i = 0; i < 15; i++) Console.Write(collection1.GetElement(i));
            Console.WriteLine();
            Console.WriteLine(collection1.Length);

            CollectionClass<string> collection2 = new CollectionClass<string>();
            for (int i = 0; i < 16; i++) collection2.Add((i + 1).ToString());
            Console.WriteLine();
            //Console.WriteLine(collection2.GetElement(3));
            //Console.WriteLine(collection2.GetIndex("15"));
            collection2.RemoveAt(random.Next(32));
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
        private int length = 0;

        public void Add(Type element)
        {
            length = length + 1;
            Collection collection = new Collection();
            collection.content = element;
            if (initialvalue == null)
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
            while (element.ToString() != initialvalue1.content.ToString())
            {
                if (initialvalue1.NextCollection == null)
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
            if (length >= index & 0 <= index)
            {
                for (int i = 0; i < index; i++)
                {
                    initialvalue1 = initialvalue1.NextCollection;
                }
                return (initialvalue1.content);
            }
            else throw new Exception("Значение индекса не соответствует длине массива! :(");
        }
        public void RemoveAt(int index)
        {
            if (length >= index & 0 <= index & initialvalue != null)
            {
                length = length - 1;
                if (index == 0) initialvalue = initialvalue.NextCollection;
                else
                {
                    Collection initialvalue1 = initialvalue;
                    for (int i = 0; i < index - 1; i++) initialvalue1 = initialvalue1.NextCollection;
                    Collection initialvalue2 = initialvalue1.NextCollection;
                    initialvalue2 = initialvalue2.NextCollection;
                    initialvalue1.NextCollection = initialvalue2;
                }
            }
            //else throw new Exception("Значение индекса не соответствует длине массива! :(");
        }
        public int Length
        {
            get { return length; }
        }
    }
}

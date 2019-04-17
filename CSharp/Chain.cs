namespace com.dnene.josephus
{
    public class Chain
    {
        private Person first = null;

        public Chain(int size)
        {
            Person last = null;
            Person current = null;
            for (int i = 0 ; i < size ; i++)
            {
                current = new Person(i);
                if (first == null) first = current;
                if (last != null)
                {
                    last.Next = current;
                    current.Prev = last;
                }
                last = current;
            }
            first.Prev = last;
            last.Next = first;
        }

        public Person Kill(int nth)
        {
            Person current = first;
            int shout = 1;
            while(current.Next != current)
            {
                shout = current.Shout(shout, nth);
                current = current.Next;
            }
            first = current;
            return current;
        }

        public Person First => first;


    }

    public class Person
    {
        int count;
        private Person prev = null;
        private Person next = null;

        public Person(int count)
        {
            this.count = count;
        }

        public int Shout(int shout, int deadif)
        {
            if (shout < deadif) return (shout + 1);
            this.Prev.Next = Next;
            this.Next.Prev = Prev;
            return 1;
        }

        public int Count => count;

        public Person Prev
        {
            get => prev;
            set => prev = value;
        }
        public Person Next
        {
            get => next;
            set => next = value;
        }
    }

}

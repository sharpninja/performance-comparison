package Java;

public class Chain
{
    private static int ITER = 10000;
    private Person first = null;
    private static Chain[] chains = new Chain[ITER];
    private static Chain[] target = new Chain[ITER];

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
                last.setNext(current);
                current.setPrev(last);
            }
            last = current;
        }
        first.setPrev(last);
        last.setNext(first);
    }

    public Person kill(int nth)
    {
        Person current = first;
        int shout = 1;
        while(current.getNext() != current)
        {
            shout = current.shout(shout, nth);
            current = current.getNext();
        }
        first = current;
        return current;
    }

    public Person getFirst()
    {
        return first;
    }
    public static void main(String[] args)
    {
        long start = System.nanoTime();

        for (int i = 0 ; i < ITER ; i++)
        {
            Chain chain = new Chain(40);
            chain.kill(3);
            chains[i] = chain;
        }

        // Ensure JIT doesn't optimize out the first loop
        for (int i = 0; i < ITER; ++i)
        {
            target[i] = chains[i];
        }

        long end = System.nanoTime();

        System.out.println(GetLastChain());

        double elapsedTime = (end - start);
        System.out.println("Elapsed time: " + elapsedTime + " nanoseconds");

        System.out.println("Time per iteration = " + elapsedTime / ITER + " nanoseconds.");
    }

    private static Chain GetLastChain()
    {
        return target[ITER - 1];
    }
}

class Chain
{
    constructor(size)
    {
        var last;
        var current;
        for (var i = 0 ; i < size ; i++)
        {
            current = new Person(i);
            if (typeof first === 'undefined')
                this.first = current;
            if (typeof last != 'undefined')
            {
                last.setNext(current);
                current.setPrev(last);
            }
            last = current;
        }
        this.first.setPrev(last);
        last.setNext(this.first);
    }

    kill(nth)
    {
        var current = this.first;
        var shout = 1;
        while(current.getNext() !== current)
        {
            shout = current.shout(shout, nth);
            current = current.getNext();
        }
        this.first = current;
        return current;
    }
}

class Person
{
    constructor(count)
    {
        this.count = count;
    }

    shout(shout, deadif)
    {
        if (shout < deadif) return (shout + 1);
        this.getPrev().setNext(this.getNext());
        this.getNext().setPrev(this.getPrev());
        return 1;
    }

    getCount()
    {
        return this.count;
    }

    getPrev()
    {
        return this.prev;
    }

    setPrev(prev)
    {
        this.prev = this.prev;
    }

    getNext()
    {
        return this.next;
    }

    setNext(next)
    {
        this.next = next;
    }
}

var ITER = 100000;
var start = process.hrtime();
for (var i = 0 ; i < ITER ; i++)
{
    const chain = new Chain(40);
    chain.kill(3);
}
var end = process.hrtime(start);
console.info('Execution time (hr): %ds %dms', end[ 0 ], end[ 1 ] / 1000000)

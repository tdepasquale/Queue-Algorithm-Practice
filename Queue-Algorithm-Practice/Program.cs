using System;
using System.Collections;

namespace Queue_Algorithm_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new PriorityQueue(7);

            queue.enqueue(3);
            queue.enqueue(7);
            queue.enqueue(2);
            queue.enqueue(5);
            queue.enqueue(6);
            queue.enqueue(1);

            Console.WriteLine(queue.remove());
            Console.WriteLine(queue.remove());
            Console.WriteLine(queue.remove());
            Console.WriteLine(queue.remove());
            Console.WriteLine(queue.remove());
            Console.WriteLine(queue.remove());
        }

        public static void reverse(Queue queue)
        {
            var stack = new Stack();
            while(queue.Count > 0) stack.Push(queue.Dequeue());
            while (stack.Count > 0) queue.Enqueue(stack.Pop());
        }

        class ArrayQueue
        {
            int[] data;
            int front = 0, back = -1, count = 0, capacity;

            public ArrayQueue(int capacity)
            {
                this.capacity = capacity;
                data = new int[capacity];
            }

            public void Enqueue(int item)
            {
                if (isFull()) throw new InsufficientMemoryException();

                if (back == capacity - 1)
                {
                    data[0] = item;
                    back = 0;
                }
                else
                {
                    data[++back] = item;
                }

                count++;
            }

            public int Dequeue()
            {
                if (isEmpty()) throw new InvalidOperationException();

                var output = data[front];
                
                if (front == capacity - 1) front = 0;
                else front++;

                count--;

                return output;
            }

            public bool isEmpty()
            {
                return count == 0;
            }

            public bool isFull()
            {
                return count == 5;
            }

            public int peek()
            {
                return data[front];
            }

            public void print()
            {
                var counter = 0; 
                var offset = 0;
                while(counter < count)
                {
                    Console.WriteLine(data[front + counter + offset]);
                    if (front + counter >= capacity - 1) offset++;
                    counter++;
                }
            }
        }

        public class QueueWith2Stacks
        {
            Stack stack1 = new Stack();
            Stack stack2 = new Stack();

            public void Enqueue(int value)
            {
                stack1.Push(value);
            }

            public int Dequeue()
            {
                refillStack2();
                return (int)stack2.Pop();
            }

            public int Peek()
            {
                refillStack2();
                return (int)stack2.Peek();
            }

            private void refillStack2()
            {
                if (stack2.Count == 0) while (stack1.Count != 0) stack2.Push(stack1.Pop());
            }
        }

        public class PriorityQueue
        {
            int maxSize = 5;
            int currentSize = 0;
            int[] queue;

            public PriorityQueue(int maxSize = 5)
            {
                this.maxSize = maxSize;
                queue = new int[maxSize];
            }

            public void enqueue(int value)
            {
                if (isFull()) throw new Exception();
                int i;
                for (i = currentSize - 1; i >= 0; i--)
                {
                    if (value < queue[i]) queue[i + 1] = queue[i];
                    else break;
                }
                queue[i + 1] = value;
                currentSize++;
            }

            public int remove()
            {
                if (currentSize == 0) throw new Exception();
                return queue[--currentSize];
            }

            public int[] getQueue()
            {
                return queue;
            }

            private bool isFull()
            {
                return currentSize == maxSize ;
            }
        }

    }
}

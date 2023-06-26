using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData<T>
{
    private Data<T> firstNode { get; set; }
    private Data<T> lastNode { get; set; }

    public int count;
    public ItemData()
    {
        firstNode = null;
        lastNode = null;
        count = 0;
    }

    public int Count()
    {
        return count;
    }

    public T Get(int index)
    {
        if (index == 0)
        {
            return firstNode.value;
        }

        if (index.Equals(count-1))
        {
            return lastNode.value;
        }

        if (index > 0 && index < (count - 1))
        {
            var currentNode = firstNode;
            for (int i = 0; i < index; ++i)
            {
                currentNode = currentNode.Next;
            }
            return currentNode.value;
        }

        throw new IndexOutOfRangeException();


    }
    public void RemoveAt(int index)
    {
        if (count == 0 || index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        if (index == 0)
        {
            firstNode = firstNode.Next;

            count--;
        }
        else if (index == count - 1)
        {
            var currentNode = firstNode;

            while (currentNode.Next != null && currentNode.Next != lastNode)
                currentNode = currentNode.Next;

            currentNode.Next = null;
            lastNode = currentNode;

            count--;
        }
        else
        {
            int i = 0;
            var currentNode = firstNode;
            while (currentNode.Next != null)
            {
                if (i + 1 == index)
                {
                    currentNode.Next = currentNode.Next.Next;
                    count--;
                    break;
                }
                ++i;
                currentNode = currentNode.Next;
            }
        }
    }



    public void Append(T obj)
    {
        Data<T> newNode = new Data<T>(obj);
        if (firstNode != null)
        {
            Data<T> currentNode = lastNode;
            currentNode.Next = newNode;
            lastNode = newNode;
        }
        else
        {
            firstNode = newNode;
            lastNode = newNode;
        }
        count++;
    }
}

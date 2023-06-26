using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data<T> 
{

    private Data<T> next;
    private T data;

    public Data()
    {
        next = null;
        data = default(T);
    }
    public Data(T obj)
    {
        data = obj;
        next = null;
    }
    public T value
    {
        get { return this.data; }
        set { this.data = value; }
    }

    public Data<T> Next
    {
        get { return this.next; }
        set { this.next = value; }
    }


}

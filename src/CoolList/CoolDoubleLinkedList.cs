using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// CoolList Library namespace
/// By Daniel und Bjarne
/// </summary>
namespace CoolList {
  /// <summary>
  /// Double Linked List with enumerator
  /// </summary>
  public class CoolDoubleLinkedList<T> : IEnumerable<T> where T : IComparable<T> {
    protected Node head;
    protected Node current = null;

    protected class Node {
      public Node prev;
      public Node next;
      private T data;
      public Node(T t) {
        next = null;
        prev = null;
        data = t;
      }

      public Node Next {
        get { return next; }
        set { next = value; }
      }

      public Node Prev {
        get { return prev; }
        set { prev = value; }
      }

      public T Data {
        get { return data; }
        set { data = value; }
      }
    }

    public CoolDoubleLinkedList() {
      head = null;
    }

    /// <summary>
    /// Return the Length of the List
    /// </summary>
    public int Length {
      get {
        Node temp = head;
        int count = 1;

        while (temp.next != null) {
          temp = temp.next;
          count++;
        }

        return count;
      }
    }

    /// <summary>
    /// Add new entry to the List
    /// </summary>
    public void Add(T t) {
      Node n = new Node(t);
      if (head == null) {
        n.Next = head;
        head = n;
      } else {
        Node current = head;

        while (current.Next != null && current.Data.CompareTo(n.Data) < 0) {
          current = current.Next;
        }

        n.Next = current;
        head = n;
      }
    }

    /// <summary>
    /// Find Entry and return Object
    /// </summary>
    public T Find(Func<T, bool> lamda) {
      Node temp = head;
      T result = default(T);
      while (temp.next != null) {
        temp = temp.next;
        if (lamda(temp.Data)) {
          result = temp.Data;
        }
      }  
      return result;
    }

    public IEnumerator<T> GetEnumerator() {
      Node current = head;
      while (current != null) {
        yield return current.Data;
        current = current.Next;
      }
    }

    IEnumerator IEnumerable.GetEnumerator() {
      return GetEnumerator();
    }
  }
}

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
  public class CoolDoubleLinkedList<T> : IEnumerable<T> {
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
    /// Add new entry to the List
    /// </summary>
    public void Add(T t) {
      Node n = new Node(t);
      n.Next = head;
      head = n;
    }

    /// <summary>
    /// Find Entry and return Object
    /// </summary>
    public T Find(Func<T, bool> lamda) {
      Node temp = head;
      T result = default(T);
      while (head.next != null) {
        if (lamda(temp.Data)) {
          result = temp.Data;
        }
        temp = head.next;
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

using System;
using CoolList;

namespace Program {
  class Program {
    static int Main(string[] args) {
      CoolSortedDoubleLinkedList<Student> list = new CoolSortedDoubleLinkedList<Student>();

      int i = 0;
      string[] names = new string[] {
        "Kevin",
        "Yannis",
        "Bjarne",
        "Dominik",
        "Lukas",
        "Marco",
        "Daniel",
      };

      foreach (string name in names) {
        list.Add(new Student(name, i));
        i++;
      }

      foreach (Student student in list) {
        Console.WriteLine(student.ToString());
      }

      return 0;
    }
  }

  public class Student : IComparable<Student> {
    string name;
    int id;

    public Student(string s, int i) {
      name = s;
      id = i;
    }

    public int CompareTo(Student s) {
      return id - s.id;
    }

    public override string ToString() {
      return String.Format("{0} : {1}", name, id);
    }

    public bool Equals(Student s) {
      return (this.id == s.id);
    }
  }
}

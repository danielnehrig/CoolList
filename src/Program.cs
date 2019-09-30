using System;
using CoolList;

namespace Program {
  class Program {
    static int Main(string[] args) {
      CoolDoubleLinkedList<Student> list = new CoolDoubleLinkedList<Student>();

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

      // Add students to List
      foreach (string name in names) {
        list.Add(new Student(name, i));
        i++;
      }

      // IEnum list loop
      foreach (Student student in list) {
        Console.WriteLine(student.ToString());
      }

      // Length Test
      Console.WriteLine(String.Format("List Length = {0}",list.Length));

      // Find Test
      Student temp = list.Find(x => 4 == x.id);
      Console.WriteLine(temp.id);

      return 0;
    }
  }

  public class Student : IComparable<Student> {
    public string name;
    public int id;

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

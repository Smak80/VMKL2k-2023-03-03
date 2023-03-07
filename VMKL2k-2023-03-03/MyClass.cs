using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VMKL2k_2023_03_03
{
    public class Elem
    {
        public int X { get; set; }

        public Elem(int x = 5)
        {
            X = x;
        }

        public Elem(Elem existingElem)
        {
            X = existingElem.X;
        }
        public override string ToString()
        {
            return X.ToString();
        }
    }
    public class MyClass
    {
        public static int cnt = 0;
        public int A { get; set; } = 5;
        public int B { get; set; } = 3;
        public List<Elem> S { get; set; } = 
            new(){new Elem(1), new Elem(3), new Elem()};

        public MyClass()
        {
            cnt++;
        }

        public MyClass Copy() => new MyClass(){A = A, B = B, S = new List<Elem>(S)};

        public MyClass DeepCopy()
        {
            var r = new MyClass();
            r.A = A;
            r.B = B;
            r.S = new List<Elem>();
            foreach (var elem in S)
            {
                r.S.Add(new Elem(elem));
            }
            return r;
        }

        public override string ToString()
        {
            return $"A={A}, B={B},\n S={string.Join(" ", S)}";
        }

        public override bool Equals(object? obj)
        {
            return obj is MyClass a && a.A == A && a.B == B;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }

        public static bool operator == (MyClass a, MyClass b)
        {
            return a.A == b.A && a.B == b.B;
        }

        public static bool operator != (MyClass a, MyClass b)
        {
            return !(a == b);
        }

        public static MyClass operator +(MyClass a, MyClass b)
        {
            return new MyClass() { A = a.A + b.A, B = a.B + b.B };
        }

        public static MyClass operator +(MyClass a, int x)
        {
            return new MyClass() { A = a.A + x, B = a.B + x };
        }

        public static MyClass operator -(MyClass a)
        {
            return new MyClass() { A = -a.A, B = -a.B };
        }
        
        public static implicit operator MyClass(int x)
        {
            return new MyClass() { A = x, B = x };
        }

        public static explicit operator int(MyClass x)
        {
            return x.A;
        }
    }
}

// See https://aka.ms/new-console-template for more information

using VMKL2k_2023_03_03;

var mc1 = new MyClass();
var mc2 = new MyClass();
var mc3 = mc2;
var mc2c = mc2.Copy();
mc2.S.Add(new Elem(4));
mc2.S[0].X = 10;
Console.WriteLine($"mc2={mc2}; mc3={mc3}; mc2c={mc2c}");
var mc2dc = mc2.DeepCopy();
mc2dc.S[0].X = 200;
Console.WriteLine($"mc2dc = {mc2dc};\nmc2 = {mc2}");
Console.WriteLine(MyClass.cnt);
mc1.Equals(mc2);
if (mc1 == mc2)
{
    Console.WriteLine("Равны");
}
else
{
    Console.WriteLine("Не равны");
}
Console.WriteLine(mc1 + mc2);
Console.WriteLine(mc1 + 10);
Console.WriteLine(10 + mc1);
MyClass mc4 = 5;
int i = (int)mc4;
var mc5 = -mc4;
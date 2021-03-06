﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections; // 为了使用 ArrayList
using System.Collections.Generic; // 增加泛型集合命名空间

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        /* 关键在这里，声明一个泛型集合变量，用接口IList，注意：
         * IList<Animal>表示此集合变量只能接受Animal类型，其他不可以。
         * 也可以直接声明“List <Animal> arrayAnimal;
         */ 
        IList<Animal> arrayAnimal;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cat cat = new Cat("小花");
            cat.ShoutNum = 5;
            MessageBox.Show(cat.Shout());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dog dog = new Dog("旺财");
            dog.ShoutNum = 8;
            MessageBox.Show(dog.Shout());
        }

  //      private Animal[] arrayAnimal;

        // 动物报名 的按钮事件
        private void button3_Click(object sender, EventArgs e)
        {
            // ArrayList是命名空间System.Collections下的一部分，它是使用大小可按需动态增加的数组实现IList接口。
            // 优点： 它可以根据使用大小按需动态增加，不用受事先设置其大小的限制。可以随意地添加、插入或移除某一范围元素，比数组方便
            // 缺点：ArrayList不是类型安全的。
            // 装箱就是把值类型打包到Object引用类型的一个实例中。
            // 拆箱就是指从对象中提取值类型。
            // 相对于简单的赋值而言，装箱和拆箱过程需要进行大量的计算。
            // 对值类型进行装箱时，必须分配并构造一个全新的对象。其次，拆箱所需的强制转换也需要进行大量的计算。
            /* 泛型
             * 泛型是具有占位符（类型参数）的类、结构、接口和方法，这些占位符是类、结构、接口和方法所存储或使用的一个或多个类型的占位符。
             * 泛型集合类可以将类型参数用作它所存储的对象的类型的占位符；
             * 类型参数作为其字段的类型和其方法的参数类型出现。
             */ 

            // 实例化List对象，注意：此时也需要指定List<T>的T是Animal
            arrayAnimal = new List<Animal>();
            arrayAnimal.Add(new Cat("小花"));
            arrayAnimal.Add(new Dog("阿毛"));
            arrayAnimal.Add(new Cattle("小黑"));
            arrayAnimal.Add(new Sheep("娇娇"));
            arrayAnimal.Add(new Cat("咪咪"));

            MessageBox.Show(arrayAnimal.Count.ToString());

            arrayAnimal.RemoveAt(1);
            arrayAnimal.RemoveAt(1);
            MessageBox.Show(arrayAnimal.Count.ToString());
        }
        
        // 叫声比赛 的按钮事件
        private void button4_Click(object sender, EventArgs e)
        {
            foreach (Animal item in arrayAnimal)
            {
                MessageBox.Show(item.Shout());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MachineCat mcat = new MachineCat("叮当");
            StoneMonkey wukong = new StoneMonkey("孙悟空");

            IChange[] array = new IChange[2];
            array[0] = mcat;
            array[1] = wukong;

            MessageBox.Show(array[0].ChangeThing("各种各样的东西！"));
            MessageBox.Show(array[1].ChangeThing("各种各样的东西！"));
        }
    }
}


// 多态表示不同的对象可以执行相同的动作，但要它们自己的实现代码来执行。
// 用到虚方法和方法重写，或方法覆写。Override。
// C#允许把类和方法声明为abstract，即抽象类和抽象方法
abstract class Animal
{
    // protected表示继承时子类可以对父类有完全访问权
    // 用protected修饰的类成员，对子类公开，但不对其他类公开。
    protected string name = "";
    public Animal (string name)
    {
        this.name = name;
    }
    public Animal ()
    {
        this.name = "无名";
    }

    protected int shoutNum = 3;
    public int ShoutNum
    {
        get
        {
            return shoutNum;
        }
        set
        {
            shoutNum = value;
        }
    }
    /* 原来是个虚方法，但是每个实现重复代码很多，都放在这个方法中
    public virtual string Shout()
    {
        return "";
    }
    */
    public string Shout()
    {
        string result = "";
        for (int i = 0; i < shoutNum; i++)
            result += getShoutSound() + ", ";

        return "我的名字叫" + name + " " + result;
    }

    /* “得到叫声”，虚方法，让子类重写，只需要给继承的子类使用，所以用protected修饰符
     */
    /* 抽象类通常代表一个抽象概念，它提供一个继承的出发点，当设计一个新的抽象类时，一定是用来继承的，所以，在一个
     * 以继承关系形成的等级结构里面，树叶节点应当是具体类，而树枝节点均应当是抽象类。
     */
    protected abstract string getShoutSound();
}

// 未用多态实现的Animal类
/*
class Animal
{
    // protected表示继承时子类可以对父类有完全访问权
    // 用protected修饰的类成员，对子类公开，但不对其他类公开。
    protected string name = "";
    public Animal(string name)
    {
        this.name = name;
    }
    public Animal()
    {
        this.name = "无名";
    }

    protected int shoutNum = 3;
    public int ShoutNum
    {
        get
        {
            return shoutNum;
        }
        set
        {
            shoutNum = value;
        }
    }
}
*/

// 继承定义了类如何相互关联，共享特性。继承的工作方式是，定义父类和子类，或叫基类和派生类，
// 其中子类继承父类的所有特性。子类不但继承了父类的所有特性，还可以定义新的特性。
class Cat : Animal
{
    public Cat() : base()
    { }

    public Cat(string name) : base (name)
    { }

    protected override string getShoutSound()
    {
        return "喵";
    }
}

// 狗类实现
class Dog : Animal
{
    public Dog() : base()
    { }

    public Dog(string name) : base(name)
    { }

    protected override string getShoutSound()
    {
        return "汪";
    }
}

class Cattle : Animal
{
    public Cattle()
        : base()
    { }

    public Cattle(string name)
        : base(name)
    { }

    protected override string getShoutSound()
    {
        return "哞";
    }
}

class Sheep : Animal
{
    public Sheep()
        : base()
    { }

    public Sheep(string name)
        : base(name)
    { }

    protected override string getShoutSound()
    {
        return "咩";
    }
}

class Monkey : Animal
{
    public Monkey()
        : base()
    { }

    public Monkey(string name)
        : base(name)
    { }

    protected override string getShoutSound()
    {
        return "吱";
    }
}
/*
// 类与实例
// 类就是具有相同的属性和功能的对象的抽象的集合
class Cat
{
    private string name = "";
    // 字段是存储类要满足其设计所需要的数据，字段是与类相关的变量
    private int shoutNum = 3;
    // 属性是一个方法或一对方法（get，set），但在调用它的代码看来，它是一个字段，即属性适合于以字段的方法使用方法调用的场合
    public int ShoutNum
    {
        get
        {
            return shoutNum;
        }
        set
        {
            if (value <= 10)
                shoutNum = value;
            else
                shoutNum = 10;
        }
    }

    // 构造方法，又叫构造函数，其实就是对类进行初始化。构造方法与类同名，无返回值，也不需要void，在new时候调用。
    public Cat(string name)
    {
        this.name = name;
    }

    // 方法重载提供了创建同名的多个方法的能力，但这些方法需使用不同的参数类型。
    // 构造方法重载
    public Cat()
    {
        this.name = "无名";
    }

    public string Shout()
    {
        string result = "";
        
        for (int i = 0; i < shoutNum; i++)
        {
            result += "喵 ";
        }
        return "我的名字叫"+ name + " " + result;
    }
    // 普通方法重载
    public string Shout(string shout)
    {
        return "我的名字叫" + name + shout;
    }
}

// 封装，每个对象都包含它能进行操作所需要的所有信息，这个特性称为封装，因此对象不必依赖其他对象来完成自己的操作。
class Dog
{
    private string name = "";
    // 字段是存储类要满足其设计所需要的数据，字段是与类相关的变量
    private int shoutNum = 3;
    // 属性是一个方法或一对方法（get，set），但在调用它的代码看来，它是一个字段，即属性适合于以字段的方法使用方法调用的场合
    public int ShoutNum
    {
        get
        {
            return shoutNum;
        }
        set
        {
            if (value <= 10)
                shoutNum = value;
            else
                shoutNum = 10;
        }
    }

    // 构造方法，又叫构造函数，其实就是对类进行初始化。构造方法与类同名，无返回值，也不需要void，在new时候调用。
    public Dog(string name)
    {
        this.name = name;
    }

    // 方法重载提供了创建同名的多个方法的能力，但这些方法需使用不同的参数类型。
    // 构造方法重载
    public Dog()
    {
        this.name = "无名";
    }

    public string Shout()
    {
        string result = "";

        for (int i = 0; i < shoutNum; i++)
        {
            result += "汪 ";
        }
        return "我的名字叫" + name + " " + result;
    }
    // 普通方法重载
    public string Shout(string shout)
    {
        return "我的名字叫" + name + shout;
    }
}
*/

/* 接口把隐式公共方法和属性组合起来，以封装特定功能的一个集合。
 * 一旦类实现了接口，类就可以支持接口所指定的所有属性和成员。
 * 声明接口在语法上与声明抽象类完全相同，但不允许提供接口中任何成员的执行方式。
 * 所以接口不能实例化，不能有构造方法和字段；不能有修饰符，比如public，private等；
 * 不能声明虚拟的或静态的等。
 * 实现接口的类就必须要实现接口中所有的方法和属性
 * 一个类可以支持多个接口，多个类也可以支持相同的接口。
 * 接口的命名，前面要加一个大写字母‘I’，这是规范
*/
/* 声明一个IChange接口
 */ 
interface IChange
{
    string ChangeThing(string thing);
}

/* 机器猫继承于猫，并实现IChange接口，注意Cat与IChange是用“，”分隔
 */ 
class MachineCat:Cat, IChange
{
    public MachineCat() : base()
    {

    }
    public MachineCat(string name) : base (name)
    { }

    public string ChangeThing(string thing)
    {
        return base.Shout() + "我有万能的口袋，我可以变出：" + thing;
    }
}

/* 孙悟空
 */
class StoneMonkey : Monkey, IChange
{
    public StoneMonkey()
        : base()
    {

    }
    public StoneMonkey(string name)
        : base(name)
    { }

    public string ChangeThing(string thing)
    {
        return base.Shout() + "我有万能的口袋，我可以变出：" + thing;
    }
}

/* 抽象类和接口的区别
 * 抽象类可以给出一些成员的实现，接口却不包含成员的实现，
 * 抽象类的抽象成员可以被子类部分实现，接口的成员需要实现类完全实现，
 * 一个类只能继承一个抽象类，但可以实现多个接口等等。
 * 
 * 第一，类是对对象的抽象；抽象类时对类的抽象；接口是对行为的抽象。
 * 第二，如果行为跨越不同类的对象，可以使用接口；对于一些相似的类对象，用继承抽象类。
 * 第三，从设计角度讲，抽象类时从子类中发现了公共的东西，泛化父类，然后子类继承父类，----通过重构改善既有代码的设计。
 *       而接口是根本不知子类的存在，方法如何实现还不确认，预先定义。
*/
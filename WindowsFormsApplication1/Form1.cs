using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
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
    }
}

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
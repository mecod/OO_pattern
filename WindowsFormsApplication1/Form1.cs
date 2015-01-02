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
            MessageBox.Show(cat.Shout("hoho"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

// 类与实例
// 类就是具有相同的属性和功能的对象的抽象的集合
class Cat
{
    private string name = "";

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
        return "我的名字叫"+ name + ", 喵";
    }
    // 普通方法重载
    public string Shout(string shout)
    {
        return "我的名字叫" + name + shout;
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    public abstract class chess
    {
        string name;//名字，颜色，行，列，这是我暂时想到有用的属性
        public string color;
        public int row;
        public int column;
        public string image;
        public string imageEat;
        public bool Cango = false;
        public bool alive = true;

        public chess(string color, string name, int column, int row)//构造函数
        {
            this.color = color;
            this.name = name;
            this.column = column;
            this.row = row;
            
        }

        public string Getname()//获取名字
        {
            return this.name;
        }

        public string Getcolor()//获取棋子的颜色
        {
            return this.color;
        }



        public void changeCango()
        {
            Cango = true;
        }

        public bool GetCango()
        {
            return Cango;
        }

        public string GetImage()
        {
            return this.image;
        }

        public string GetImageEat()
        {
            return this.imageEat;
        }

    }


    //以下就算是各个棋子的类，也就是“棋子”的子类，除了将我添加了一个"生死"属性，其它一样
    public class horse : chess
    {
        public horse(string color, int column, int row)
        : base(color, "马", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Rh.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/RhS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Bh.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/BhS.gif";
                    break;
            }
            
        }
    }

    public class cannon : chess
    {
        public cannon(string color, int column, int row)
        : base(color, "炮", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Rc.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/RcS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Bc.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/BcS.gif";
                    break;
            }
        }
    }
    public class rood : chess
    {
        public rood(string color, int column, int row)
        : base(color, "车", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Rr.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/RrS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Br.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/BrS.gif";
                    break;
            }
        }
    }

    public class soldier : chess
    {
        public soldier(string color, int column, int row)
        : base(color, "兵", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Rs.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/RsS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Bs.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/BsS.gif";
                    break;
            }
        }
    }

    public class elephant : chess
    {
        public elephant(string color, int column, int row)
        : base(color, "象", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Re.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/ReS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Be.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/BeS.gif";
                    break;
            }
        }
    }

    public class guard : chess
    {
        public guard(string color, int column, int row)
        : base(color, "士", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Rg.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/RgS.gif";
                    break;

                case "black":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/Bg.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/BgS.gif";
                    break;
            }
        }
    }

    public class general : chess
    {
        public general(string color, int column, int row)
            : base(color, "将", column, row)
        {
            switch (this.color)
            {
                case "red":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/RK.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/RKS.gif";

                    break;

                case "black":
                    this.image = "C:/Users/75475/Desktop/WPFImage/Chess/BK.gif";
                    this.imageEat = "C:/Users/75475/Desktop/WPFImage/Chess/BKS.gif";
                    break;
            }
        }
    }

    public class nochess : chess
    {
        public nochess(int column, int row)
            : base("nochess", "nochess", column, row)
        {
            this.image = "C:/Users/75475/Desktop/WPFImage/Chess/OO.gif";
        }
    }
    

}

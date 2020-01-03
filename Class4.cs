using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    public class control//这个类的作用我觉得是能把main类变得很简洁
    {
        public board Board = new board();
        public board copyBoard = new board();
        int beginrow;
        int begincol;
        public bool state = true;
        string color = "red";//这个是在后面玩家切换回合使用，显示黑色走

        public bool Gameover()
        {
            bool alive;
            alive = Board.GeneralAlive();
            return alive;
        }

        public bool WhoWin()
        {
            bool alive;
            alive = Board.blackGeneralAlive();
            return alive;
        }

        
        public void Playchoose(int beginrow, int begincol)//选择棋子
        {

            this.begincol = begincol;
            this.beginrow = beginrow;

        }

        public void Movechess(int endrow, int endcol)
        {
           
            Board.MoveChess(this.begincol, this.beginrow, endcol, endrow);
            if (this.beginrow == endrow && this.begincol == endcol)
            {
                MyException ex = new MyException();
                throw new MyException("you choose the start point", ex);
            }
        }
        


        public void RefreshCanGo(int endrow, int endcol)
        {
            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    Board.Chess[i, j].Cango = false;
                }

            }
        }
        public void SwitchPlayer()
        {
            switch (color)
            {
                case "black":
                    color = "red";
                    break;

                case "red":
                    color = "black";
                    break;
            }
        }

        

    }
}

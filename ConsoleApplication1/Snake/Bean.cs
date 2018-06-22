using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //食物
    class Bean
    {
        //用于画食物的顶端坐标
        public  Point _origin{set;get;}


        //显示食物
        public void ShowBean(Graphics g)
        {
            //定义红色的画笔
            SolidBrush brush = new SolidBrush(Color.Red);
            //画实心矩形表示食物
            g.FillRectangle(brush,_origin.X,_origin.Y,15,15);
        
        }

        public void UnshowBean(Graphics g)
        { 
            //定义系统背景颜色的画笔
            SolidBrush brush = new SolidBrush(Color.Silver);
            //画实心矩形颜色为系统背景颜色，相当于食物被吃掉了
            g.FillRectangle(brush, _origin.X, _origin.Y, 15, 15);
        
        }

    }
}

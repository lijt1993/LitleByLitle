using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    //蛇身体的每一单元，简称块
    class Block
    {
        //是否为蛇头
        public bool IsHead { get; set; }

        //蛇块的编号
        public int BlockNumber { get; set; }

        //蛇块的左上角位置
        public Point Origin { get; set; }

        //根据指定位置画蛇块
        public void ShowBlock(Graphics g)
        {
            Bitmap bitMap;
            if (IsHead)
            {

                //蛇头
                bitMap = new Bitmap(Image.FromFile("Head.gif"));
            }
            else
            {
                bitMap = new Bitmap(Image.FromFile("body.gif"));
            }
            g.DrawImage(bitMap,Origin.X,Origin.Y,15,15);
        }

        //消除蛇块
        public void UnShowBlock(Graphics g)
        {
            SolidBrush brush = new SolidBrush(Color.Silver);
            g.FillRectangle(brush, Origin.X, Origin.Y, 15, 15);
        }

    }
}

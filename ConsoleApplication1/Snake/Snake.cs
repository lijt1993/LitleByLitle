using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake
    {
        //用于存放蛇块的集合
        private List<Block> blocksList;
        //0-上，1-右，2-下，3-左
        private int direction = 1;
        //蛇头的编号，也是蛇的长度
        private int headNumber;
        //蛇头左上角坐标
        private Point headPoint;
        private Point mapLeft;

        //游戏开始时，初始的蛇
        public Snake(Point map, int count)
        {
            mapLeft = map;
            Block blockSnake;
            //定义蛇的起始位置(蛇尾)
            Point p = new Point(map.X + 15,map.Y + 15);
            blocksList = new List<Block>();
            //循环画蛇块用于填充蛇集合
            for (int i = 0; i < count; i++)
            { 
                //x坐标加15
                p.X += 15;
                //实例化蛇块
                blockSnake = new Block();
                //定义蛇块的左上角位置
                blockSnake.Origin = p;
                //定义蛇块的编号
                blockSnake.BlockNumber = i + 1;
                if (i == count - 1)
                {
                    //蛇头
                    //给蛇头位置赋值
                    headPoint = blockSnake.Origin;
                    blockSnake.IsHead = true;
                }

                blocksList.Add(blockSnake);
            }
            //蛇的长度赋值
            headNumber = count;
        
        }


        //蛇头坐标的只读属性
        public Point HeadPoint
        {
            get { return headPoint; }
        }

        //蛇的运动方向的属性
        public int Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        /// <summary>
        /// 蛇的转换方向
        /// </summary>
        /// <param name="pDirection">想要改变的方向</param>
        public void TurnDirection(int pDirection)
        {
            switch (direction)
            { 
              //原来向上运动
                case 0:
                    //希望向左运动
                    if (pDirection == 3)
                    {
                        direction = 3;
                    }
                    //希望向右运动
                    else if (pDirection == 1)
                    {
                        direction = 1;
                    }
                    break;
              //原来向右运动
                case 1:
                    //希望向上运动
                    //希望向下运动
                    break;
              //原来向下运动
                case 2:
                    //希望向左运动
                    //希望向右运动
                    break;
              //原来向左运动 
                case 3:
                    //希望向上运动
                    //希望向下运动
                    break;
            
            }
        }
    }
}

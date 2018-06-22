using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAndSort
{
    //定义一个委托
    delegate bool CompareOp(object lhs, object rhs);
    class Program
    {
        
       
        static void Main(string[] args)
        {
            //初始化一个学生数组
            Student[] students = 
            {
                new Student("Zhang",86),
                new Student("Li",100),
                new Student("Wang",93),
                new Student("Zhao",78),
                new Student("Liu",53),
                new Student("Jia",91),
                new Student("Wu",19)

            };

            //使用RhsIsGreater方法进行比较，并用Sort方法排序
            CompareOp studentCompareOp = new CompareOp(Student.RhsIsGreater);
            ScoreSort.Sort(students,studentCompareOp);
            //循环输出所有学生的已排序成绩
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].ToString());
            }
            Console.ReadLine();

            
        }
    }
    #region 学生类
    class Student
    {
        private string name;                      //姓名字段
        private decimal score;                    //成绩字段
        public Student(string name, decimal score) //构造函数
        {
            this.name = name;
            this.score = score;
        }

        /// <summary>
        /// 比较方法
        /// </summary>
        /// <param name="lhs">左侧学生对象</param>
        /// <param name="rhs">右侧学生对象</param>
        /// <returns>右侧学生对象的成绩高返回true</returns>
        public static bool RhsIsGreater(object lhs, object rhs)
        {
            Student studentL = (Student)lhs;
            Student studentR = (Student)rhs;
            return (studentR.score > studentL.score) ? true : false;
        
        }
        /// <summary>
        /// 重写ToString方法，可以使得输出更加清晰，输出预定义格式
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format(name + " : " + score);
        }
    
    
    }
    #endregion

    #region 排序类，定义成绩排序的委托方法，并将这个方法添加到委托对象之中
    /// <summary>
    /// 排序类，方法Sort为静态方法，使用冒泡法
    /// </summary>
    class ScoreSort
    {
        /// <summary>
        /// 冒泡法排序
        /// </summary>
        /// <param name="sortArray">要进行排序的数组</param>
        /// <param name="Method">排序的方法</param>
        static public void Sort(object[] sortArray, CompareOp Method)
        { 
            //外围第一次循环
            for (int i = 0; i < sortArray.Length; i++)
            { 
                //第二次循环
                for (int j = i + 1; j < sortArray.Length; j++)
                {
                    if (Method(sortArray[j], sortArray[i]))
                    {
                        object temp = sortArray[i];
                        sortArray[i] = sortArray[j];
                        sortArray[j] = temp;
                    }
                }
            
            }
        
        }
    }
    #endregion
}

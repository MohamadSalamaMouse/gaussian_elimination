using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gaussian_elimination
{
    class Program
    {
        static bool achiveCondtion;
        static int firstColum;
        static void Main(string[] args)
        {
        
            Console.Write("enter number of equation");
            int n = int.Parse(Console.ReadLine());

            double[,] matrix = new double[n, n +1];
            double[] variable = new double[n];
            // int firstColum;
            //enter agumented matrix
            enter_agumented(ref matrix, n);
            Console.WriteLine("without operation");
            printMatrix( matrix, n);
            //  اذا كانت قيمة اول عنصر فى العمود اللى تم تحديده بتساوي صفر فسوف نبدل الصفوف
            exchange_colum(ref matrix, n, firstColum, 0);
            if(achiveCondtion==true)
            {
                printMatrix(matrix, n);
            }

            // لتكرار الخطوة من 1 الى 4
            for (int i = 0; i < n; i++)
            {
                // ايجاد اول عمود غير صفري
                find_first_colum(ref matrix, n, i);
                Console.WriteLine("next colum = {0}", firstColum);
                //نجعل قيمة اول عنصر فى العمود اللى تم اختياره ب 1
                if (matrix[i,firstColum]!=1)
                {
                    leading1(ref matrix, n, firstColum, i);
                    printMatrix(matrix, n);
                }
                //apply gauss Elimination
                gaussionElimintion(matrix, n);
                //print items  
                printMatrix(matrix, n);
                

            }
            Console.WriteLine("end operation in matrix");

            //solution
            outputVariable(matrix,variable, n);

            Console.ReadKey();
        }

        private static void leading1(ref double[,] matrix, int n, int first_colum, int loop)
        {
            if (matrix[loop, first_colum] != 0)
            {
                double ratio = 1 / matrix[loop, first_colum];
                for (int i = 0; i <n+1; i++)
                {
                    matrix[loop, i] = matrix[loop, i] * ratio;
                }
            }

           
        }

        private static void find_first_colum(ref double[,] matrix, int n, int loop)
        {
            int i;
            for (i=loop; i <n+1; i++)
            {
                for (int j = loop; j < n; j++)
                {
                    if(matrix[i,j]!=0)
                    {
                        firstColum = i;
                        break;
                    }
                }
                if (firstColum==i)
                {
                    break;
                }
            }
          
        }

        private static void exchange_colum(ref double[,] matrix, int n, int first_colum, int loop)
        {
            double valueNotZero;
            double swap;
            if (matrix[loop, first_colum] == 0)
            {
                achiveCondtion = true;
                for (int i = 0; i < n; i++)
                {
                    valueNotZero = matrix[i, first_colum];
                    if(valueNotZero!=0)
                    {
                        Console.WriteLine("exchange row {0} with row {1}",loop,i);
                        for (int j = 0; j < n+1; j++)
                        { 
                            swap = matrix[loop, j];
                            matrix[loop, j] = matrix[i, j];
                            matrix[i, j] = swap;
                        }
                        break;
                    }
                }
            }
            
        }

        public static void enter_agumented(ref double [,]agumented,int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    Console.Write("matrix[{0},{1}] = ", i, j);
                   agumented[i, j] = double.Parse(Console.ReadLine());
                }
            }

        }


        public static void gaussionElimintion(double[,]matrix,int n)
        {
            double ratio;


            for (int i = 0; i < n - 1; i++)
            {


                for (int j = i + 1; j < n; j++)
                {
                    if (matrix[i, i] != 0)
                    {
                        ratio = matrix[j, i] / matrix[i, i];
                        if(ratio !=0)
                        Console.WriteLine("multiple with  {0} in row {1} and substraction from row {2} ",ratio,i,j);
                        for (int k = 0; k < n + 1; k++)
                        {
                            matrix[j, k] = matrix[j, k] - ratio * matrix[i, k];

                        }
                    }

                }
              

            }


        }
        public static void outputVariable(double[,] matrix, double[] variable, int n)
        {
            variable[n - 1] = matrix[n - 1, n] / matrix[n - 1, n - 1];

            for (int i = n - 2; i >= 0; i--)
            {
                variable[i] = matrix[i, n];
                for (int j = i + 1; j < n; j++)
                {
                    variable[i] = variable[i] - matrix[i, j] * variable[j];
                }
                variable[i] = variable[i] / matrix[i, i];
            }

            for (int i = 0; i < variable.Length; i++)
            {
                Console.WriteLine("x{0} = {1} ", (i + 1), variable[i]);
            }



        }
        private static void printMatrix( double[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                    Console.Write("{0}\t", matrix[i, j]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("===========================================================");
        }
    }

}       



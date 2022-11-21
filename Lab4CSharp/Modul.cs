using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    /*----Task-1------------*/
    class Money
    {
        public double First { get; set; }
        public double Second { get; set; }
        public double this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return First;
                }
                else if (index == 1)
                {
                    return Second;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }

            set
            {
                if (index == 0)
                {
                    First = value;
                }
                else if (index == 1)
                {
                    Second = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public Money()
        {

        }
        public Money(double first, double second)
        {
            First = first;
            Second = second;
        }

        public static explicit operator Money(string fields) => new Money { First = Convert.ToDouble(fields.Split(" ")[0]), Second = Convert.ToDouble(fields.Split(" ")[1]) };

        public static implicit operator string(Money money) => $"{money[0]} {money[1]}";
        public static Money operator ++(Money money) => new Money { First = money[0]++, Second = money[1]++ };
        public static Money operator --(Money money) => new Money { First = money[0]--, Second = money[1]-- };
        public static bool operator !(Money money) => money[1] != 0;
        public static Money operator +(Money money1, Money money2) => new Money(money1[0] + money2[0], money1[1] + money2[1]);
        public static Money operator -(Money money1, Money money2) => new Money(money1[0] - money2[0], money1[1] - money2[1]);
    }
    /*----------------------*/


    /*----Task-2------------*/
    class VectorLong
    {
        long[] longArray;
        uint size;
        int codeError;
        static uint num_vl = 0;
        public uint Size 
        { 
            get
            {
                return size;
            }
        }
        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }
        public long this[int index]
        {
            get 
            {
                try
                {
                    return longArray[index];
                }
                catch (Exception e)
                {
                    codeError = 1;
                    Console.WriteLine(e.Message);
                    return 0;
                }
            }
            set 
            {
                try
                {
                    longArray[index] = value;
                }
                catch (Exception e)
                {
                    codeError = 1;
                    Console.WriteLine(e.Message);
                }
            }
        }

        public VectorLong()
        {
            size = 1;
            longArray = new long[size];
            codeError = 0;
            num_vl++;
        }
        public VectorLong(uint size) : this()
        {
            this.size = size;
            longArray = new long[size];
        }
        public VectorLong(uint size, long value) : this(size)
        {
            for (int i = 0; i < size; i++)
            {
                longArray[i] = value;
            }
        }
        ~VectorLong() 
        {
            Console.WriteLine("Destructor was called");
            Console.WriteLine($"{this.GetType().Name} - deleted");
        }

        public void enterVectorElements()
        {
            for (int i = 0; i < size; i++)
            {
                longArray[i] = (long)Convert.ToDouble(Console.ReadLine());
            }
        }
        public void printVectorWithStartStrOrDefoult(string startStr = "")
        {
            Console.Write(startStr);
            for (int i = 0; i < size; i++)
            {
                Console.Write($"{longArray[i]} ");
            }
            Console.WriteLine();
        }
        public void fillVector(long value)
        {
            for (int i = 0; i < size; i++)
            {
                longArray[i] = value;
            }
        }
        public static uint countNumOfVectors()
        {
            return num_vl;
        }
        public static VectorLong operator ++(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector[i]++;
            }

            return vector;
        }
        public static VectorLong operator --(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector[i]--;
            }

            return vector;
        }
        public static bool operator true(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                if (vector[i] == 0)
                    return false;
            }
            return vector.size != 0;
        }
        public static bool operator false(VectorLong vector) 
        {
            for (int i = 0; i < vector.size; i++)
            {
                if (vector[i] == 0)
                    return true;
            }
            return vector.size != 0;
        }
        public static bool operator !(VectorLong vector) => vector.size != 0;
        public static VectorLong operator ~(VectorLong vector)
        {
            for (int i = 0; i < vector.size; i++)
            {
                vector[i] = ~vector[i];
            }

            return vector;
        }
        public static VectorLong operator +(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] += vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator +(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] += vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator -(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] -= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator -(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] -= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator *(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] *= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator *(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] *= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator /(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] /= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator /(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] /= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator %(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] %= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator %(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] %= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator |(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] |= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator |(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] |= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator ^(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] ^= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator ^(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] ^= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator &(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] &= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator &(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] &= vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator <<(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] = (int)vector1[i] << (int)vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator <<(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] = (int)vector1[i] << (int)vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator >>(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                vector1[i] = (int)vector1[i] >> (int)vector2[i];
            }

            return vector1;
        }
        public static VectorLong operator >>(VectorLong vector1, long[] vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.Length); i++)
            {
                vector1[i] = (int)vector1[i] >> (int)vector2[i];
            }

            return vector1;
        }
        public static bool operator ==(VectorLong vector1, VectorLong vector2)
        {
            return vector1.Equals(vector2);
        }
        public static bool operator !=(VectorLong vector1, VectorLong vector2)
        {
            return !vector1.Equals(vector2);
        }
        public static bool operator >(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {             
                if (vector1[i] < vector2[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator <(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                if (vector1[i] > vector2[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator >=(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                if (vector1[i] <= vector2[i])
                {
                    return false;
                }
            }
            return true;
        }
        public static bool operator <=(VectorLong vector1, VectorLong vector2)
        {
            for (int i = 0; i < Math.Min(vector1.size, vector2.size); i++)
            {
                if (vector1[i] >= vector2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    /*----------------------*/


    /*----Task-3------------*/
    class MatrixLong
    {
        long[,] longArray;
        int n, m;
        int codeError;
        static int num_m;
        public int N 
        { 
            get
            {
                return n;
            } 
            private set
            {
                n = value;
            }
        }
        public int M
        {
            get
            {
                return m;
            }
            private set
            {
                m = value;
            }
        }
        public int CodeError
        {
            get { return codeError; }
            set { codeError = value; }
        }
        public long this[int index1, int index2]
        {
            get 
            {
                try
                {
                    return longArray[index1, index2];
                }
                catch (Exception e)
                {
                    codeError = 1;
                    Console.WriteLine(e.Message);
                    throw e;
                }
            }
            set 
            {
                try
                {
                    longArray[index1, index2] = value;
                }
                catch (Exception e)
                {
                    codeError = 1;
                    Console.WriteLine(e.Message);
                }
            }
        }
        public MatrixLong()
        {
            n = 1;
            m = 1;
            longArray = new long[n, m];
        }
        public MatrixLong(int n, int m)
        {
            this.n = n;
            this.m = m;
        }
        public MatrixLong(int n, int m, long value)
        {
            this.n = n;
            this.m = m;
            longArray = new long[n, m];

            fillVector(value);
        }
        ~MatrixLong()
        {
            Console.WriteLine("Destructor was called");
            Console.WriteLine($"{this.GetType().Name} - deleted");
        }
        public void enterVectorElements()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    longArray[n, m] = (long)Convert.ToDouble(Console.ReadLine());
                }
            }
        }
        public void printVectorWithStartStrOrDefoult(string startStr = "")
        {
            Console.Write(startStr);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{longArray[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public void fillVector(long value)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    longArray[i, j] = value;
                }
            }
        }
        public static int countNumOfVectors()
        {
            return num_m;
        }
        public static MatrixLong operator ++(MatrixLong vector)
        {
            for (int i = 0; i < vector.N; i++)
            {
                for (int j = 0; j < vector.M; j++)
                {
                    vector[i, j]++;
                }
            }
            return vector;
        }
        public static MatrixLong operator --(MatrixLong vector)
        {
            for (int i = 0; i < vector.N; i++)
            {
                for (int j = 0; j < vector.M; j++)
                {
                    vector[i, j]--;
                }
            }
            return vector;
        }
        public static bool operator true(MatrixLong vector)
        {
            for (int i = 0; i < vector.N; i++)
            {
                for (int j = 0; j < vector.M; j++)
                {
                    if (vector[i, j] == 0)
                        return false;
                }
            }

            return vector.N != 0 && vector.M != 0;
        }
        public static bool operator false(MatrixLong vector)
        {
            for (int i = 0; i < vector.N; i++)
            {
                for (int j = 0; j < vector.M; j++)
                {
                    if (vector[i, j] == 0)
                        return true;
                }
            }

            return vector.N != 0 && vector.M != 0;
        }
        public static bool operator !(MatrixLong vector) => vector.N != 0 && vector.M != 0;
        public static MatrixLong operator ~(MatrixLong vector)
        {
            for (int i = 0; i < vector.N; i++)
            {
                for (int j = 0; j < vector.M; j++)
                {
                    vector[i, j] = ~vector[i, j];
                }
            }

            return vector;
        }
        public static MatrixLong operator +(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] += vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator +(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] += vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator -(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] -= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator -(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] -= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator *(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] *= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator *(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] *= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator /(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] /= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator /(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] /= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator %(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] %= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator %(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] %= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator |(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] |= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator |(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] |= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator ^(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] ^= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator ^(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] ^= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator &(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] &= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator &(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] &= vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator <<(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] = (int)vector1[i, j] << (int)vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator <<(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] = (int)vector1[i, j] << (int)vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator >>(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] = (int)vector1[i, j] >> (int)vector2[i, j];
                }
            }

            return vector1;
        }
        public static MatrixLong operator >>(MatrixLong vector1, long[,] vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    vector1[i, j] = (int)vector1[i, j] >> (int)vector2[i, j];
                }
            }

            return vector1;
        }
        public static bool operator ==(MatrixLong vector1, MatrixLong vector2)
        {
            return vector1.Equals(vector2);
        }
        public static bool operator !=(MatrixLong vector1, MatrixLong vector2)
        {
            return !vector1.Equals(vector2);
        }
        public static bool operator >(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    if (vector1[i, j] < vector2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator <(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    if (vector1[i, j] > vector2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator >=(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    if (vector1[i, j] <= vector2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool operator <=(MatrixLong vector1, MatrixLong vector2)
        {
            for (int i = 0; i < vector1.N; i++)
            {
                for (int j = 0; j < vector1.M; j++)
                {
                    if (vector1[i, j] >= vector2[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
    /*----------------------*/
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CompGraphLab1
{

    [DebuggerDisplay("Matrix = {ToString()}")]
    public class Matrix
    {
        private float[,] _matrix;

        public int Rows { get { return _matrix.GetLength(0); } }
        public int Columns { get { return _matrix.GetLength(1); } }

        public bool IsSquare => (Rows == Columns);

        public float this[int row, int column]
        {
            get
            {
                return _matrix[row, column];
            }

            set
            {
                _matrix[row, column] = value;
            }
        }

        /// <summary>
        /// Warning: does not copy array data
        /// </summary>
        public Matrix(float[,] data)
        {
            _matrix = data;
        }

        public Matrix(int Rows, int Columns)
        {
            _matrix = new float[Rows, Columns];
        }

        /// <summary>
        /// Square Matrix constructor; Creates matrox of size m*x
        /// </summary>
        /// <param name="m"></param>
        public Matrix(int m) : this(m, m) { }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("[");
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    sb.Append($"{_matrix[row, col]:N2}").Append(" ");
                }
                sb.Append(";");
            }
            sb.Append("]");
            return sb.ToString();
        }

        public void Multiply(Matrix Matrix)
        {
            if (Columns != Matrix.Rows)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            var _result = new float[Rows, Matrix.Columns];
            for (int _row = 0; _row < Rows; _row++)
                for (int _col = 0; _col < Matrix.Columns; _col++)
                {
                    float _sum = 0;
                    for (int i = 0; i < Columns; i++)
                        _sum += _matrix[_row, i] * Matrix[i, _col];
                    _result[_row, _col] = _sum;
                }
            _matrix = _result;
        }

        public Vector3 Multiply(Vector3 vector)
        {
            Vector3 result = new Vector3();
            if (Columns != 3 || Rows!=3)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            result.x = _matrix[0, 0] * vector.x + _matrix[0, 1]*vector.y + _matrix[0, 2]*vector.z;
            result.y = _matrix[1, 0] * vector.x + _matrix[1, 1]*vector.y + _matrix[1, 2]*vector.z;
            result.z = _matrix[2, 0] * vector.x + _matrix[2, 1]*vector.y + _matrix[2, 2]*vector.z;
            return result;
        }

        public void HadamardProduct(Matrix Matrix)
        {
            if (Columns != Matrix.Columns || Rows != Matrix.Rows)
                throw new InvalidOperationException("Cannot multiply matrices of different sizes.");
            for (int _row = 0; _row < Rows; _row++)
                for (int _col = 0; _col < Columns; _col++)
                {
                    _matrix[_row, _col] *= Matrix[_row, _col];
                }
        }

        public void Multiply(float Scalar)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] *= Scalar;
                }
        }

        public void Add(Matrix Matrix)
        {
            if (Rows != Matrix.Rows || Columns != Matrix.Columns)
                throw new InvalidOperationException("Cannot add matrices of different sizes.");
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] += Matrix[_row, _col];
                }
        }

        public void Sub(Matrix Matrix)
        {
            if (Rows != Matrix.Rows || Columns != Matrix.Columns)
                throw new InvalidOperationException("Cannot sub matrices of different sizes.");
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] -= Matrix[_row, _col];
                }
        }

        public void Inverse()
        {
            if (!IsSquare)
                throw new InvalidOperationException("Only square matrices can be inverted.");
            int dimension = Rows;
            var result = _matrix.Clone() as float[,];
            var identity = _matrix.Clone() as float[,];
            //make identity matrix
            for (int _row = 0; _row < dimension; _row++)
                for (int _col = 0; _col < dimension; _col++)
                {
                    identity[_row, _col] = (_row == _col) ? 1.0f : 0.0f;
                }
            //invert
            for (int i = 0; i < dimension; i++)
            {
                float temporary = result[i, i];
                for (int j = 0; j < dimension; j++)
                {
                    result[i, j] = result[i, j] / temporary;
                    identity[i, j] = identity[i, j] / temporary;
                }
                for (int k = 0; k < dimension; k++)
                {
                    if (i != k)
                    {
                        temporary = result[k, i];
                        for (int n = 0; n < dimension; n++)
                        {
                            result[k, n] = result[k, n] - temporary * result[i, n];
                            identity[k, n] = identity[k, n] - temporary * identity[i, n];
                        }
                    }
                }
            }
            _matrix = identity;
        }

        public void Transpose()
        {
            var _result = new float[Columns, Rows];
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _result[_col, _row] = _matrix[_row, _col];
                }
            _matrix = _result;
        }

        public void Map(Func<float, float> func)
        {
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = func(_matrix[_row, _col]);
                }
        }

        public void Randomize(float lowest, float highest)
        {
            Random _random = new Random();
            float _diff = highest - lowest;
            for (int _row = 0; _row < _matrix.GetLength(0); _row++)
                for (int _col = 0; _col < _matrix.GetLength(1); _col++)
                {
                    _matrix[_row, _col] = ((float)_random.NextDouble() * _diff) + lowest;
                }
        }

        public void Randomize()
        {
            Randomize(0.0f, 1.0f);
        }

        public Matrix Duplicate()
        {
            var _result = new Matrix(Rows, Columns);
            for (int row = 0; row < Rows; row++)
                for (int col = 0; col < Columns; col++)
                {
                    _result[row, col] = _matrix[row, col];
                }
            return _result;
        }

        #region Overloaded operators
        public static Matrix operator ~(Matrix matrix)
        {
            var result = matrix.Duplicate();
            result.Transpose();
            return result;
        }

        public static Matrix operator !(Matrix matrix)
        {
            var result = matrix.Duplicate();
            result.Inverse();
            return result;
        }

        public static Matrix operator +(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.Add(second);
            return result;
        }

        public static Matrix operator -(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.Sub(second);
            return result;
        }

        public static Matrix operator *(Matrix first, Matrix second)
        {
            var result = first.Duplicate();
            result.Multiply(second);
            return result;
        }

        public static Vector3 operator *(Matrix first, Vector3 second)
        {
            var result = first.Duplicate();
            return result.Multiply(second);
        }

        public static Matrix operator *(Matrix matrix, float scalar)
        {
            var result = matrix.Duplicate();
            result.Multiply(scalar);
            return result;
        }

        public static Matrix operator *(float scalar, Matrix matrix)
        {
            var result = matrix.Duplicate();
            result.Multiply(scalar);
            return result;
        }
        #endregion
    }
}
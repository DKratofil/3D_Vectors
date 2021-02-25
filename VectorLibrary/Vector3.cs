using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VectorLibrary
{
    /// <summary>
    /// Vector Struct
    /// </summary>
    [ImmutableObject(true), Serializable]
    public struct Vector3
    {
        #region Variables
        /// <summary>
        /// The X component of the vector.
        /// </summary>
        private readonly double x;

        /// <summary>
        /// The Y component of the vector.
        /// </summary>
        private readonly double y;

        /// <summary>
        /// The Z component of the vector.
        /// </summary>
        private readonly double z;

        #endregion

        #region Constructor
        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        #endregion

        #region Accessors

        /// <summary>
        /// Get the x component of the Vector.
        /// </summary>
        public double X
        {
            get
            {
                return this.x;
            }
        }

        /// <summary>
        /// Get the y component of the Vector.
        /// </summary>
        public double Y
        {
            get
            {
                return this.y;
            }
        }

        /// <summary>
        /// Get the z component of the Vector.
        /// </summary>
        public double Z
        {
            get
            {
                return this.z;
            }
        }

        /// <summary>
        /// Gets the magnitude
        /// </summary>
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(this.SumComponentSqrs());
            }
        }

        /// <summary>
        /// Gets the Vector3 as an array.
        /// </summary> 
        [XmlIgnore]
        public double[] Array
        {
            get
            {
                return new[] { this.x, this.y, this.z };
            }
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return this.X;
                    case 1:
                        return this.Y;
                    case 2:
                        return this.Z;
                    default:
                        throw new ArgumentException("Should have three components");
                }
            }
        }

        #endregion

        #region Operators
        /// <summary>
        /// Overloading Add Operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                v1.X + v2.X,
                v1.Y + v2.Y,
                v1.Z + v2.Z);
        }
        /// <summary>
        /// Overloading Subtract Operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                v1.X - v2.X,
                v1.Y - v2.Y,
                v1.Z - v2.Z);
        }
        /// <summary>
        /// Overloading Scalar Multiplication Operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static Vector3 operator *(Vector3 v1, double s2)
        {
            return
                new Vector3(
                        v1.X * s2,
                        v1.Y * s2,
                        v1.Z * s2);
        }
        /// <summary>
        /// Overloading Division by Scalar Operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static Vector3 operator /(Vector3 v1, double s2)
        {
            return new Vector3(
                        v1.X / s2,
                        v1.Y / s2,
                        v1.Z / s2);
        }
        /// <summary>
        /// Inverse the Vector
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static Vector3 operator -(Vector3 v1)
        {
            return new Vector3(
                -v1.X,
                -v1.Y,
                -v1.Z);
        }
        /// <summary>
        /// overloading Equal operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return
                v1.X == v2.X &&
                v1.Y == v2.Y &&
                v1.Z == v2.Z;
        }
        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }

        #endregion

        #region value operation
        /// <summary>
        /// calculating Cross Product of vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector3 CrossProduct(Vector3 v1, Vector3 v2)
        {
            return
                new Vector3(
                        v1.Y * v2.Z - v1.Z * v2.Y,
                        v1.Z * v2.X - v1.X * v2.Z,
                        v1.X * v2.Y - v1.Y * v2.X);
        }

        public Vector3 CrossProduct(Vector3 other)
        {
            return CrossProduct(this, other);
        }
        /// <summary>
        /// calculating Dot Product of vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double DotProduct(Vector3 v1, Vector3 v2)
        {
            return
                v1.X * v2.X +
                v1.Y * v2.Y +
                v1.Z * v2.Z;
        }

        public double DotProduct(Vector3 other)
        {
            return DotProduct(this, other);
        }
        /// <summary>
        /// calculating angle Between vectors
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static double Angle(Vector3 v1, Vector3 v2)
        {
            // If the two vectors are equal then the angle is 0 
            if (v1 == v2)
            {
                return 0;
            }

            return Math.Acos(Math.Min(1.0f, v1.DotProduct(v2)));
        }
        public double Angle(Vector3 other)
        {
            return Angle(this, other);
        }
        /// <summary>
        /// Sum of componenets of a vector
        /// </summary>
        /// <param name="v1"></param>
        /// <returns></returns>
        public static double SumComponents(Vector3 v1)
        {
            return v1.X + v1.Y + v1.Z;
        }
        public double SumComponents()
        {
            return SumComponents(this);
        }
        /// <summary>
        /// check if two vectors are equal
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Vector3 other)
        {
            return
               this.X.Equals(other.X) &&
               this.Y.Equals(other.Y) &&
               this.Z.Equals(other.Z);
        }
        #endregion

        #region Helpers
        public static double SumComponentSqrs(Vector3 v1)
        {
            Vector3 v2 = SqrComponents(v1);
            return v2.SumComponents();
        }
        public double SumComponentSqrs()
        {
            return SumComponentSqrs(this);
        }
        public static Vector3 SqrComponents(Vector3 v1)
        {
            return new Vector3(
                v1.X * v1.X,
                v1.Y * v1.Y,
                v1.Z * v1.Z);
        }
        #endregion
    }
}

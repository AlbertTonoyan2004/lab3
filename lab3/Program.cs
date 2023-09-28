using System;
using System.Collections;
using System.Collections.Generic;
namespace lab3
{
    internal class Program
    {
        
        
        /// <summary>
        /// Задача 1
        /// </summary>
        
        
        struct Vector
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }

            public Vector(int X, int Y, int Z)
            {
                this.X = X;
                this.Y = Y;
                this.Z = Z;
            }

            public static Vector operator +(Vector v1, Vector v2)
            {
                return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
            }

            public static Vector operator *(Vector v1, Vector v2)
            {
                return new Vector(v1.X * v2.X, v1.Y * v2.Y, v1.Z * v2.Z);
            }
            public static Vector operator *(Vector v, int L)
            {
                return new Vector(v.X * L, v.Y * L, v.Z * L);
            }

            public static bool operator <(Vector v1, Vector v2)
            {
                double alg1 = Math.Sqrt(v1.X + v2.X + v1.Y + v2.Y + v1.Z + v2.Z);
                double alg2 = Math.Sqrt(v1.X + v2.X + v1.Y + v2.Y + v1.Z + v2.Z);
                return alg1 < alg2;
            }

            public static bool operator >(Vector v1, Vector v2)
            {
                double alg1 = Math.Sqrt(v1.X + v2.X + v1.Y + v2.Y + v1.Z + v2.Z);
                double alg2 = Math.Sqrt(v1.X + v2.X + v1.Y + v2.Y + v1.Z + v2.Z);
                return alg1 > alg2;
            }

            public static bool operator ==(Vector v1, Vector v2)
            {
                double alg1 = Math.Sqrt(v1.X + v2.X + v1.Y + v2.Y + v1.Z + v2.Z);
                double alg2 = Math.Sqrt(v1.X + v2.X + v1.Y + v2.Y + v1.Z + v2.Z);
                return alg1 == alg2;
            }

            public static bool operator !=(Vector v1, Vector v2)
            {
                
                return !(v1 == v2);
            }
        }

        /// <summary>
        /// конец задачи 1
        /// </summary>










        /// Задача 2

        class Car : IEquatable<Car>
        {
            public string Name { get; set; }
            public string Engine { get; set; }
            public double MaxSpeed { get; set; }
            

            public virtual string ToString()
            {
                return (Name);
            }

            public bool Equals(Car other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Name == other.Name && Engine == other.Engine && MaxSpeed.Equals(other.MaxSpeed);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((Car)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hash = (Name != null ? Name.GetHashCode() : 0);
                    hash = (hash * 397) ^ (Engine != null ? Engine.GetHashCode() : 0);
                    hash = (hash * 397) ^ MaxSpeed.GetHashCode();
                    return hash;
                }
            }
        }

        class CarsCatalog : Car
        {
            private List<Car> cars;

            public CarsCatalog()
            {
                cars = new List<Car>();
            }
            public Car this[int index]
            {
                get { return cars[index]; }
                set { cars[index] = value; }
            }

            public string this[Car car]
            {
                get { return $"{car.Name} - {car.Engine}"; }
            }
        


        }
        
        
        
        /// <summary>
        /// конец задачи 2
        /// </summary>
        
        
        
        
        
        /// Задача 3
        
        public class Currency
        {
            public double Value { get; set; }

            public Currency(double value)
            {
                Value = value;
            }
        }

        public class CurrencyUSD : Currency
        {
            public CurrencyUSD(double value) : base(value)
            {
            }

            public static implicit operator CurrencyEUR(CurrencyUSD usd)
            {
                double exchangeRate = 0.85; // user-defined exchange rate USD to EUR
                return new CurrencyEUR(usd.Value * exchangeRate);
            }

            public static implicit operator CurrencyRUB(CurrencyUSD usd)
            {
                double exchangeRate = 75.5; // user-defined exchange rate USD to RUB
                return new CurrencyRUB(usd.Value * exchangeRate);
            }
        }

        public class CurrencyEUR : Currency
        {
            public CurrencyEUR(double value) : base(value)
            {
            }

            public static implicit operator CurrencyUSD(CurrencyEUR eur)
            {
                double exchangeRate = 1.18; // user-defined exchange rate EUR to USD
                return new CurrencyUSD(eur.Value * exchangeRate);
            }

            public static implicit operator CurrencyRUB(CurrencyEUR eur)
            {
                double exchangeRate = 89.0; // user-defined exchange rate EUR to RUB
                return new CurrencyRUB(eur.Value * exchangeRate);
            }
        }

        public class CurrencyRUB : Currency
        {
            public CurrencyRUB(double value) : base(value)
            {
            }

            public static implicit operator CurrencyUSD(CurrencyRUB rub)
            {
                double exchangeRate = 0.013; // user-defined exchange rate RUB to USD
                return new CurrencyUSD(rub.Value * exchangeRate);
            }

            public static implicit operator CurrencyEUR(CurrencyRUB rub)
            {
                double exchangeRate = 0.011; // user-defined exchange rate RUB to EUR
                return new CurrencyEUR(rub.Value * exchangeRate);
            }
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        public static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 2, 3);
            Vector v2 = new Vector(4, 5, 6);

            // Addition
            Vector result1 = v1 + v2;
            Console.WriteLine($"Сложение: ({result1.X}, {result1.Y}, {result1.Z})");

            // Multiplication
            Vector result2 = v1 * v2;
            Console.WriteLine($"Умножение: ({result2.X}, {result2.Y}, {result2.Z})");

            // Scalar multiplication
            int scalar = 2;
            Vector result3 = v1 * scalar;
            Console.WriteLine($"Умнажение на число: ({result3.X}, {result3.Y}, {result3.Z})");

            // Comparison
            Console.WriteLine($"Comparison: v1 < v2 = {v1 < v2}");
            Console.WriteLine($"Comparison: v1 > v2 = {v1 > v2}");
            Console.WriteLine($"Comparison: v1 == v2 = {v1 == v2}");
            Console.WriteLine($"Comparison: v1 != v2 = {v1 != v2}"); 
            Console.WriteLine();
            
            
            
            
            Console.WriteLine($"/////////// Задача 2 ///////////");
            Console.WriteLine();
            
            
            
            Car car1 = new Car
            {
                Name = "Tesla",
                Engine = "Electric",
                MaxSpeed = 250.0
            };

            Car car2 = new Car
            {
                Name = "Ford",
                Engine = "Gasoline",
                MaxSpeed = 200.0
            };

            Console.WriteLine(car1.ToString()); // Выводит "Tesla"
            Console.WriteLine(car2.ToString()); // Выводит "Ford"

            Console.WriteLine(car1.Equals(car2)); // Выводит "False", так как объекты разные

            Car car3 = new Car
            {
                Name = "Tesla",
                Engine = "Electric",
                MaxSpeed = 250.0
            };

            Console.WriteLine(car1.Equals(car3)); // Выводит "True", так как объекты имеют одинаковые свойства
            Console.WriteLine(); 
            
            
            
            
            
            
            
            Console.WriteLine($"/////////// Задача 3 ///////////");
            Console.WriteLine();
            
            
            CurrencyUSD usd = new CurrencyUSD(100);
            CurrencyEUR eur = usd; // Implicit conversion USD to EUR based on exchange rate 
            CurrencyRUB rub = eur; // Implicit conversion EUR to RUB based on exchange rate

            Console.WriteLine("USD: " + usd.Value); // 100
            Console.WriteLine("EUR: " + eur.Value); // 85 (100 USD * 0.85 exchange rate)
            Console.WriteLine("RUB: " + rub.Value); // 6377.5 (85 EUR * 75.5 exchange rate)

            // Convert RUB to USD
            CurrencyUSD convertedUsd = rub;
            Console.WriteLine("Converted USD: " + convertedUsd.Value); // 85 (6377.5 RUB * 0.013 exchange rate)

            // Convert EUR to RUB
            CurrencyRUB convertedRub = eur;
            Console.WriteLine("Converted RUB: " + convertedRub.Value); // 7606.5 (85 EUR * 89.0 exchange rate)

            // Convert USD to EUR
            CurrencyEUR convertedEur = usd;
            Console.WriteLine("Converted EUR: " + convertedEur.Value); // 118 (100 USD * 1.18 exchange rate)

            Console.ReadLine();
            
            
            
            
            
        }
    }
}
using System;
using System.Collections.Generic;

namespace Solid
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenidos al calculo de figuras con un " +
                              "ejemplo C# implementando SOLID\n");
            var figuras = new IGeometricShape[]
            {
                new Rectangulo {Width =10,Height =5},
                new EquilateroTriangulo {SlideLength =5},
                new Rectangulo {Width =4,Height =6},
                new Cuadrado { SideLength = 10},
                new Rectangulo {Width =8,Height =9},
                new Cuadrado {SideLength =8},
                new EquilateroTriangulo {SlideLength =5}
            };
            var calcular = new GreatCalculator();
            calcular.Calcular(figuras);
            Console.WriteLine($"Área total: {calcular.TotalArea}\n"+
                              $"Perímetro total: {calcular.TotalPerimetro}");
        }
    }

    public class Rectangulo: IGeometricShape
    {
        public double Sides { get; } = 4;
        public double Height { get; set; }
        public double Width { get; set; }

        public double Area() 
        {
            return Height * Width;
        }

        public double Perimetro()
        {
            return Height * 2 + Width * 2;
        }
    }

    public class EquilateroTriangulo : IGeometricShape
    {
        public double Sides { get; } = 3;
        public double SlideLength { get; set; }

        public double Area()
        {
            return Math.Sqrt(3) * Math.Pow(SlideLength, 2) / 4;
        }
        public double Perimetro()
        {
            return SlideLength * 3;
        }
    }

    public class Cuadrado: IGeometricShape
    {
        public double Sides { get; }=4;
        public double SideLength { get; set; }

        public double Area()
        {
            return SideLength * SideLength;
        }

        public double Perimetro()
        {
            return SideLength * 4;
        }
    }

    public class AreaOperaciones
    {
        public double Suma(IEnumerable<IGeometricShape> shapes)
        {
            double area = 0;
            foreach (var shape in shapes)
                area += shape.Area();
            return area;
        }
    }

    public class PerimetroOperaciones
    {
        public double Sum(IEnumerable<IGeometricShape> shapes)
        {
            double perimetro = 0;
            foreach (var shape in shapes)
                perimetro += shape.Perimetro();
            return perimetro;
        }
    }

    public interface IGeometricShape : TengoArea, TengoPerimetro
    {   
    }

    public interface TengoPerimetro
    {
        double Perimetro();
    }

    public interface TengoArea
    {
        double Area();
    }

    public class GreatCalculator
    {
        public double TotalArea { get; private set; }
        public double TotalPerimetro { get; private set; }

        public void Calcular(IEnumerable <IGeometricShape> figuras)
        {
            var areaOperaciones = new AreaOperaciones();
            var perimetroOperaciones = new PerimetroOperaciones();
            TotalArea = areaOperaciones.Suma(figuras);
            TotalPerimetro = perimetroOperaciones.Sum(figuras);
        }
    }
}

using System;

namespace CSharpDesignPattern
{
	class Program
	{
        public abstract class Shape
        {
            private string Name { get; set; }
            protected IRenderer Renderer;

            public Shape(IRenderer renderer, string name)
            {
                Name = name;
                Renderer = renderer;
            }

            public override string ToString() => Renderer.Draw(Name);
        }

        public class Triangle : Shape
        {
            public Triangle(IRenderer render) : base(render, "Triangle")
            {
            }
        }

        public class Square : Shape
        {
            public Square(IRenderer render) : base(render, "Square")
            {
            }
        }

        // imagine VectorTriangle and RasterTriangle are here too

        public interface IRenderer
        {
            string Draw(string name);
        }

        public class RasterRenderer : IRenderer
        {
            public string Draw(string name)
            {
                return $"Drawing {name} as pixels";
            }
        }

        public class VectorRenderer : IRenderer
        {
            public string Draw(string name)
            {
                return $"Drawing {name} as lines";
            }
        }

        public class VectorSquare : Square
        {
            public VectorSquare() : base(new VectorRenderer())
            {

            }
        }

        public class RasterSquare : Square
        {
            public RasterSquare() : base(new RasterRenderer())
            {

            }
        }

        static void Main(string[] args)
		{
            var vectorSquare1 = new VectorSquare();
            Console.WriteLine(vectorSquare1.ToString());

            var rasterSquare1 = new RasterSquare();
            Console.WriteLine(rasterSquare1.ToString());
        }
	}
}

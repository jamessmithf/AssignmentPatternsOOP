namespace Decorator
{
    class Decorator
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Створюємо просту ялинку
            IChristmasTree tree = new ChristmasTree();

            // Додаємо прикраси
            tree = new OrnamentDecorator(tree);

            // Додаємо гірлянду
            tree = new GarlandDecorator(tree);

            // Відображаємо прикрашену ялинку
            tree.Display();

            Console.ReadKey();
        }
    }
    // Базовий інтерфейс для ялинки
    public interface IChristmasTree
    {
        void Display();
    }

    // Клас базової ялинки
    public class ChristmasTree : IChristmasTree
    {
        public void Display()
        {
            Console.WriteLine("Проста ялинка");
        }
    }

    // Абстрактний клас декоратора, який реалізує IChristmasTree
    public abstract class TreeDecorator : IChristmasTree
    {
        protected IChristmasTree tree;

        public TreeDecorator(IChristmasTree tree)
        {
            this.tree = tree;
        }

        public virtual void Display()
        {
            tree.Display();
        }
    }

    // Декоратор для додавання ялинкових прикрас
    public class OrnamentDecorator : TreeDecorator
    {
        public OrnamentDecorator(IChristmasTree tree) : base(tree) { }

        public override void Display()
        {
            base.Display();
            Console.WriteLine("Додані ялинкові прикраси");
        }
    }

    // Декоратор для додавання гірлянди
    public class GarlandDecorator : TreeDecorator
    {
        public GarlandDecorator(IChristmasTree tree) : base(tree) { }

        public override void Display()
        {
            base.Display();
            AddGarland();
        }

        private void AddGarland()
        {
            Console.WriteLine("Гірлянда світиться");
        }
    }
}

namespace Builder
{
    internal class Builder
    {
        class Pizza
        {
            string dough; // тісто 
            string sauce; // соус 
            string topping; // заправка
            public Pizza() { }
            public void SetDough(string d) { dough = d; }
            public void SetSauce(string s) { sauce = s; }
            public void SetTopping(string t) { topping = t; }
            public void Info() { Console.WriteLine($"Dough: {dough}\nSauce: {sauce}\nTopping: {topping}"); }
        }

        // Abstract Builder
        abstract class PizzaBuilder
        {
            protected Pizza pizza;
            public PizzaBuilder() { }
            public Pizza GetPizza() { return pizza; }
            public void CreateNewPizza() { pizza = new Pizza(); }
            public abstract void BuildDough();
            public abstract void BuildSauce();
            public abstract void BuildTopping();
        }

        // Concrete Builder for Hawaiian Pizza
        class HawaiianPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("cross"); }
            public override void BuildSauce() { pizza.SetSauce("mild"); }
            public override void BuildTopping() { pizza.SetTopping("ham+pineapple"); }
        }

        // Concrete Builder for Spicy Pizza
        class SpicyPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("panbaked"); }
            public override void BuildSauce() { pizza.SetSauce("hot"); }
            public override void BuildTopping() { pizza.SetTopping("pepperoni+salami"); }
        }

        // Concrete Builder for Margherita Pizza
        class MargheritaPizzaBuilder : PizzaBuilder
        {
            public override void BuildDough() { pizza.SetDough("thin crust"); }
            public override void BuildSauce() { pizza.SetSauce("tomato"); }
            public override void BuildTopping() { pizza.SetTopping("mozzarella+tomatoes+basil"); }
        }

        /** "Director" */
        class Waiter
        {
            private PizzaBuilder pizzaBuilder;
            public void SetPizzaBuilder(PizzaBuilder pb) { pizzaBuilder = pb; }
            public Pizza GetPizza() { return pizzaBuilder.GetPizza(); }
            public void ConstructPizza()
            {
                pizzaBuilder.CreateNewPizza();
                pizzaBuilder.BuildDough();
                pizzaBuilder.BuildSauce();
                pizzaBuilder.BuildTopping();
            }
        }

        /** A customer ordering a pizza. */
        class BuilderExample
        {
            public static void Main(string[] args)
            {
                Waiter waiter = new Waiter();

                // Creating Hawaiian Pizza
                PizzaBuilder hawaiianPizzaBuilder = new HawaiianPizzaBuilder();
                waiter.SetPizzaBuilder(hawaiianPizzaBuilder);
                waiter.ConstructPizza();
                Pizza hawaiianPizza = waiter.GetPizza();
                Console.WriteLine("Hawaiian Pizza:");
                hawaiianPizza.Info();

                // Creating Spicy Pizza
                PizzaBuilder spicyPizzaBuilder = new SpicyPizzaBuilder();
                waiter.SetPizzaBuilder(spicyPizzaBuilder);
                waiter.ConstructPizza();
                Pizza spicyPizza = waiter.GetPizza();
                Console.WriteLine("\nSpicy Pizza:");
                spicyPizza.Info();

                // Creating Margherita Pizza
                PizzaBuilder margheritaPizzaBuilder = new MargheritaPizzaBuilder();
                waiter.SetPizzaBuilder(margheritaPizzaBuilder);
                waiter.ConstructPizza();
                Pizza margheritaPizza = waiter.GetPizza();
                Console.WriteLine("\nMargherita Pizza:");
                margheritaPizza.Info();

                Console.ReadKey();
            }
        }
    }
}

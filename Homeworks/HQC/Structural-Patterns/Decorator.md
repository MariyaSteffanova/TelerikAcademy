## Decorator

### Същност
___
>* Позволява да добавяме функционалност към съществуващ обект по време на изпълнение на порграмата.
>* Пази референция към оригиналния обект, към който се добавя функционалността на декоратора.
>* Обекта, към който се добавя функционалността не знае за нея 
>	* Спазва Open/Closed принципа 

### Необходимост от употреба
___
* При експоненциално нарастване на наследяване. 
 
### UML диаграма
___
![alt text](Diagrams/DecoratorUML.png)

### Имплементация
___

###### Pancake (Component)

```c#
public abstract class Pancake
    {
        protected string Description { get; set; }
        protected double Calories { get; set; }

        public abstract double CalculateCalories();
        public abstract string GetDescription();
        public  void Display()
        {
              Console.WriteLine($"{this.GetDescription()}{Environment.NewLine}Calories: {this.CalculateCalories()}");
        }
    }
```

###### WholeGrainPancake (ConcreteComponent)

```c#
public class WholeGrainPancake : Pancake
    {

        public WholeGrainPancake()
        {
            this.Calories = 50;
            this.Description = "Healthy whole grain pancake!";
        }

        public override double CalculateCalories()
        {
            return this.Calories;
        }

        public override string GetDescription()
        {
            return this.Description;
        }

       
    }
```

###### GlutenFreePancake (ConcreteComponent)

```c#
 public class GlutenFreePancake : Pancake
    {
        public GlutenFreePancake()
        {
            this.Calories = 40;
            this.Description = "Gluten-free pancake!";
        }

        public override double CalculateCalories()
        {
            return this.Calories;
        }

        public override string GetDescription()
        {
            return this.Description;
        }
    }
```

###### PancakeDecorator (Decorator)

```c#
public abstract class PancakeDecorator : Pancake
    {
        public PancakeDecorator(Pancake pancake)
        {
            this.Pancake = pancake;
        }

        protected Pancake Pancake { get; set; }
    } 
```

###### ChocolateDecorator (ConcreteDecorator)
```c#
 public class ChocolateDecorator : PancakeDecorator
    {
        public ChocolateDecorator(Pancake pancake)
            : base(pancake)
        {
        }

        public override double CalculateCalories()
        {
            return this.Pancake.CalculateCalories() + 55.50;
        }

        public override string GetDescription()
        {
            return this.Pancake.GetDescription() + "\n\t + chocolate;";
        }
    }
```

###### BananaDecorator (ConcreteDecorator)
```c#
public class BananaDecorator : PancakeDecorator
    {
        public BananaDecorator(Pancake pancake)
            : base(pancake)
        {
        }

        public override double CalculateCalories()
        {
            return this.Pancake.CalculateCalories() + 33.30;
        }

        public override string GetDescription()
        {
            return this.Pancake.GetDescription() + "\n\t + banana;";
        }
    }
```
###### AgaveDecorator (ConcreteDecorator)
```c#
public class AgaveDecorator : PancakeDecorator
    {
        public AgaveDecorator(Pancake pancake)
            : base(pancake)
        {
        }

        public override double CalculateCalories()
        {
            return this.Pancake.CalculateCalories() + 20.6;
        }

        public override string GetDescription()
        {
            return this.Pancake.GetDescription() + "\n\t + agave syrup;";
        }
    }
```


###### Usage
```c#
public class Client
    {
        static void Main()
        {
            var pancake = new WholeGrainPancake();
            var pancakeWithChocolate = new ChocolateDecorator(pancake);
            var pancakeWithChocolateAndBanana = new BananaDecorator(pancakeWithChocolate);

            pancakeWithChocolateAndBanana.Display();

            Console.WriteLine(new string('=', 40));

            var glutenFreePancake = new GlutenFreePancake();
            var glutenFreePancakeWithBanana = new BananaDecorator(glutenFreePancake);
            var glutenFreePancakeWithBananaAndAgave = new AgaveDecorator(glutenFreePancakeWithBanana);

            glutenFreePancakeWithBananaAndAgave.Display();
        }
    }
```	




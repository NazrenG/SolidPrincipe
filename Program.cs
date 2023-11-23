
//Single Responsibility Principe

//telefonun qiymeti ve hesablanmasi ayri class daxilinde hesablanmalidir
namespace Single
{
    public class Sale
    {
        public double totalSale;
        public double CalculateSale()
        {
            return totalSale;
        }
    }
    public class Phone
    {
        public string? ModelName;
        public string? Processor;
        public string? DisplayMember;
        public string? RAM;
        public string? ROM;

        public Sale? TotalSale;
        public void SetSpecification()
        {
            //do work
        }
    }
}


//Open/Close Principe

//Her telefon modeli cixdiqca yeni spesifikasiyalar elave olunur,
//bu prisiple evvelki xarakteristikalar qalmaqla beraber yenisi elave olunur

namespace OpenClose
{
    public interface IModel
    {
        public void SetModel();
    }

    public class Iphone12 : IModel
    {
        public string? ModelName;

        public void SetModel()
        {
            //do work
        }
    }

    public class Iphone15 : IModel
    {
        public string? ModelName;

        public void SetModel()
        {
            //do work
        }
    }

    public class Phone
    {
        public string? ModelName;
        public string? Processor;
        public string? DisplayMember;
        public string? RAM;
        public string? ROM;

        public IModel? Model;
        public void SetSpecification()
        {
            //do work
        }
    }

}

//Liskow Principe

namespace Liskow
{

    //kvadrat duzbucaqli-dan torenen sinifdir ve
    //hec bir problem olmadan duzbucaqlinin xasselerini evez ede bilir
    public class Shape
    {
        public virtual double Area()
        {
            throw new NotImplementedException();
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double Area()
        {
            return Width * Height;
        }
    }

    public class Square : Rectangle
    {
        public override double Area()
        {
            return Width * Width;
        }
    }

}

//Interface

//her bir heyvanin ozune xas qabiliyyeti var ve bu prinsipe gore uygun interface-den implement edir
namespace Interface
{
    public interface ISwim
    {
        public void Swim();
    }
    public interface IFly
    {
        public void Fly();
    }
    public class Bird : IFly
    {
        public void Fly()
        {
            Console.WriteLine("The bird can fly");
        }  
    }
    public class Fish : ISwim
    {
        public void Swim()
        {
            Console.WriteLine("The fish can swim");
        }
    }
    public class Pelican : ISwim,IFly
    {
        public void Fly()
        {
            Console.WriteLine("The Pelican can fly");
        }

        public void Swim()
        {
            Console.WriteLine("The Pelican can swim");
        }
    }
    
}

//Dependency inversion

namespace Dependency
{
    //bu prinsipe gore High-level class(EmployeeDetail) Low-level(SalaryCalculator) classdan deyil interfaceden asilidir
    public interface ISalaryCalculator
    {
        float CalculateSalary(int hoursWorked, float hourlyRate);
    }
    public class SalaryCalculatorModified : ISalaryCalculator
    {
        public float CalculateSalary(int hoursWorked, float hourlyRate) => hoursWorked * hourlyRate;
    }
    public class EmployeeDetailsModified
    {
        private readonly ISalaryCalculator _salaryCalculator;

        public int HoursWorked { get; set; }
        public int HourlyRate { get; set; }
        public EmployeeDetailsModified(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }
        public float GetSalary()
        {
            return _salaryCalculator.CalculateSalary(HoursWorked, HourlyRate);
        }
    }
}
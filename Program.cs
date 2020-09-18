using System;

namespace OneNeuron
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smoothing { get; private set; } = 0.00001m;
            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }
            public decimal RestoreInputData(decimal output)
            {
                return output / weight;
            }
            public void Train(decimal input,decimal exceptedResult)
            {
                var actualResult = input * weight;
                LastError = exceptedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }
        }
        static void Main(string[] args)
        {
            decimal km = 100;
            decimal miles = 62.1371m;

            Neuron neuron = new Neuron();


            int i = 0;
            do
            {
                i++;
                neuron.Train(km, miles);
                if(i % 5000 == 0)
                Console.WriteLine($"Iterration: {i}\tError:\t{neuron.LastError}");
            } while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

            Console.WriteLine("Learning Neuron ends");

            
            Console.WriteLine($"{neuron.ProcessInputData(100)} miles in {100} km");
            Console.WriteLine($"{neuron.ProcessInputData(200)} miles in {200} km");
            Console.WriteLine($"{neuron.ProcessInputData(1000)} miles in {1000} km");
            Console.WriteLine($"{neuron.ProcessInputData(10)} miles in {10} km");

            Console.WriteLine($"{neuron.RestoreInputData(62.1371m)} km in {62.1371m} ml");
            
            //Console.WriteLine("Hello World!");
        }
    }
}

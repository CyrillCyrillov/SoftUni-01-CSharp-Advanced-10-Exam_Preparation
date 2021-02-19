using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;

           data = new List<Car>();

        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }
        
        
        public void Add(Car carToAdd)
        {
            if(data.Count < Capacity)
            {
                data.Add(carToAdd);
            }
        }
        
        public bool Remove(string manufacturer, string model)
        {
            Car carToRemove = data.FirstOrDefault(n => n.Manufacturer == manufacturer && n.Model == model);
            if(carToRemove == null)
            {
                return false;
            }

            data.Remove(carToRemove);
            return true;
        }

        
        public Car GetLatestCar()
        {
            return data.OrderByDescending(n => n.Year).FirstOrDefault();
        }

        
        public Car GetCar(string manufacturer, string model)
        {
            return data.FirstOrDefault(n => n.Manufacturer == manufacturer && n.Model == model);
        }

        /*
        •	GetStatistics() – returns a string in the following format:
        o	"The cars are parked in {parking type}:
        {Car1}
        {Car2}
        (…)"

         * */

        public string GetStatistics()
        {
            StringBuilder statisticsResult = new StringBuilder();
            statisticsResult.AppendLine($"The cars are parked in {Type}:");

            foreach (Car line in data)
            {
                statisticsResult.AppendLine($"{line.Manufacturer} {line.Model} ({line.Year})");
            }

            return statisticsResult.ToString();

        }

    }
}

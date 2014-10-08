using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Taxi
{
    public class Reader
    {
        public void ReaderFile(ref Taxi taxi, string fileName = "data.xml")
        {
            //  Taxi taxi1 = new Taxi();
            var settings = XDocument.Load("data.xml");
            var xml = XDocument.Load(fileName);
            var query = from c in xml.Root.Descendants("taxi")
                        select c.Attribute("type").Value + "\n Model: " +
                                c.Element("model").Value + "\n Speed: " +
                               c.Element("speed").Value;


            IEnumerable<Car> cars = settings.Root.Descendants("taxi").Select(x => new Car()
            {

                name = x.Attribute("type").Value,
                model = Convert.ToInt32(x.Element("model").Value),
                speed = Convert.ToInt32(x.Element("speed").Value)

            });
            var taxi1 = new Taxi() { CarsList = cars.ToList() };
            taxi = taxi1;
            foreach (string name in query)
            {
                //  taxi.CarsList.Add(name);
                Console.WriteLine("Cars: {0}", name);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace AdvanceAPI.Data_Serialization
{
    public class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Person() { }
        public Person(string name, int id)
        {
            this.Name = name;
            this.Id = id;
        }

        public override string ToString()
        {
            return $"Name is : {this.Name} and Id is : {this.Id}";
        }
    }
    internal class Tester
    {
        public static void TestNow()
        {
            //Data Serialization : The process of converting an object into a format that can be easily stored or transmitted
            Person person = new Person("NK",421 );

            //1) JSON 
            //-> we are using NewtonSoft.Json Package for this 
            //-> Basic JSON Serialization with Newtonsoft.Json:
            //    - Serialization: Converting an object to a JSON string.
            //    - Deserialization: Converting a JSON string back into an object.
            string json = JsonConvert.SerializeObject(person);
            Console.WriteLine(json);

            Person? newPerson = JsonConvert.DeserializeObject<Person>(json);
            Console.WriteLine(newPerson?.ToString());

            //-> This package have some conditions with DateTime object 
            //- Below is the required format
            //"2025-01-09T13:45:30.1234567Z";
            //-> other formats will through errors 
            //-> to handle this situation, we can use JsonSerializerSettings
            JsonSerializerSettings mySettings = new JsonSerializerSettings
            {
                DateFormatString = "dd-MM-yyyy",
            };

            string time = JsonConvert.SerializeObject(DateTime.Now, mySettings);
            Console.WriteLine(time);
            DateTime? time2 = JsonConvert.DeserializeObject<DateTime>(time,mySettings); // default is : MM-dd-yyyy
            Console.WriteLine(time2?.ToString());

            //2) XML
            //-> Here, we used System.Xml.Serialization namespace

            //Serialization --
            XmlSerializer xmls = new XmlSerializer(typeof(Person));

            StringWriter strw = new StringWriter();
            xmls.Serialize(strw,person);

            string xml = strw.ToString();
            Console.WriteLine(xml);
            strw.Close();

            //Deserialization -- 
            using(StringReader strr = new StringReader(xml))
            {
                if (strr == null) return;
                Person? xmlPerson = (Person?)xmls.Deserialize(strr);
                Console.WriteLine(xmlPerson);
            }
        }
    }
}

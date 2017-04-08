using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SerializationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee employee1 = new Employee(123, "Javid");
            var outputfile= SerializeEmployee(employee1);
            Console.WriteLine("Employee object is serialized to : "+ outputfile);
            Console.WriteLine("***********************************************");

            Console.WriteLine("Deserializing.......");

            Employee DeserializedEmployee = DeSerializeEmployee();
            Console.WriteLine("Employee Id: " + DeserializedEmployee.Id);
            Console.WriteLine("Employee Name: " + DeserializedEmployee.Name);
            Console.ReadKey();
        }
        private static string SerializeEmployee(Employee employee)
        {
            string output = System.Environment.CurrentDirectory + "\\employee.txt";
            FileStream stream = new FileStream(output, FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, employee);

            stream.Close();
            return output;
         }
        private static Employee DeSerializeEmployee()
        {
            FileStream stream = new FileStream(System.Environment.CurrentDirectory + "\\employee.txt", FileMode.OpenOrCreate);
            BinaryFormatter formatter = new BinaryFormatter();
            Employee employee = (Employee)formatter.Deserialize(stream);
                       
            stream.Close();
            return employee;
        }
    }
}

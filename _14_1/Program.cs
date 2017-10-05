using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //Måste läggas till för att skriva på fil. 

namespace _14_1
{
    struct Adress //Lägg dessa utanför struct person
    {
        public string street;
        public string city;

        public Adress(string street, string city)
        {
            this.street = street;
            this.city = city;
        }
    }

    enum Sex //Lägg utanför struct person
    {
        male,
        female
    }


    struct Person
    {

        public string firstName; //blir private. inte nåbar utifrån. går bara att hantera här inne. detta ändras med "public" framför
        public string lastName;
        public string phone;
        public string email;
        public Sex sex;
        public List<Adress> adresses;

        public Person(string firstName, string lastName, string phone, string email, Sex sex)
        {
            this.firstName = firstName;
            this.phone = phone;
            this.email = email;
            this.sex = sex;
            this.lastName = lastName;
            adresses = new List<Adress>();
        }

        public string FirstName { get => firstName; set => firstName = value; }

        internal void SetFirstName(string name)
        {
            FirstName = name;
        }

        internal void SetEmail(string emailadress)
        {
            email = emailadress;
        }

        internal void SetPhone(string phoneNumber)
        {
            phone = phoneNumber;
        }

        internal void SetSex(Sex sex)
        {
            this.sex = sex;
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            List<Person> contacts = new List<Person>();

            Person person1 = new Person("Håkan", "Johansson", "0086408", "mail1", Sex.male);
            person1.adresses.Add(new Adress("söder", "stockholm"));
            person1.adresses.Add(new Adress("kungsholmen", "stockholm"));

            contacts.Add(person1);

            Person person2 = new Person("Daniel", "Söderberg", "0701234554", "danielsmail@hotmail.com", Sex.male);
            contacts.Add(person2);

            Person person3 = new Person("David", "Davidsson", "0709987656", "325235ail@hotmail.com", Sex.male);
            contacts.Add(person3);

            Person person4 = new Person("Fredrik", "Fredriksson", "070998765456", "8900978ail@hotmail.com", Sex.male);
            contacts.Add(person4);

            PrintPerson(contacts);
            WriteToList(contacts);

        }


        private static void PrintPerson(List<Person> contacts)
        {
            foreach (Person person in contacts)
            {
                Console.WriteLine($"{person.firstName}");
                Console.WriteLine($"{person.lastName}");
                Console.WriteLine($"{person.email}");
                Console.WriteLine($"{person.phone}");
                Console.WriteLine("------");
                int i = 1;
                foreach (Adress adress in person.adresses)
                {
                    Console.WriteLine($"Adress {i++}");
                    Console.WriteLine($"{adress.street}");
                    Console.WriteLine($"{adress.city}");
                    Console.WriteLine("------");
                }
                Console.WriteLine("----------------------");
            }
        }

        private static void ReadFromFile(List<Person> contacts)
        {
            string[] content = File.ReadAllLines(filePath);

            for (int i = 0; i < content.Length; i++)
            {
                string[] data = content[i].Split(';');
                contacts.Add(new Person(data[0], data[2]));
            }
        }

        private void  SaveToList(List<Person> contacts)
        {
            string path = @"C:\ProjectX\Övning14\MYLIST.txt";
            string[] tmp = File.ReadAllLines(path);
            //foreach (Person person in contacts)
            //{
            //    File.WriteAllText(path, person.firstName);
            //}b
        }
    }
}

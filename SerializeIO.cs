using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * Write a Serialize and DeSerialize function for the Contact struct.
 * Serialize should write the contents of the object into a file
 * DeSerialize should read the contents of a file and assign them to the object's variables.
 */
namespace FileExercise
{
    struct Contact
    {
        public string name;
        public string email;
        public int id;
        public Contact(string name, string email, int id)
        {
            this.name = name;
            this.email = email;
            this.id = id;
        }
        //Prints out the object's name, email, and id
        public void Print()
        {
            Console.WriteLine(name + " | " + email + " | " + id);
        }
        //Writes the contents of an object into a file
        public void Serialize(string path)
        {
            //Writes the file
            if (!File.Exists(path))
            {
                try
                {
                    StreamWriter writer = new StreamWriter(path, false);
                    writer.WriteLine(name);
                    writer.WriteLine(email);
                    writer.WriteLine(id);
                    writer.Close();

                    try
                    {
                        writer.Dispose();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        //Reads the contents of the aforementioned file and assigns them to their variables
        public void DeSerialize(string path)
        {
            //Reads the file & assigns the contents to their appropriate variables
            try
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string fileName = reader.ReadLine();
                    name = fileName;
                    string fileEmail = reader.ReadLine();
                    email = fileEmail;
                    int fileId = Convert.ToInt32(reader.ReadLine());
                    id = fileId;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    internal class SerializeIO
    {
        public void Run()
        {
            //Make 3 contacts
            Contact bob = new Contact("Bob", "bob@email.com", 1234);
            Contact fred = new Contact("Fred", "fred@email.com", 8987);
            Contact jane = new Contact("Jane", "jane@email.com", 5432);

            // Write each contact to a file

            bob.Serialize(@"contacts\bob.txt");
            fred.Serialize(@"contacts\fred.txt");
            jane.Serialize(@"contacts\jane.txt");

            //Clear out contacts
            bob = new Contact();
            fred = new Contact();
            jane = new Contact();

            //Load contacts from file
            bob.DeSerialize(@"contacts\bob.txt");
            fred.DeSerialize(@"contacts\fred.txt");
            jane.DeSerialize(@"contacts\jane.txt");

            //Print contacts
            bob.Print();
            fred.Print();
            jane.Print();
        }
    }
}

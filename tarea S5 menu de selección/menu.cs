using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace tarea_s5
{
    class menu
    {
        static void Main()
        {
            bool showmenu = true;

            while (showmenu)
            {
                showmenu = Menu(); //llamado al metodo menu
            }
            Console.ReadKey();
        }

        private static bool Menu()
        {
            //crear menu para mostrar al usuario 
            Console.Clear(); //limpiar la consola
            Console.WriteLine("Que Opción desea Realizar ");
            Console.WriteLine("1. Registrar nuevo estudiante");
            Console.WriteLine("2. actualizar datos del estudiante");
            Console.WriteLine("3. Mostrar listado de alumnos registrados");
            Console.WriteLine("4. salir");
            Console.Write("\nOpcion: ");

            switch (Console.ReadLine())
            {
                case "1":
                    register();//llamado al metodo registrar
                    return true;
                case "2":
                    updateData();//llamado al metodo registrar
                    Console.ReadKey();
                    return true;

                case "3":
                    //mostrar el contenido del archivo 
                    Console.WriteLine("LISTADO DE ESTUDIANTES");
                    foreach (KeyValuePair<object, object> data in readFile())
                    {
                        Console.WriteLine("{0}, {1}", data.Key, data.Value);
                    }
                    Console.ReadKey();
                    return true;

                case "4":
                    return false;
                default:
                    return false;



            }
        }
        //metodo para obtener la ruta del archivo
        private static string getPath()
        {
            string path = @"C:\Users\Oscar Avalos\Desktop\tarea\registros.txt";
            return path;
        }
        //metodo para registrar nombres en archivo
        private static void register()
        {
            //solicitar datos
            Console.WriteLine("Datos del estudiante");
            Console.Write("Escriba Nombre completo:");
            string fullname = Console.ReadLine();
            Console.WriteLine("Escriba Edad:");
            int age = Convert.ToInt32(Console.ReadLine());

            //crear el archivo stremWriter para esciribir el archivo 
            using (StreamWriter SW = File.AppendText(getPath()))

            {
                SW.WriteLine("{0}; {1}", fullname, age);
                SW.Close();

            }

        }

        //metodo para leer el contenido del archivo 
        private static Dictionary<object, object> readFile()
        {
            //Declarar diccionario
            Dictionary<object, object> ListData = new Dictionary<object, object>();

            //uso del streamReader paar leer el archivo 
            using (var reader = new StreamReader(getPath()))
            {
                //variable para almacenar el contenido del arcivo 
                string Lines;

                while ((Lines = reader.ReadLine()) != null)//mientras no se encuenyre una linea vacia se ejecuta el ciclo

                {
                    string[] Keyvalue = Lines.Split(';');
                    if (Keyvalue.Length == 2)
                    {
                        ListData.Add(Keyvalue[0], Keyvalue[1]);
                    }

                }
            }
            //RETORNAR EL DICCIONARIO 
            return ListData;

        }

        //metodo para buscar por clave
        private static bool search(string name)
        {
            if (!readFile().ContainsKey(name))
            {
                return false;
            }
            return true;

        }
        //metodo para actualizar 
        private static void updateData()
        {
            //soliictar el elemento a modificar
            Console.WriteLine("Escriba el nombre del estudiante a actualizar: ");
            var name = Console.ReadLine();

            //Realizar la busqueda
            if (search(name))
            {
                Console.WriteLine("El registro existe");
                Console.Write("nueva edad: ");
                var newAge = Console.ReadLine();

                //Declarar un diccionario
                Dictionary<object, object> temp = new Dictionary<object, object>();
                temp = readFile();

                temp[name] = newAge; //actualizar el valor
                Console.WriteLine("El registro ha sido actualizado");
                File.Delete(getPath()); //eliminamos archivo y lo volvemos a crear con la actualización

                using (StreamWriter sw = File.AppendText(getPath()))
                {
                    //leer el diccionario temporal y almacenar los elementos en el archivo
                    foreach (KeyValuePair<object, object> values in temp)
                    {
                        sw.WriteLine("{0}; {1}", values.Key, values.Value);
                        //sw.Close();

                    }
                }


            }
            else
            {
                Console.WriteLine("EL regitro no se encontro");
            }


        }
    }
}

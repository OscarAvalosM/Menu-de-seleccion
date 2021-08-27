using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //permitira trabajr con las clases para manipular archivos

namespace manejoArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            //definir la ruta del archivo
            string path = @"C:\Users\Oscar Avalos\Desktop\tarea\texto.txt";

            //evaluar si el archivo exite
            if (File.Exists(path))
            {
                Console.WriteLine("El archivo exites");

                //leer el contenido del archivo linea por linea
                String[] lines;
                lines = File.ReadAllLines(path);
                Console.WriteLine("CONTENIDO UTILIZANDO ReadAllLines()");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }

                //leer el contenido del archivo
                Console.WriteLine("CONTENIDO UTILIZANDO ReadAllText()");
                String content;
                content = File.ReadAllText(path);
                Console.WriteLine(content);
            }
            else
            {
                //crear un archivo, y agregar texto
                using (StreamWriter archivo = File.AppendText(path))
                {
                    //contenido del archivo
                    archivo.WriteLine("Programación computacional");
                    archivo.WriteLine("Programación computacional");
                    archivo.Close();//cierra el archivo creado
                }
            }


            Console.ReadKey();
        }
    }
}
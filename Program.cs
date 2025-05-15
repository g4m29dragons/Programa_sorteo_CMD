//Datos de estudiante o autor.
//Nombre: Jesus Augusto Chacon Corredor
//Cedula: 85.150.769
//Codigo de Curso: 213023


namespace Trabajo_Componente_Practico
{
    using System;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            int[] numeros = new int[10];
            bool Funciono = false;

            Console.WriteLine("Welcome to the Number Sorter App!");

            // Input numbers from the user
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    Console.Write($"Enter number {i + 1}: ");
                    string entrada = Console.ReadLine();

                    // Check if input is a valid integer
                    Funciono = int.TryParse(entrada, out numeros[i]);
                    if (!Funciono)
                        Console.WriteLine("Invalid input. Please enter a valid integer.");
                } while (!Funciono);
            }

            Console.WriteLine("\nChoose a sorting method:");
            Console.WriteLine("1. Bubble Sort");
            Console.WriteLine("2. Shell Sort");
            Console.WriteLine("3. Selection Sort");
            Console.WriteLine("4. Insertion Sort");

            int Seleccio;
            do
            {
                Console.Write("Enter your choice (1-4): ");
                Funciono = int.TryParse(Console.ReadLine(), out Seleccio);
                if (!Funciono || Seleccio < 1 || Seleccio > 4)
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
            } while (!Funciono || Seleccio < 1 || Seleccio > 4);

            switch (Seleccio)
            {
                case 1:
                    BubbleSort(numeros);
                    break;
                case 2:
                    ShellSort(numeros);
                    break;
                case 3:
                    SelectionSort(numeros);
                    break;
                case 4:
                    InsertionSort(numeros);
                    break;
            }

            // Output sorted numbers to console
            Console.WriteLine("\nSorted numbers:");
            foreach (int num in numeros)
            {
                Console.WriteLine(num);
            }

            // Option to write sorted numbers to a file
            Console.Write("\nDo you want to save sorted numbers to a file? (yes/no): ");
            string GuardarSeleccion = Console.ReadLine().ToLower();
            if (GuardarSeleccion == "yes")
            {
                Console.Write("Enter file name: ");
                string filaNombres = Console.ReadLine();
                SaveToFile(numeros, filaNombres);
                Console.WriteLine($"Sorted numbers saved to {filaNombres}.");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // Bubble Sort
        static void BubbleSort(int[] arrai)
        {
            int n = arrai.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arrai[j] > arrai[j + 1])
                    {
                        // swap temp and arr[j]
                        int temp = arrai[j];
                        arrai[j] = arrai[j + 1];
                        arrai[j + 1] = temp;
                    }
                }
            }
        }

        // Shell Sort
        static void ShellSort(int[] arrai)
        {
            int n = arrai.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i += 1)
                {
                    int temp = arrai[i];
                    int j;
                    for (j = i; j >= gap && arrai[j - gap] > temp; j -= gap)
                        arrai[j] = arrai[j - gap];
                    arrai[j] = temp;
                }
            }
        }

        // Selection Sort
        static void SelectionSort(int[] arrai)
        {
            int n = arrai.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int miniíndice = i;
                for (int j = i + 1; j < n; j++)
                    if (arrai[j] < arrai[miniíndice])
                        miniíndice = j;
                int temp = arrai[miniíndice];
                arrai[miniíndice] = arrai[i];
                arrai[i] = temp;
            }
        }

        // Insertion Sort
        static void InsertionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;

                /* Move elements of arr[0..i-1], that are
                   greater than key, to one position ahead
                   of their current position */
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }

        // Save sorted numbers to a file
        static void SaveToFile(int[] arrai, string nombreArchivo)
        {
            using (StreamWriter writer = new StreamWriter(nombreArchivo))
            {
                foreach (int num in arrai)
                {
                    writer.WriteLine(num);
                }
            }
        }
    }
}
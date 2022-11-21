using System;
using System.Collections;

namespace MapSearch
{
    class Map
    {
        string Type { get; set; }

        public Map(string type)
        {
            this.Type = type;

            string option;
            string coordinates;
            string stringAddress; 
            string addressShow;
            string URL;

            bool exit = false;

            ArrayList address = new ArrayList();

            while (exit == false)
            {
                Console.WriteLine("\n[0] Para encerrar o programa");
                Console.WriteLine("[1] Para pesquisar coordenada existente");
                Console.WriteLine("[2] Para adicionar coordenada e endereço");
                Console.WriteLine("[3] Para listar os registros\n");
                
                option = Console.ReadLine();

                if (option == "1")
                {
                    Console.WriteLine("\nPesquisar coordenada existente:");

                    coordinates = Console.ReadLine();

                    URL = $"https://www.google.com.br/maps/@{coordinates},172m/data=!3m1!1e3";
                    Search(URL);
                }
                else if (option == "2")
                {
                    Console.Clear();
                    Console.WriteLine("\nAdicionar coordenadas (Exemplo: -25.4249653,-49.2697727) e Endereço:");

                    coordinates = Console.ReadLine();
                    stringAddress = Console.ReadLine();

                    addressShow = $"| {coordinates} | {stringAddress} |";
                    address.Add(addressShow);
                }
                else if (option == "3")
                {
                    foreach(var elements in address)
                    {
                        Console.WriteLine(elements);
                    }
                }
                else if (option == "0")
                {
                    exit = true;
                    Console.Clear();
                }
            }
        }

        private void Search(string urlMap)
        {
            Console.Clear();

            try
            {
                System.Diagnostics.Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe",urlMap);
            }
            catch(System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode==-2147467259)
                Console.WriteLine(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                Console.WriteLine(other.Message);
            }
        }
    }
}

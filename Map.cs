using System;

namespace MapSearch
{
    class Map
    {
        string Type { get; set; }

        public Map(string type)
        {
            this.Type = type;

            string coordinates; 
            string URL;

            bool exit = false;

            while (exit == false)
            {
                Console.Clear();
                Console.WriteLine("\n======================| Bem-vindo(a) ao Sistema Geográfico MapSearch |=======================");
                Console.WriteLine("= Favor inserir coordenadas para o sistema buscar no mapa (Exemplo: -25.4249653,-49.2697727) =");
                coordinates = Console.ReadLine();

                URL = $"https://www.google.com.br/maps/@{coordinates},172m/data=!3m1!1e3";

                if (coordinates == "0")
                {
                    exit = true;
                    Console.Clear();
                }
                else
                    Search(URL);
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

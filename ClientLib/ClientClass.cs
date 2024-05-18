using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Client
{
    public class ClientClass
    {

        /// <summary>
        /// Открытие порта
        /// </summary>
        public void OpenFlags()
        {
            Console.OutputEncoding = Encoding.GetEncoding(866);
            try
            {
                Communicate("localhost", 8888);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }
      
        /// <summary>
        /// отправка сообщения
        /// </summary>
        /// <param name="hostname"></param>
        /// <param name="port"></param>
        private static void Communicate(string hostname, int port)
        {
           
           
            byte[] bytes = new byte[1024];
            IPHostEntry ipHost = Dns.GetHostEntry(hostname);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            Socket socket = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipEndPoint);
            try
            {
                Console.Write("Введите фамилию, имя и отчество через запятую: ");
                string fio = Console.ReadLine();

                Console.Write("Участвует в марафоне (1/0): ");
                int marathon = int.Parse(Console.ReadLine());
                if ((marathon != 1 && marathon != 0))
                {
                   
                    Console.WriteLine("Введите корректные данные");
                }
                Console.Write("Участвует в полумарафоне (1/0): ");
                int halfMarathon = int.Parse(Console.ReadLine());
                if ((halfMarathon != 1 && halfMarathon != 0))
                {
                    Console.WriteLine("Введите корректные данные");
                }
                Console.Write("Выбран RFID браслет (1/0): ");
                int rfid = int.Parse(Console.ReadLine());
                if ((rfid != 1 && rfid != 0))
                {
                   
                    Console.WriteLine("Введите корректные данные");
                }
                Console.Write("Выбран нагрудник бегуна (1/0): ");
                int badge = int.Parse(Console.ReadLine());
                if ((badge != 1 && badge != 0))
                {
                   
                    Console.WriteLine("Введите корректные данные");
                }
                Console.Write("Выбрана бутылка для воды (1/0): ");
                int bottle = int.Parse(Console.ReadLine());
                if ((bottle != 1 && bottle != 0))
                {
                   
                    Console.WriteLine("Введите корректные данные");
                }
                Console.Write("Выбрана бандана с логотипом (1/0): ");
                int bandana = int.Parse(Console.ReadLine());
                if ((bandana != 1 && bandana != 0))
                {
                    
                    Console.WriteLine("Введите корректные данные");
                }

                Console.Write("Сумма для фонда 'Подари жизнь': ");
                int charity1 = int.Parse(Console.ReadLine());

                Console.Write("Сумма для фонда 'Вера': ");
                int charity2 = int.Parse(Console.ReadLine());

                Console.Write("Сумма для фонда 'Линия жизни': ");
                int charity3 = int.Parse(Console.ReadLine());
                string message = $"{fio},{{{marathon},{halfMarathon}}},{{{rfid},{badge},{bottle},{bandana}}},{{{charity1},{charity2},{charity3}}}";


            
            Console.WriteLine($"Подключаемся к порту {socket.RemoteEndPoint.ToString()} ");
            byte[] data = Encoding.UTF8.GetBytes(message);
            int bytesSent = socket.Send(data);
            int bytesRec = socket.Receive(bytes);
            Console.WriteLine($"\n Ответ сервера:\n {Encoding.UTF8.GetString(bytes, 0, bytesRec)} \n \n ");
            if (message.IndexOf("<The End>") == -1)
            {
                Communicate(hostname, port);
            }
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }

    }

}
//# Название приложения

//Приложения для передачи сообщений

//## Начало работы

//Для начала работы с приложением необходимо запустить выполняющий файл "ClientTest-master\bin\Debug\App.exe"

//### Необходимые условия

//Для корректной работы приложения необходимо удостовериться что в одной директории с выполняемым App.exe файлом находятся следующие файлы:
//    -App.exe.config
//    - App.pdb
//    - ServerLib.dll
//    - ClientLib.dll

//### Установка

//Для устоновк нужно склонировать репозиторий на компьютер

//## Автор

//Королева М.А.


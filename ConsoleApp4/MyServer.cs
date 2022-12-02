// ConsoleApp4
// ConsoleApp4
// MyServer.cs
// ---------------------------------------------
// Alex Samarkin
// Alex
// 
// 5:49 02 12 2022

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class MyServer
    {
        private HttpListener server = new HttpListener();

        public MyServer(string addres = "http://localhost:8001/info/")
        {
            server.Prefixes.Add(addres); // добавляем адрес
            server.Start(); // слушаем адрес
        }
        ~MyServer()
        {
            server.Close(); // закрываем сервер
        }

        public string Response = 
@"<!DOCTYPE html>
<html>
    <head> <meta charset='utf8'> </head>
    <body> <h2>Hello World!</h2> </body>
</html>";

        public async Task AnswerAsync()
        {
            var context = await server.GetContextAsync();

            var request = context.Request;  // получаем данные запроса
            var response = context.Response; // получаем объект для установки ответа
            var user = context.User; // получаем данные пользователя

            byte[] buffer = Encoding.UTF8.GetBytes(Response);
            
            response.ContentLength64 = buffer.Length;
            var output = response.OutputStream;
            
            await output.WriteAsync(buffer,0,buffer.Length);
            await output.FlushAsync();
            Console.WriteLine("OK!!!!");
        }
    }
}
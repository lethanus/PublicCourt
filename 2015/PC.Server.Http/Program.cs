using System;
using System.Net;
using System.Threading;
using System.Linq;
using System.Text;

namespace PC.Server.Http
{
    public class Program
    {
        static void Main(string[] args)
        {
            WebServer ws = new WebServer(SendResponse, "http://localhost:8081/test/", "http://localhost:8081/test2/");
            ws.Run();
            Console.WriteLine("A simple webserver. Press a key to quit.");
            Console.ReadKey();
            ws.Stop();
        }

        public static string SendResponse(HttpListenerRequest request)
        {
            return string.Format("<HTML><BODY>My web page.<br>{0}<br>{1}</BODY></HTML>", DateTime.Now, request.RawUrl);
        }
    }
}
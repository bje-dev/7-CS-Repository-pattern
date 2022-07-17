using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SL.SER
{
    public class LoggerManager
    {
        private string filePath;
        /*
         * 
         * ESTO ES EL SINGLETON LLAMADO DESDE EL SNIPPET
         * SE COMPLETA EN LA CLASE CON EL NOMBRE DE LA CLASE Y DOBLE TAB + CLICK
         * SE AGREGA EL FILEPATH EN EL CONSTRUCTOR Y LISTO
         * ES UNA FORMA MAS 
         * 
         * 
        public sealed class LoggerManager
        {

            //ESTA UNICA LINEA REALIZA EL CONTROL DE MULTITHREADING QUE SE USA CON EL LOCK
            private readonly static LoggerManager _instance = new LoggerManager();


        //CURRENT ES LA PROPERTY QUE VA EN LUGAR DEL GetInstance()
            public static LoggerManager Current
            {
                get
                {
                    return _instance;
                }
            }

            private LoggerManager()
            {
                filePath = ConfigurationManager.AppSettings["filePathLogger"];
            }
        }
        */





        private static LoggerManager loggerManager;

        private static object mutex = new object();


        private LoggerManager()
        {
            filePath = ConfigurationManager.AppSettings["filePathLogger"];
        }


        //SINGLETON CON CONTROL DE CONCURRENCIA - MULTITHREADING
        public static LoggerManager GetInstance()
        {
            if (loggerManager==null)
            {
                lock(mutex)
                {
                    if(loggerManager==null)
                    {
                        loggerManager = new LoggerManager();
                    }

                }
                

            }
                return loggerManager;
            
        }

        public void Write(string message, EventLevel eventlevel)
        {
         
            using (StreamWriter streamwriter = new StreamWriter(filePath, true))
            {
                streamwriter.WriteLine($"{DateTime.Now.ToString("dd-mm-yy hh:mm:ss")}[Severity{eventlevel.ToString()}]:{message}");
            }

        }
    }
}

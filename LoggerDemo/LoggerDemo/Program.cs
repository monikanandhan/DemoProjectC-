using System;
using System.IO;

namespace LoggerDemo
{

    public abstract class LogBase
    {
        public abstract void Log(string Message);
    }

    public class Filelogger :LogBase
    {
        private string Currentirectory { get; set; }
        private string FileName { get; set; }
        private string FilePath { get; set; }

        public Filelogger()
        {
            this.Currentirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = this.Currentirectory + "/" + this.FileName;
        }
        public override void Log(string Message)
        {
            using (StreamWriter w = File.AppendText(this.FilePath))
            {
                w.Write("\r\nLog Entry:");
                w.Write("{0}{1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.Write("{0}", Message);

            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var logger = new Filelogger();
            logger.Log("Hello");
            logger.Log("World");






            
        }
    }
}

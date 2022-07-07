using System.IO;
using System.Text;

namespace CurrencyConverter.Controller
{
    class LogController
    {
        string path = "logs.txt";

        public void Write(string value)
        {
            using (StreamWriter file = new StreamWriter(path, true, Encoding.Default))
            {
                file.WriteLine(value);
            }
        }
    }
}

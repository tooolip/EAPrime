using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAPrime
{
    public class FileParser
    {
        private string filepath;
        private ArrayList inputsList = new ArrayList();

        public FileParser(string filepath)
        {
            this.filepath = filepath;
        }

        public bool generateListFromFile()
        {
            try
            {
                FileStream fs = new FileStream(filepath, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                    addInputToList(sr.ReadLine());
                }

                sr.Close();
                fs.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Specified file cannot be found.");
                return false;
            }

            return true;
        }

        public bool addInputToList(string s)
        {
            try
            {
                int value = int.Parse(s);
                inputsList.Add(value);
            }
            catch (FormatException)
            {
                Console.WriteLine("Value in file is not of integer format.");
                return false;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Value in file is too large.");
                return false;
            }

            return true;
        }

        public int getInputCount()
        {
            return inputsList.Count;
        }

        public ArrayList getInputList()
        {
            return inputsList;
        }
    }
}

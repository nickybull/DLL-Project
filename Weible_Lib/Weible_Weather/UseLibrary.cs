using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;
using System.Xml;
using System.Net;
using Weible_Lib;

namespace Weible_Weather
{
    static public class UseLibrary
    {
        public static System.String searchFunction()
        {
            Console.Write("Enter Name of City: ");
            string city = Console.ReadLine();

            SearchClass.setSearch(city);
            string link = SearchClass.getLink();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(link);

            try
            {
                HttpWebResponse response = (HttpWebResponse)req.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string responseString = reader.ReadToEnd();

                reader.Close();
                responseStream.Close();
                response.Close();

                return responseString;
            }
            catch
            {
                Console.WriteLine("Bad Request");
                SystemException error = new SystemException("Bad Request");
                return error.ToString();
            }
        }
        public static String sortFunction(String xmlString)
        {
            StringBuilder output = new StringBuilder();

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
            {
                if (reader.ReadToFollowing("id"))
                    output.AppendLine(reader.ReadElementContentAsString());
                if (reader.ReadToFollowing("state"))
                    output.AppendLine(reader.ReadElementContentAsString());
                if (reader.ReadToFollowing("minDate"))
                    output.AppendLine(reader.ReadElementContentAsString());
                if (reader.ReadToFollowing("maxDate"))
                    output.AppendLine(reader.ReadElementContentAsString());
                if (reader.ReadToFollowing("score"))
                    output.AppendLine(reader.ReadElementContentAsString());
            }
            return output.ToString();
        }
        public static void run()
        {
            string xmlResult = searchFunction();
            string sortedResult = sortFunction(xmlResult);
            Console.WriteLine(sortedResult);

            System.Threading.Thread.Sleep(10000);
        }
    }
}

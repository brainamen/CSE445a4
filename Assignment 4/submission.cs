using System;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json;
using System.IO;



/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/


namespace ConsoleApp1
{


    public class Program
    {
        public static string xmlURL = "https://github.com/brainamen/CSE445a4/blob/master/Assignment%204/Hotels.xml";
        public static string xmlErrorURL = "https://github.com/brainamen/CSE445a4/blob/master/Assignment%204/HotelsErrors.xml";
        public static string xsdURL = "https://github.com/brainamen/CSE445a4/blob/master/Assignment%204/Hotels.xsd";

        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result);


            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);


            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        // Q2.1
        public static string Verification(string xmlUrl, string xsdUrl)
        {
            //create a xml reader setting with the xsd schema
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, xsdUrl);
            settings.ValidationType = ValidationType.Schema;
            //create a xml reader to read the xml file
            using (XmlReader reader = XmlReader.Create(xmlUrl, settings))
            {
                try
                {
                    //read the xml file and validate against the xsd schema
                    while (reader.Read())
                    {

                    }
                    return "No error";
                }
                catch(XmlSchemaValidationException exception)
                {
                    return exception.Message;
                }
                catch(Exception exception)
                {
                    return exception.Message;
                }
            }
            
        }

        public static string Xml2Json(string xmlUrl)
        {
            //load the xml file
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlUrl);
            //convert the xml document to json
            string jsonText = JsonConvert.SerializeXmlNode(xmlDocument, Newtonsoft.Json.Formatting.Indented, true);

            // The returned jsonText needs to be de-serializable by Newtonsoft.Json package. (JsonConvert.DeserializeXmlNode(jsonText))
            return jsonText;

        }
    }

}

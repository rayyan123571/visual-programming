using System;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine();
        Console.WriteLine("---------------------------------------------------Assignement 03-----------------------------------------------");
        Console.WriteLine();

        string fileName = "GPS.xml";

        // Create XML file
        CreateXmlFile(fileName);

        // Read and display XML file content
        ReadXmlFile(fileName);
    }

    static void CreateXmlFile(string fileName)
    {
        XmlWriterSettings settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "\t",
            Encoding = System.Text.Encoding.UTF8
        };

        using (XmlWriter writer = XmlWriter.Create(fileName, settings))
        {
            writer.WriteStartDocument(); // Start XML document
            writer.WriteStartElement("GPS_Log"); // Start root element

            // Add Position element with attributes and sub-elements
            writer.WriteStartElement("Position");
            writer.WriteAttributeString("DateTime", DateTime.Now.ToString());
            writer.WriteElementString("x", "65.8973342");
            writer.WriteElementString("y", "72.3452346");

            // Add SatteliteInfo element
            writer.WriteStartElement("SatteliteInformation");
            writer.WriteElementString("Speed", "40");
            writer.WriteElementString("NoOFSattlites", "7");
            writer.WriteEndElement(); // End SatteliteInfo

            writer.WriteEndElement(); // End Position

            // Add Image element with attributes and sub-elements
            writer.WriteStartElement("Image");
            writer.WriteAttributeString("Resolution", "1024x800");
            writer.WriteElementString("Path", @"\images\1.jpg");
            writer.WriteEndElement(); // End Image

            writer.WriteEndElement(); // End GPS_Log
            writer.WriteEndDocument(); // End XML document
        }

        Console.WriteLine("XML file created successfully.");
    }

    static void ReadXmlFile(string fileName)
    {
        Console.WriteLine("\nReading XML file...\n");

        using (XmlReader reader = XmlReader.Create(fileName))
        {
            while (reader.Read())
            {
                // When an element is encountered, print its name
                if (reader.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine($"Element: {reader.Name}"); // Print element name

                    // Check if the element has attributes
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute())  // Iterate through the attributes
                        {
                            Console.WriteLine($"  Attribute: {reader.Name} = {reader.Value}"); // Print attribute name and value
                        }
                    }
                }

                // When text content of the element is encountered, print it
                if (reader.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine($"  Value: {reader.Value}"); // Print the text content
                }
            }
        }

        Console.WriteLine("\nXML file read successfully.");
    }

}


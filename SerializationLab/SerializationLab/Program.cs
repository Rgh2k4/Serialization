using SerializationLab;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

#pragma warning disable SYSLIB0011

        string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        Console.WriteLine(path);

        Event e = new Event()
        {
            eventNumber = 1,
            location = "Calgary",
            event1 = "1 Calgary",
            event2 = "2 Edmonton",
            event3 = "3 Vancouver",
            event4 = "4 Saskatoon",
        };

        string pathBin = path + "/event.txt";
        string pathJSON = path + "/event.json";

        SerializeEvent(pathBin, e);
        DeserializeEvent(pathBin);

        SerializeJSON(pathJSON, e);
        DeserializeJSON(pathJSON);
    }

    public static void SerializeEvent(string path, Event e)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            binaryFormatter.Serialize(fs, e);
        }
    }

    private static void DeserializeEvent(string path)
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            Event e1 = (Event)binaryFormatter.Deserialize(fs);
            Console.WriteLine(e1);
        }
    }

    private static void SerializeJSON(string path, Event e)
    {
        string JSONstring = JsonSerializer.Serialize(e);
        File.WriteAllText(path, JSONstring);
    }

    private static void DeserializeJSON(string path)
    {
        Event e1 = JsonSerializer.Deserialize<Event>(File.ReadAllText(path));
        Console.WriteLine(e1);
    }

    public static void ReadFromFile(string path, Event e)
    {
        using (StreamWriter sw = new StreamWriter("event.txt"))
        {
            sw.WriteLine("Hackathon");
        }
        using (BinaryReader a = new BinaryReader(File.Open("event.txt", FileMode.Open)))
        {
            a.BaseStream.Seek(1, SeekOrigin.End);
        }
        using (BinaryReader b = new BinaryReader(File.Open("event.txt", FileMode.Open)))
        {
            b.BaseStream.Seek(5, SeekOrigin.End);
        }
        using (BinaryReader c = new BinaryReader(File.Open("event.txt", FileMode.Open)))
        {
            c.BaseStream.Seek(9, SeekOrigin.End);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SerializationLab
{
    [Serializable]
    public class Event
    {
        public double eventNumber { get; set; }

        public string location { get; set; }

        [JsonIgnore]

        public string event1 { get; set; }

        public string event2 { get; set; }

        public string event3 { get; set; }

        public string event4 { get; set; }

        public Event()
        {
        }

        public override string ToString()
        {
            return $"\neventNumber" +
                $"\nlocation" +
                $"\nevent1" +
                $"\nevent2" +
                $"\nevent3" +
                $"\nevent4" +
                $"\nReadFromFile";

        }
    }
}

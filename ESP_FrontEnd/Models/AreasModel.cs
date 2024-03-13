namespace ESP_FrontEnd.Models
{
    //https://json2csharp.com/
    public class Area
    {
        public string id { get; set; }
        public string name { get; set; }
        public string region { get; set; }
    }

    public class AreasModel
    {
        public List<Area> areas { get; set; }
    }
}

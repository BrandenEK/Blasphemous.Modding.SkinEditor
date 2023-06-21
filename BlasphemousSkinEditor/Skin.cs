
namespace BlasphemousSkinEditor
{
    [System.Serializable]
    public class Skin
    {
        public string id;
        public string name;
        public string author;
        public string version;

        public Skin(string id, string name, string author, string version)
        {
            this.id = id;
            this.name = name;
            this.author = author;
            this.version = version;
        }
    }
}

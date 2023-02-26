namespace BlasphemousSkinEditor
{
    [System.Serializable]
    public class Skin
    {
        public string id;
        public string name;
        public string author;

        public Skin(string id, string name, string author)
        {
            this.id = id;
            this.name = name;
            this.author = author;
        }
    }
}

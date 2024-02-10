namespace WindowsFormsApp1.models
{
    public class ItemTypeModel
    {
        private int iD;
        private string name;
        private string description;
        private int min;

        public ItemTypeModel(int iD, string name, string description, int min)
        {
            this.iD = iD;
            this.name = name;
            this.description = description;
            this.min = min;
        }

        // properties

        public int ID { get => iD; set => iD = value; }
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public int Min { get => min; set => min = value; }
    }
}

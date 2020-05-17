using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Serialization;

namespace Model
{
    public class GameModel
    {
        public double GameWidth { get; private set; }
        public double GameHeight { get; private set; }
        public static int ZeroAxios { get; private set; }
        public Player player;
        public LevelsResourses levelsResourses;
        public Screen screen;
        public int RespawnCX { get; set; }
        public int RespawnCY { get; set; }

        public GameModel(double w, double h)
        {
            GameWidth = w;
            GameHeight = h;
            ZeroAxios = (int)h / 2;
            RespawnCX = 10;
            RespawnCY = 50;
            player = new Player(RespawnCX, RespawnCY)
            {
                Lives = 3
            };
            levelsResourses = new LevelsResourses();
            screen = levelsResourses.screens["screen_1"];
        }

        public void Save(string FileName)
        {
            using (var writer = new System.IO.StreamWriter(FileName))
            {
                var serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(writer, this);
                writer.Flush();
            }
        }

        public static GameModel Load(string FileName)
        {
            using (var stream = System.IO.File.OpenRead(FileName))
            {
                var serializer = new XmlSerializer(typeof(GameModel));
                return serializer.Deserialize(stream) as GameModel;
            }
        }
    }
}

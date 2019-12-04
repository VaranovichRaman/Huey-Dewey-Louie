using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dungeon.Model;
using Newtonsoft.Json;

namespace Dungeon.Actions
{
    public class HSGameService
    {
        public List<HSCard> CreateDeck(string path)
        {
            string json = File.ReadAllText(path);
            List<HSCard> deck = JsonConvert.DeserializeObject<List<HSCard>>(json);
            return (deck.OrderBy(c => Guid.NewGuid()).ToList());
        }
    }
}

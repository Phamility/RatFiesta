using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Items.XConsumables;
using System.Collections.Generic;
using Terraria.DataStructures;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace RatFiesta.Mods
{
//To be completely honest with you - all I know is that this helps you add stuff to Boss Checklist and save that you beat a boss before.
    class ZaWarudo : ModWorld
    {
        public static bool DownedSlimeye = false;
        public override void Initialize()
        {
            DownedSlimeye = false;
        }
        public override TagCompound Save()
        {
            var Downed = new List<string>();
            if (DownedSlimeye) Downed.Add("Slimeye");
            return new TagCompound
            {
               
                {
                    "Downed",Downed
                }
            };
        }
        public override void Load(TagCompound tag)
        {
            var Downed = tag.GetList<string>("Downed");
            DownedSlimeye = Downed.Contains("Slimeye");
        }
        public override void LoadLegacy(BinaryReader reader)
        {
            int loadversion = reader.ReadInt32();
            if(loadversion == 0)
            {
                BitsByte flags = reader.ReadByte();
                DownedSlimeye = flags[0];
            }
        }
        public override void NetSend(BinaryWriter writer)
        {
            BitsByte flags = new BitsByte();
            flags[0] = DownedSlimeye;
            writer.Write(flags);
        }
        public override void NetReceive(BinaryReader reader)
        { BitsByte flags = reader.ReadByte();
            DownedSlimeye = flags[0]; }
    }
}

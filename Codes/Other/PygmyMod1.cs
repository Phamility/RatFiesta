using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using RatFiesta.Items.Accessories;

namespace RatFiesta.Items.Modifications
{
    class PygmyMod1 : GlobalItem
    {

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.PygmyNecklace)
            {
                player.minionDamage += .04f;
            }
        }
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
           

                if (item.type == ItemID.PygmyNecklace)
            {
                foreach (TooltipLine line in tooltips)
                {
                   
                    if (line.mod == "Terraria" && line.Name == "Tooltip0")
                    {
                        line.text = "Increases your max number of minions by one. \nIncreases summon damage by 4%.";
                    }
                }
            }
        }
    }
}

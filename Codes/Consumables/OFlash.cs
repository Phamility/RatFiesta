
using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
namespace RatFiesta.Items.XConsumables
{
    class OFlash : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.LightRed;

        }

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Timeline Anomaly");
            Tooltip.SetDefault("When visible, gain extraordinary speed!\nWhen hidden, reduce your damage by 30% but move at light speed!\nI am the fastest man alive.");

        }



        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (hideVisual == true)
            {
                player.runAcceleration *= 9f;
                player.maxRunSpeed *= 9f;
                player.allDamage -= .3f;

            }
            else
            {
                player.runAcceleration *= 2.24f;
                player.maxRunSpeed *= 2.24f;
            }
         
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

//My name is Barry Allen and I am the fastest man alive. To the outside world, I am an ordinary forensic scientist, but secretly with the help of my friends in S.T.A.R. Labs, I fight crime and find other meta-humans like me. I hunted down the man who killed my mother, but in doing so, I opened up our world to new threats, and I am the only one fast enough to stop them. I am The Flash.
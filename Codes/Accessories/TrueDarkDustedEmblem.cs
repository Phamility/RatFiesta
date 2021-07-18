using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using RatFiesta.Items.XConsumables;

using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;

namespace RatFiesta.Items.Accessories.EmblemSetUp
{
    class TrueDarkDustedEmblem : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 20);
            item.rare = ItemRarityID.Expert;
            item.expert = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("True Darkdusted Emblem");
            Tooltip.SetDefault("When visible, increase summon damage by 90%!\nWhen hidden, decrease max amount of minions by 4 and increase summon damage by 180%!\nA measly piece of the Dark Continent achieved greater feats then this realm could ever imagine.\nAn indescribale message from A Mysterious Force can be heard in your head when equipped.\n" +
                "The message gives you the thoughts of 'Interesting' Invintation' 'Journey' and 'More'");

        }
        public override void UpdateAccessory(Player player, bool showVisual)
        {
            if (showVisual == true)
            {
                player.minionDamage += 1.8f;
                player.maxMinions -= 4;
                
            }
            else
            {
                player.minionDamage += .9f;
            }
        }
        //ON OFF FOR MEGA SPIKE DAMAGE -6 SLOTS
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<TrueSundustedEmblem>());
            recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
           
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
           
        }


    }

}


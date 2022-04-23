
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
    class ODefense : ModItem
    {

        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 5);
            item.rare = ItemRarityID.Lime;

        }

        public override void SetStaticDefaults()
        {

            DisplayName.SetDefault("Spagooger's Valor");
            Tooltip.SetDefault("When visible, increases max health by 250!\nWhen hidden, removes defense but triples your max health!\nH P. I N E E D I T. \nA S M U C H A S I N E E D Y O U R T O E S!");

        }



        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (hideVisual == true)
            {
                player.statLifeMax2 *= 3;
                player.statDefense -= 1000;


            }
            else
            {
                player.statLifeMax2 += 300;
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

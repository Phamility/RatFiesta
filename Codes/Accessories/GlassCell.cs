using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.DataStructures;

using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
namespace RatFiesta.Items.Accessories.TGlass
{
    class GlassCell : ModItem
    {


        public override void SetDefaults()
        {


            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;


        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass DNA");
            Tooltip.SetDefault("Increase damage by 12% but reduce defense by 8!\nYou feel sharp yet a bit weak.");

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense -= 8;
            player.allDamage += .12f;


        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Glass, 25);



            recipe.AddTile(TileID.GlassKiln);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}

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
    class GlassCell2 : ModItem
    {


        public override void SetDefaults()
        {


            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 10);
            item.rare = ItemRarityID.Orange;


        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Cell");
            Tooltip.SetDefault("Increase damage by 25% but reduce defense by 16!\nThe glass cannon. I can feel its calling.");

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.statDefense -= 16;
            player.allDamage += .25f;


        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<GlassCell>());
            recipe.AddRecipeGroup(mod.Name + ":EvilFlesh", 10);
            recipe.AddIngredient(ItemID.Bone, 15);




            recipe.AddTile(TileID.GlassKiln);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}

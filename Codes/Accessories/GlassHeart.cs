using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.DataStructures;

using Terraria.ID;
using Terraria.ModLoader;
using RatFiesta.Mods;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
namespace RatFiesta.Items.Accessories.TGlass
{
    class GlassHeart : ModItem
    {

        public override void SetDefaults()
        {


            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 50);
            item.rare = ItemRarityID.Yellow;


        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Heart");
            Tooltip.SetDefault("Increase damage by 50% but increase damage taken by 44%!\nThis affects weapons that damage you.\nI feel like I can crack at any moment but, KONO POWA!");

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance -= .44f;
            player.allDamage += .50f;
            player.GetModPlayer<ExamplePlayer>().GlassHeartWorn = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<GlassCell2>());
            recipe.AddIngredient(ItemID.Ectoplasm, 5);






            recipe.AddTile(TileID.GlassKiln);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}

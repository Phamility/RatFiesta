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
using RatFiesta.Mods;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using RatFiesta.Items.XConsumables;
using System.Threading.Tasks;
namespace RatFiesta.Items.Accessories.TGlass
{
    class GlassSoul : ModItem
    {

        public override void SetDefaults()
        {


            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 12);
            item.rare = ItemRarityID.Expert;
            item.expert = true;
           

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Glass Soul");
            Tooltip.SetDefault("Increase damage by 100% but increase damage taken by 85%!\nThis affects weapons that damage you.\nBelieve in the Glass Cannon.\nEmbrace the Glass Cannon.\nBe the Glass Cannon.");

        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.endurance -= .85f;
            player.allDamage += 1f;
            player.GetModPlayer<ExamplePlayer>().GlassSoulWorn = true;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<GlassHeart>());
            recipe.AddIngredient(ModContent.ItemType<NDarkContinentFragment>());
            recipe.AddIngredient(ItemID.LunarBar, 4);








            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }


    }
}

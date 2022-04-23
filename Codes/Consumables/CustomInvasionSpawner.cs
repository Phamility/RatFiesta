using System;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

using RatFiesta.Items.Drops;
namespace RatFiesta.Invasion
{
    public class CustomInvasionSpawner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rat Maraca");
            Tooltip.SetDefault("Brings forth - The Rat Fiesta.\nNot Consumable\nRats, We're rats! We're the rats!");
        }
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.scale = 1;
            item.maxStack = 1;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.consumable = false;
            item.value = Item.buyPrice(0, 1, 0, 0);
            item.rare = ItemRarityID.Cyan;
        }
     
        public override bool UseItem(Player player)
        {

            if (!MWorld.customInvasionUp)
            {
                Main.PlaySound(SoundID.Roar, player.position, 0);

                Main.NewText("The Rat Fiesta shall soon commence.", 175, 75, 255, false);
                CustomInvasion.StartCustomInvasion();
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);


            recipe.AddIngredient(ItemID.LunarBar, 2);



            recipe.AddIngredient(ModContent.ItemType<PietyFrag>(), 2);
            recipe.AddIngredient(ItemID.FragmentNebula, 2);

            recipe.AddIngredient(ItemID.FragmentSolar, 2);

            recipe.AddIngredient(ItemID.FragmentStardust, 2);

            recipe.AddIngredient(ItemID.FragmentVortex, 2);

            recipe.AddTile(TileID.LunarCraftingStation); //at work bench

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
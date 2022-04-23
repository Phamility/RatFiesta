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
namespace RatFiesta.Items.Accessories
{
    class LunarFloat : ModItem
    {




        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 3);
            item.rare = ItemRarityID.Red;
            // item.summon = true;
            item.UseSound = SoundID.Item113;
            item.buffType = ModContent.BuffType<LunarBuff>();
            item.noMelee = true;
            item.noUseGraphic = true;

        }


        public override void SetStaticDefaults()
        {


            DisplayName.SetDefault("Celestial Mineral Manipulator");

            Tooltip.SetDefault("Wearing this item summons 70 Lunar Rocks that fly around you and do 40 damage.\n" +
                "Damage is increased to 51 in expert mode.\nDamage isn't affected by buffs.\n" +
                "Ryoiki Tenkai.");

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RockFloat>());
        
            recipe.AddIngredient(ItemID.FragmentStardust, 2);
            recipe.AddIngredient(ItemID.FragmentSolar, 2);
            recipe.AddIngredient(ItemID.FragmentVortex, 2);
            recipe.AddIngredient(ItemID.FragmentNebula, 2);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {





            bool HasBuff = player.HasBuff(ModContent.BuffType<LunarBuff>());



            if (HasBuff != true)

            // if (player.ownedProjectileCounts[ModContent.ProjectileType<ProbeSummon>()] <= 0)
            {
                //   Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ModContent.ProjectileType<ProbeSummon>(), 50, -5f, Main.myPlayer);

                player.AddBuff(item.buffType, 2);
            }




        }

    }

}


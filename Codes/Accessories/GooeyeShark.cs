using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using RatFiesta.Items.Drops;
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
    class GooeyeShark : ModItem
    {




        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 2);
            item.rare = ItemRarityID.Yellow;
            // item.summon = true;

            item.buffType = ModContent.BuffType<SharkBuff>();
            item.noMelee = true;
            item.noUseGraphic = true;

        }


        public override void SetStaticDefaults()
        {
      

            DisplayName.SetDefault("Gooeye Shark Necklace");
            Tooltip.SetDefault("Wearing this item summons a Gooeye Shark that does 225 damage to attack for you. \nDamage is increased to 350 in expert mode.\nDamage isn't affected by buffs.\nThe potential has been brought out!");

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<GooeyeNeck>());
            recipe.AddIngredient(ModContent.ItemType<FishronFin>());
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {





            bool HasBuff = player.HasBuff(ModContent.BuffType<SharkBuff>());



            if (HasBuff != true)

            // if (player.ownedProjectileCounts[ModContent.ProjectileType<ProbeSummon>()] <= 0)
            {
                //   Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ModContent.ProjectileType<ProbeSummon>(), 50, -5f, Main.myPlayer);

                player.AddBuff(item.buffType, 2);
            }




        }

    }

}


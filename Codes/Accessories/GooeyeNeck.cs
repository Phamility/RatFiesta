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
    class GooeyeNeck : ModItem
    {




        public override void SetDefaults()
        {

            item.width = 32;
            item.height = 32;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
            // item.summon = true;
            
            item.buffType = ModContent.BuffType<SolidifierBuff>();
            item.noMelee = true;
            item.noUseGraphic = true;

        }


        public override void SetStaticDefaults()
        {


            DisplayName.SetDefault("Gooeye Necklace");
            Tooltip.SetDefault("Wearing this item summons a Gooeye Blob that does 9 damage to attack for you. \nDamage is increased to 14 in expert mode.\nDamage isn't affected by buffs.\nIt has potential...");

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Gooeye>(),8);
             recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {





            bool HasBuff = player.HasBuff(ModContent.BuffType<SolidifierBuff>());



            if (HasBuff != true)

            // if (player.ownedProjectileCounts[ModContent.ProjectileType<ProbeSummon>()] <= 0)
            {
                //   Projectile.NewProjectile(player.position.X, player.position.Y, 0f, 0f, ModContent.ProjectileType<ProbeSummon>(), 50, -5f, Main.myPlayer);

                player.AddBuff(item.buffType, 2);
            }




        }

    }

}


using Microsoft.Xna.Framework;
using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
namespace RatFiesta.Items.Accessories.Infinity
{
    class SoulStone : ModItem
    {
        public static int souls = 0;
        public static int display;
        public static int isWearing = 0;
        public override void Update(ref float gravity, ref float maxFallSpeed)
        {
            gravity = 0f;
        }

        public override void SetDefaults()
        {

            item.width = 36;
            item.height = 36;
            item.accessory = true;
            item.value = Item.sellPrice(platinum: 1);
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(30, 2));

            item.rare = ItemRarityID.Green;
            ItemID.Sets.ItemNoGravity[item.type] = true;

        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Undying Resolve");
            Tooltip.SetDefault("Absorb the lifeforce of nearby enemies, granting you an increase of max health.\nThe more health you gain, the harder it is to absorb more.\nFor every 7 extra max health absorbed, gain 1 defense.");
            isWearing = 0;
        }

        public override void UpdateAccessory(Player player, bool showVisual)
        {
            player.AddBuff(ModContent.BuffType<SMD>(), 2);

            player.statDefense += (SoulsConsumed.howmuchushouldadd / 7);

            // Lighting.AddLight(player.Center, Color.Green.ToVector3() * (SoulsConsumed.howmuchushouldadd * .04f));
            if (showVisual == true)
            {
            }
            else
            {
                Lighting.AddLight(player.Center, Color.Green.ToVector3() * (SoulsConsumed.howmuchushouldadd * .04f));

            }
            if (Main.rand.Next(1, 60) == 2)
            {


                if ((Main.rand.Next(1, ((SoulsConsumed.howmuchushouldadd) + 4)) != 2))
                {
                    if ((Main.rand.Next(1, ((SoulsConsumed.howmuchushouldadd) + 2)) != 2))
                    {
                        if ((Main.rand.Next(1, ((SoulsConsumed.howmuchushouldadd) + 2)) != 2))
                        {
                            Dust.NewDust(player.position, player.width, player.height, DustID.Clentaminator_Green, player.velocity.X * 0.25f, player.velocity.Y * 0.25f, 150, default(Color), 0.7f);
                        }
                    }
                }
            }
        }



           
            

        

    
        
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<AKeyStone>());

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}

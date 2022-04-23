using RatFiesta.Buffs;
using RatFiesta.Minions;
using System;
using Terraria;
using System.IO;
using Microsoft.Xna.Framework;

using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.Utilities;
using System.Linq;
using Terraria.ModLoader.IO;
using System.Text;
using System.Threading.Tasks;
using RatFiesta.Mods;
using RatFiesta.Items.Drops;

namespace RatFiesta.Items.Weapons

{
    public class ADrainGun : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Shark");
            Tooltip.SetDefault("Costs 5 Health for each bullet!\n80% chance to not consume ammo.\nEAT RELIGION B-");
        }

        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.Megashark);
            item.damage = 111;
            item.ranged = true;
            item.width = 70;
            item.height = 28;
            item.maxStack = 1;
            item.useTime = 3;
            item.useAnimation = 3;
            // item.useStyle = 5;
            // item.knockBack = 2;
            item.value = Item.sellPrice(platinum: 4);
            item.rare = ItemRarityID.Red;
            item.UseSound = SoundID.Item36;
            item.noMelee = true;
            item.useAmmo = AmmoID.Bullet;
      //      item.shootSpeed = 4f;
            item.autoReuse = true;
        }
        public float InsertDamage = 5.4f;
        public float OogaBooga;
        public float FinalBooga;
        public float Tenpercent;
        public override Vector2? HoldoutOffset()
        {
            {
                return new Vector2(-20, 0);
            }
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY) * 50);
            if(Collision.CanHit(position, 0,0, position + muzzleOffset, 0,0))
            {
                position += muzzleOffset;
            }
            InsertDamage = 5.4f;
            if (player.HasBuff(114) == true)
            {
                Tenpercent = 1;
            }
            else
            {
                Tenpercent = 0;
            }
            if (Main.expertMode == true) { FinalBooga = InsertDamage + (player.statDefense / (1 / .75f)); }
            else if (Main.expertMode == false) { FinalBooga = InsertDamage + (player.statDefense / (1 / .5f)); }
            //Add .4 because rounding wack
            //Per usage, inflict 4 damage onto player (Ignores Defense)
            if (player.GetModPlayer<ExamplePlayer>().BreastWorn == true) { }
            else
            {
                player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " used too much of their soul!"), (int)Math.Round(FinalBooga + player.GetModPlayer<ExamplePlayer>().EnduranceForDrainGun1), 0);
                player.immune = false;
                player.immuneTime = 0;
            }
            return true;

        }
        public override bool ConsumeAmmo(Player player)
        {
            return Main.rand.NextFloat() >= .80f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Megashark);
            recipe.AddIngredient(ModContent.ItemType<PietyFrag>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
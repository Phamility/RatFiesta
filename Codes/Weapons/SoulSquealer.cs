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
using RatFiesta.Items.XConsumables;
using RatFiesta.Items.Accessories.TGlass;


namespace RatFiesta.InRat

{
    public class SoulSquealer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Squealer");
            Tooltip.SetDefault("Costs 50 Health for each shot!\nFires a barrage of 16 fireworks!\nI fell in love with you, lost control.\nSeriously though, do not lose control,\nIt's living dangerously.\nHowever, if you do get hurt-\nYou can always bounce back. Always.");
        }

        public override Vector2? HoldoutOffset()
        {
            {
                return new Vector2(-5, 0);
            }
        }
        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.SnowmanCannon);
            item.damage = 192;
            item.ranged = true;
            item.width = 56;
            item.height = 30;
            item.maxStack = 1;
            item.useTime = 40;
            item.useAnimation = 40;
            // item.useStyle = 5;
            // item.knockBack = 2;
            item.value = Item.sellPrice(platinum: 20);
            item.rare = ItemRarityID.Purple;
            item.UseSound = SoundID.NPCDeath4;
            item.noMelee = true;
            //item.rare = ItemRarityID.Expert;
            //  item.expert = true;
            item.useAmmo = AmmoID.None;
            item.shoot = ProjectileID.RocketFireworkBlue;


            //      item.shootSpeed = 4f;
            item.autoReuse = true;
        }
        public float InsertDamage = 40.4f;
        public float OogaBooga;
        public float FinalBooga;
        public float Tenpercent;
        public float Glass1;
        public float Glass2;

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {


            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY) * -20);
            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
            InsertDamage = 40.4f;

            Main.PlaySound(SoundID.Critter, player.position, 13);

            Main.PlaySound(SoundID.Critter, player.position, 13);

            Main.PlaySound(SoundID.Critter, player.position, 13);

            Main.PlaySound(SoundID.Critter, player.position, 13);

            Main.PlaySound(SoundID.Critter, player.position, 13);

            if (Main.expertMode == true) { FinalBooga = InsertDamage + (player.statDefense / (1 / .75f)); }
            else if (Main.expertMode == false) { FinalBooga = InsertDamage + (player.statDefense / (1 / .5f)); }
            //Add .4 because rounding wack
            //Per usage, inflict 4 damage onto player (Ignores Defense)
            if (player.GetModPlayer<ExamplePlayer>().BreastWorn == true) { }
            else
            {
                player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " used too much of their soul!"), (int)Math.Round((FinalBooga + (player.GetModPlayer<ExamplePlayer>().EnduranceForDrainGun2 * 3.5f))), 0);
                player.immune = false;
                player.immuneTime = 0;
            }
            int numberProjectiles = 16;
            for (int i = 0; i < numberProjectiles; i++)
            {
               
                        if (Main.rand.Next(1, 3) == 2)
                        {
                            if (Main.rand.Next(1, 3) == 2)
                            {
                                item.shoot = ProjectileID.RocketFireworkRed;

                            }
                            else
                            {
                                item.shoot = ProjectileID.RocketFireworkGreen;
                            }

                        }
                        else
                        {
                            if (Main.rand.Next(1, 3) == 2)
                            {
                                item.shoot = ProjectileID.RocketFireworkBlue;

                            }
                            else
                            {
                                item.shoot = ProjectileID.RocketFireworkYellow;
                            }

                        }

                    
                
            


                
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(70)); // 30 degree spread.
                // If you want to randomize the speed to stagger the projectiles
                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
                          // return true;

        } 
   
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.RocketLauncher);
            recipe.AddIngredient(ModContent.ItemType<RatEssence>(), 100);

            recipe.AddTile(ModContent.TileType<RatObeliskBlock>()); //at work bench
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
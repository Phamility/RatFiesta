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
    public class ADrainBow2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Un-Dead Bow");
            Tooltip.SetDefault("Heals 3 health for each arrow!\nFor just a moment, you don't feel dead inside!");
        }

        public override void SetDefaults()
        {

            item.CloneDefaults(ItemID.WoodenBow);
            item.damage = 22;
            item.ranged = true;
            item.width = 26;
            item.height = 56;
            item.maxStack = 1;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 20000;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.NPCHit2;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 4f;
            item.autoReuse = true;
        }
        public float InsertDamage = 4.4f;
        public float OogaBooga;
        public float FinalBooga;
        public float Tenpercent;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {

            /*  InsertDamage = 4.4f;
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
              player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " turned to gel!"), (int)Math.Round(FinalBooga + Tenpercent), 0);
              player.immune = false;
              player.immuneTime = 0;
            */
            if (player.statLife != player.statLifeMax2)
            {
                player.HealEffect(3);
            }
            player.statLife += 3;
            return true;

        }

     
    }
}
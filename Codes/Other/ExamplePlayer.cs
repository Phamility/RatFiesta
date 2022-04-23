
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using RatFiesta.Items.XConsumables;
using RatFiesta.Items.Weapons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using RatFiesta.Items.Accessories.Infinity;
using Terraria.ID;
using Terraria.ModLoader;
using RatFiesta.InRat;
using Terraria.ModLoader.IO;
namespace RatFiesta.Mods
{
    class ExamplePlayer : ModPlayer
    {
        public static bool tech;
		public bool GlassHeartWorn;
		public bool GlassSoulWorn;
		public float EnduranceForDrainGun2;
        public int RatWorn;
        public bool RatRingOn;
		public bool BreastWorn;
        public bool HatWorn;
        public static readonly int DashDown = 0;
        public static readonly int DashUp = 1;
        public static readonly int DashRight = 2;
        public static readonly int DashLeft = 3;
     //   public override void update
        //The direction the player is currently dashing towards.  Defaults to -1 if no dash is ocurring.
        public int DashDir = -1;

        //The fields related to the dash accessory
        public bool DashActive = false;
        public int DashDelay = MAX_DASH_DELAY;
        public int DashTimer = MAX_DASH_TIMER;
        //The initial velocity.  10 velocity is about 37.5 tiles/second or 50 mph
        public readonly float DashVelocity = 16f;
        //These two fields are the max values for the delay between dashes and the length of the dash in that order
        //The time is measured in frames
        public static readonly int MAX_DASH_DELAY = 50;
        public static readonly int MAX_DASH_TIMER = 35;
        public override void Hurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {
            if (RatWorn == 0)
            {
                Main.PlaySound(SoundID.Critter, player.position, 13);

                Main.PlaySound(SoundID.Critter, player.position, 13);

                Main.PlaySound(SoundID.Critter, player.position, 13);

                Main.PlaySound(SoundID.Critter, player.position, 13);

                Main.PlaySound(SoundID.Critter, player.position, 13);
            }
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource)
        {
            if(RatWorn == 0)
            {
                playSound = false;
            }
            return base.PreHurt(pvp, quiet, ref damage, ref hitDirection, ref crit, ref customDamage, ref playSound, ref genGore, ref damageSource);
        }
        public override void ResetEffects()
        {if (tech == false)
            {
                RatWorn = 5;
            }
                RatRingOn = false;
            tech = false;
            GlassHeartWorn = false;
			GlassSoulWorn = false;
            HatWorn = false;
			BreastWorn = false;
            //ResetEffects() is called not long after player.doubleTapCardinalTimer's values have been set

            //Check if the ExampleDashAccessory is equipped and also check against this priority:
            // If the Shield of Cthulhu, Master Ninja Gear, Tabi and/or Solar Armour set is equipped, prevent this accessory from doing its dash effect
            //The priority is used to prevent undesirable effects.
            //Without it, the player is able to use the ExampleDashAccessory's dash as well as the vanilla ones
            bool dashAccessoryEquipped = false;
            
//This is the loop used in vanilla to update/check the not-vanity accessories
            for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
            {
                Item item = player.armor[2];

                //Set the flag for the ExampleDashAccessory being equipped if we have it equipped OR immediately return if any of the accessories are
                // one of the higher-priority ones
                if (item.type == ModContent.ItemType<RatGearLegs>())
                    dashAccessoryEquipped = true;
                else if (item.type == ItemID.EoCShield || item.type == ItemID.MasterNinjaGear || item.type == ItemID.Tabi)
                    return;
        }

            //If we don't have the ExampleDashAccessory equipped or the player has the Solor armor set equipped, return immediately
            //Also return if the player is currently on a mount, since dashes on a mount look weird, or if the dash was already activated
            if(!dashAccessoryEquipped || player.setSolar || player.mount.Active || DashActive)
                return;

            //When a directional key is pressed and released, vanilla starts a 15 tick (1/4 second) timer during which a second press activates a dash
//If the timers are set to 15, then this is the first press just processed by the vanilla logic.  Otherwise, it's a double-tap
           if(player.controlRight && player.releaseRight && player.doubleTapCardinalTimer[DashRight] < 15)
                DashDir = DashRight;
            else if(player.controlLeft && player.releaseLeft && player.doubleTapCardinalTimer[DashLeft] < 15)
                DashDir = DashLeft;
            else
                return;     //No dash was activated, return

            DashActive = true;

            //Here you'd be able to set an effect that happens when the dash first activates
            //Some examples include:  the larger smoke effect from the Master Ninja Gear and Tabi
        }
        public float EnduranceForDrainGun1;
        public float EnduranceForDrainBow1;

        public float EnduranceForDrainBow3;

        public override void PostUpdate()
        {
			if (player.endurance >= 0)
			{
				EnduranceForDrainGun2 = (player.endurance) * 16;
                EnduranceForDrainBow3 = (player.endurance) * 21;
                EnduranceForDrainBow1 = (player.endurance) * 10;
                EnduranceForDrainGun1 = (player.endurance) * 10;

            }
            else
            {
				EnduranceForDrainGun2 = 0;
                EnduranceForDrainBow3 = (player.endurance) * 0;
                EnduranceForDrainBow1 = (player.endurance) * 0;
                EnduranceForDrainGun1 = (player.endurance) * 0;
            }
		}
		public override void SetupStartInventory(IList<Item> items, bool mediumcoreDeath)
		{
			Item item = new Item();
			item.SetDefaults(ModContent.ItemType<MinionSlotStat>());
			item.stack = 1;
			items.Add(item);
			Item item3 = new Item();
			item3.SetDefaults(ModContent.ItemType<MThreatStat>());
			item3.stack = 1;
			items.Add(item3);
		
			Item item4 = new Item();
			item4.SetDefaults(ItemID.WoodenBow);
			item4.stack = 1;
			items.Add(item4);
			Item item5 = new Item();
			item5.SetDefaults(ItemID.WoodenArrow );
			item5.stack = 299;
			items.Add(item5);
		
			Item item7 = new Item();
			item7.SetDefaults(ModContent.ItemType<AKeyStone>());
			item7.stack = 1;
			items.Add(item7);


		}
	
	}
}

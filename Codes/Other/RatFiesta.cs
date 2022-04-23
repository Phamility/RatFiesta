
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

using Terraria;
using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using RatFiesta.Mods;
using RatFiesta.Invasion;
using Terraria.UI;
namespace RatFiesta
{
    class MyMod : Mod
    {
        public override void UpdateMusic(ref int music, ref MusicPriority priority)
        {

            {
                if (Main.invasionX == Main.spawnTileX && Main.invasionSize >= 0 && Main.invasionType == -1) { music = MusicID.OldOnesArmy;
                    priority = MusicPriority.Event;
                } }
                
            
        }
        public override void PostSetupContent()
        {
            // Showcases mod support with Boss Checklist without referencing the mod
            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {
                bossChecklist.Call(
                    "AddBoss",
                    0f,
                    new List<int> { ModContent.NPCType<Slimeye>() },
                    this, // Mod
                    "Slimeye",
                    (Func<bool>)(() => ZaWarudo.DownedSlimeye),
                    ModContent.ItemType<Items.XConsumables.ABossSummon>(),
                          new List<int> {},
                        new List<int> {
                             ModContent.ItemType<Items.XConsumables.BossBag>(),
                            ModContent.ItemType<Items.Accessories.HeartOfRe>(),
                            ModContent.ItemType<Items.Drops.Gooeye>(),
                      ModContent.ItemType<Items.Accessories.GooeyeBear>() ,
                         ModContent.ItemType<Items.Accessories.GooeyeContract>() },



                     $"Use a [i:{ModContent.ItemType<Items.XConsumables.ABossSummon>()}] at night."

                );
                                bossChecklist.Call(
                    "AddEvent",
                    15f,
                    new List<int> {    ModContent.NPCType<RatImp>(),


                   ModContent.NPCType<RatImp1>(),
                     ModContent.NPCType<RatImp2>(),
                        ModContent.NPCType<RatImp3>(),
                        ModContent.NPCType<RatImp4>(),
                           ModContent.NPCType<RatWarrior>(),
                              ModContent.NPCType<RegenRat>(),
                                 ModContent.NPCType<SombreroRat>(),
                                 ModContent.NPCType<TFlyRat>(),
                                 ModContent.NPCType<TFlyRat1>(),
                                   ModContent.NPCType<FatRat>(),
                        ModContent.NPCType<FlyRat3>()},
                    this, // Mod
                    "The Rat Fiesta",
                    (Func<bool>)(() => Invasion.MWorld.downedCustomInvasion),
                    ModContent.ItemType<Invasion.CustomInvasionSpawner>(),
                          new List<int> {},
                        new List<int> {
                                                       ModContent.ItemType<InRat.RatEssence>(),                                  
                            ModContent.ItemType<InRat.RatOCheese>(),


                        },



                     $"Use a [i:{ModContent.ItemType<Invasion.CustomInvasionSpawner>()}]. Lasts until enough enemies are defeated.","The Rats have taken over!", "RatFiesta/CustomInvasionTexture", "RatFiesta/CustomInvasionHead"

                );
            }
        }
        public MyMod() { }

        public override void AddRecipeGroups()
        {

            //--------------------------------------------------------------------------
            var group = new RecipeGroup
            (
                () => Language.GetTextValue("LegacyMisc.37") + " Hardmode Tier 1 Ore", new int[]
                {
                    ItemID.CobaltOre,
                    ItemID.PalladiumOre //Use ItemType("SomeModItem") for mod items
                }
            );

            

            RecipeGroup.RegisterGroup(Name + ":CobaltPaladium", group);
            


            var group2 = new RecipeGroup
            (
                () => Language.GetTextValue("LegacyMisc.37") + " Hardmode Tier 2 Ore", new int[]
                {
                    ItemID.OrichalcumOre,
                    ItemID.MythrilOre //Use ItemType("SomeModItem") for mod items
                }
            );

            RecipeGroup.RegisterGroup(Name + ":OriMythril", group2);
            //--------------------------------------------------------------------------

            var group3 = new RecipeGroup
          (
              () => Language.GetTextValue("LegacyMisc.37") + " Hardmode Tier 3 Ore", new int[]
              {
                    ItemID.TitaniumOre,
                    ItemID.AdamantiteOre //Use ItemType("SomeModItem") for mod items
              }
          );

           RecipeGroup.RegisterGroup(Name + ":AdaTit", group3);
            //--------------------------------------------------------------------------
            /*var group4 = new RecipeGroup
            (
                () => Language.GetTextValue("LegacyMisc.37") + " True Sunnoner Emblem", new int[]
                {
                     ModContent.ItemType<TrueIlluminated>(),
                    ModContent.ItemType<TrueDarkened>(),
                    //Use ItemType("SomeModItem") for mod items
                }
            );

            RecipeGroup.RegisterGroup(Name + ":EmblemGroup", group4);
            */
            var group5 = new RecipeGroup
           (
               () => Language.GetTextValue("LegacyMisc.37") + " Evil Ore", new int[]
               {
                    ItemID.CrimtaneOre,
                    ItemID.DemoniteOre //Use ItemType("SomeModItem") for mod items
               }
           );



            RecipeGroup.RegisterGroup(Name + ":Evil", group5);
            //--------------------------------------------------------------------------
            var group6 = new RecipeGroup
        (
            () => Language.GetTextValue("LegacyMisc.37") + " Evil Flesh", new int[]
            {
                    ItemID.TissueSample,
                    ItemID.ShadowScale //Use ItemType("SomeModItem") for mod items
            }
        );



            RecipeGroup.RegisterGroup(Name + ":EvilFlesh", group6);

            var group7 = new RecipeGroup
        (
            () => Language.GetTextValue("LegacyMisc.37") + " Evil Bar", new int[]
            {
                    ItemID.CrimtaneBar,
                    ItemID.DemoniteBar //Use ItemType("SomeModItem") for mod items
            }
        );



            RecipeGroup.RegisterGroup(Name + ":EvilBar", group7);
        }
    }
}
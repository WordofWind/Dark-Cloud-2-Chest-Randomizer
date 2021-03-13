using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace DarkCloud2_ChestRandomizer
{
    public class Randomizer
    {      
        static int prevFloor;
        static int storeItem;
        static int itemID;
        static int currentAddress;     
        static int checkChest;
        static int itemRoll;
        static bool exitError;
        public static int itemAmount;
        static int[] dungeonAreaChestAddressUSA = { 0x20E656A0, 0x20E65D60, 0x20E67220, 0x20E67620, 0x20E681A0, 0x20E679A0, 0x20E68960 };
        static int[] dungeonAreaChestAddressPAL = { 0x20E8A520, 0x20E8ABE0, 0x20E8C0A0, 0x20E8C4A0, 0x20E8D020, 0x20E8C820, 0x20E8D7E0 };
        static int[] dungeonAreaChestAddress;

        static int currentFloorUSA = 0x21ECD638;
        static int currentFloorPAL = 0x21EFC658;
        static int currentFloor;

        static int currentDungeonUSA = 0x20376638;
        static int currentDungeonPAL = 0x2037C828;
        static int currentDungeon;

        static int dungeonCheckAddressUSA = 0x21E9F6E0;
        static int dungeonCheckAddressPAL = 0x21ECE1E0;
        static int dungeonCheckAddress;

        public static int gameVersion = 0;

        static int[] tier1weapons = { 1, 2, 9, 15, 22, 23, 24, 90 };
        static int[] tier2weapons = { 10, 11, 18, 25, 28, 31 };
        static int[] tier3weapons = { 3, 12, 17, 26, 35 };
        static int[] tier4weapons = { 4, 6, 13, 29, 32, 36 };
        static int[] tier5weapons = { 5, 7, 14, 16, 27, 37 };
        static int[] tier6weapons = { 8, 19, 30, 33, 38 };
        static int[] tier7weapons = { 20, 21, 34, 39, 40 };

        static int[] tier1weaponsmonica = { 41, 43, 44, 91 };
        static int[] tier2weaponsmonica = { 42, 46, 48, 61, 73, 92, 93, 110 };
        static int[] tier3weaponsmonica = { 45, 49, 54, 65, 67, 69, 74, 94, 104 };
        static int[] tier4weaponsmonica = { 47, 52, 58, 62, 68, 70, 76, 82, 95, 103 };
        static int[] tier5weaponsmonica = { 50, 51, 56, 64, 66, 71, 75, 85, 86, 97, 98, 100, 106 };
        static int[] tier6weaponsmonica = { 55, 59, 63, 72, 77, 80, 84, 87, 96, 99, 105, 107 };
        static int[] tier7weaponsmonica = { 57, 60, 78, 79, 81, 83, 88, 89, 101, 102, 108, 109 };

        static int[] tierclothes = { 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 123, 124, 125, 126, 127, 128, 129, 130, 131, 132, 133, 134, 258, 259, 260, 261, 262, 263, 264, 265, 266, 267 };
        static int[] tier1ridepod = { 135, 136, 145, 146, 147, 151, 155, 156, 157, 158, 163, 165, 166 };
        static int[] tier2ridepod = { 137, 138, 149, 159, 160, 161, 162, 167, 392, 393, 395, 398, 410 };
        static int[] tier3ridepod = { 139, 140, 148, 150, 152, 153, 154, 168, 394, 396, 399, 401, 404, 411 };
        static int[] tier4ridepod = { 141, 142, 169, 397, 400, 402, 405, 407, 412, 413, 416, 419 };
        static int[] tier5ridepod = { 170, 403, 406, 408, 409, 414, 417, 420 };
        static int[] tier6ridepod = { 415, 418, 421 };
        static int[] tierattachments = { 175, 176, 177, 178, 179, 180, 181, 182, 183, 184 };
        static int[] tiergems = { 186, 187, 188, 189, 190, 191, 192, 193, 194, 195, 196, 197 };
        static int[] tierraregems = { 198, 199 };
        static int[] tiercoins = { 200, 201, 202, 203, 204, 205, 206, 207, 208, 209 };
        static int[] tier1items = { 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223, 224, 226, 227, 228, 229, 230, 231, 232, 233, 234, 235, 236, 237, 238, 239, 240, 241, 242, 243, 244, 245, 253, 254, 255, 256, 257, 268, 269, 275, 276, 277, 278, 280, 281, 282, 283, 284, 285, 286, 287, 288, 289, 290, 291, 292, 293, 294, 298, 301, 312, 313, 314, 315, 316, 317, 318, 319, 352, 425 };
        static int[] tier2items = { 225, 270, 271, 272, 274, 279, 299, 304, 307, 377, 378, 379, 380, 381, 383, 390 };
        static int[] tier3items = { 273, 295, 296, 297, 376, 388, 389, 391 };
        static int[] tierfish = { 310, 320, 321, 322, 323, 324, 325, 326, 327, 328, 329, 330, 331, 332, 333, 334, 335, 336 };

        static Random rnd = new Random();
        public static void ChestRandomizer()
        {
            if (gameVersion == 1)
            {
                currentFloor = currentFloorPAL;
                dungeonAreaChestAddress = dungeonAreaChestAddressPAL;
                dungeonCheckAddress = dungeonCheckAddressPAL;
                currentDungeon = currentDungeonPAL;
            }
            else
            {
                currentFloor = currentFloorUSA;
                dungeonAreaChestAddress = dungeonAreaChestAddressUSA;
                dungeonCheckAddress = dungeonCheckAddressUSA;
                currentDungeon = currentDungeonUSA;
            }
            Console.WriteLine("Chest randomizer on");
            while (true)
            {              
                if (Memory.ReadByte(currentFloor) > 0)
                {
                    if (currentFloor != prevFloor)
                    {
                        Console.WriteLine("New floor");
                        Thread.Sleep(6000);
                        currentAddress = dungeonAreaChestAddress[Memory.ReadByte(currentDungeon)] + 0x0000005C;
                        Console.WriteLine("Waiting for map to spawn");
                        Console.WriteLine("Address: " + currentAddress);
                        while (Memory.ReadShort(currentAddress) != 306 )
                        {
                            Thread.Sleep(1);
                            if (Memory.ReadByte(currentFloor) == 0 || Memory.ReadByte(dungeonCheckAddress) > 2)
                            {
                                Console.WriteLine("Error, went out of dungeon");
                                exitError = true;
                                break;
                            }
                        }
                        if (exitError == false)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine("Map spawned on first chest");
                            Memory.WriteUShort(currentAddress, 305);
                            currentAddress += 0x00000070;
                            Memory.WriteUShort(currentAddress, 306);
                            currentAddress += 0x0000006C;

                            for (int i = 0; i < 8; i++)
                            {
                                checkChest = Memory.ReadByte(currentAddress);
                                if (checkChest == 1)
                                {
                                    break;
                                }
                                else if (checkChest < 128)
                                {
                                    currentAddress += 0x00000004;

                                    Memory.Write(currentAddress, BitConverter.GetBytes(GetItem()));
                                    currentAddress += 0x00000004;
                                    Memory.Write(currentAddress, BitConverter.GetBytes(itemAmount));
                                    Console.WriteLine("Added item!");
                                    currentAddress += 0x00000068;
                                }
                                else
                                {
                                    currentAddress += 0x00000004;
                                    Memory.Write(currentAddress, BitConverter.GetBytes(GetItem()));
                                    currentAddress += 0x00000002;
                                    Memory.Write(currentAddress, BitConverter.GetBytes(GetItem()));
                                    currentAddress += 0x00000002;
                                    Memory.WriteByte(currentAddress, 1);
                                    currentAddress += 0x00000002;
                                    Memory.WriteByte(currentAddress, 1);
                                    Console.WriteLine("Added double item!");
                                    currentAddress += 0x00000066;
                                }
                            }

                            prevFloor = currentFloor;
                        }
                        exitError = false;
                    }
                }
                else
                {
                    prevFloor = 200;
                }

                if (gameVersion == 1)
                {
                    if (Memory.ReadInt(0x203694D0) != 1701667175)
                    {
                        Thread.Sleep(1000);
                        if (Memory.ReadInt(0x203694D0) != 1701667175)
                        {
                            Program.ExitProgram();
                        }
                    }
                }
                else if (gameVersion == 2)
                {

                    if (Memory.ReadInt(0x20364BD0) != 1701667175)
                    {
                        Thread.Sleep(1000);
                        if (Memory.ReadInt(0x20364BD0) != 1701667175)
                        {
                            Program.ExitProgram();
                        }
                    }
                }

                Thread.Sleep(1);
            }
        }

        public static int GetItem()
        {
            itemRoll = rnd.Next(100);
            if (itemRoll < 5)
            {
                //weapons
                itemRoll = rnd.Next(100);
                if (itemRoll < 50)
                {
                    itemRoll = rnd.Next(1000);
                    if (itemRoll < 10)
                    {
                        storeItem = rnd.Next(0, tier7weapons.Length);
                        itemID = tier7weapons[storeItem];
                    }
                    else if (itemRoll < 30)
                    {
                        storeItem = rnd.Next(0, tier6weapons.Length);
                        itemID = tier6weapons[storeItem];
                    }
                    else if (itemRoll < 60)
                    {
                        storeItem = rnd.Next(0, tier5weapons.Length);
                        itemID = tier5weapons[storeItem];
                    }
                    else if (itemRoll < 120)
                    {
                        storeItem = rnd.Next(0, tier4weapons.Length);
                        itemID = tier4weapons[storeItem];
                    }
                    else if (itemRoll < 240)
                    {
                        storeItem = rnd.Next(0, tier3weapons.Length);
                        itemID = tier3weapons[storeItem];
                    }
                    else if (itemRoll < 480)
                    {
                        storeItem = rnd.Next(0, tier2weapons.Length);
                        itemID = tier2weapons[storeItem];
                    }
                    else
                    {
                        storeItem = rnd.Next(0, tier1weapons.Length);
                        itemID = tier1weapons[storeItem];
                    }

                    itemRoll = rnd.Next(100);
                    if (itemRoll == 0)
                    {
                        itemAmount = 2;
                    }
                    else
                    {
                        itemAmount = 1;
                    }
                }
                else
                {
                    itemRoll = rnd.Next(1000);
                    if (itemRoll < 10)
                    {
                        storeItem = rnd.Next(0, tier7weaponsmonica.Length);
                        itemID = tier7weaponsmonica[storeItem];
                    }
                    else if (itemRoll < 30)
                    {
                        storeItem = rnd.Next(0, tier6weaponsmonica.Length);
                        itemID = tier6weaponsmonica[storeItem];
                    }
                    else if (itemRoll < 60)
                    {
                        storeItem = rnd.Next(0, tier5weaponsmonica.Length);
                        itemID = tier5weaponsmonica[storeItem];
                    }
                    else if (itemRoll < 120)
                    {
                        storeItem = rnd.Next(0, tier4weaponsmonica.Length);
                        itemID = tier4weaponsmonica[storeItem];
                    }
                    else if (itemRoll < 230)
                    {
                        storeItem = rnd.Next(0, tier3weaponsmonica.Length);
                        itemID = tier3weaponsmonica[storeItem];
                    }
                    else if (itemRoll < 440)
                    {
                        storeItem = rnd.Next(0, tier2weaponsmonica.Length);
                        itemID = tier2weaponsmonica[storeItem];
                    }
                    else
                    {
                        storeItem = rnd.Next(0, tier1weaponsmonica.Length);
                        itemID = tier1weaponsmonica[storeItem];
                    }

                    itemRoll = rnd.Next(100);
                    if (itemRoll == 0)
                    {
                        itemAmount = 2;
                    }
                    else
                    {
                        itemAmount = 1;
                    }
                }
            }
            else if (itemRoll < 10)
            {
                //ridepod
                itemRoll = rnd.Next(1000);
                if (itemRoll < 10)
                {
                    storeItem = rnd.Next(0, tier6ridepod.Length);
                    itemID = tier6ridepod[storeItem];
                }
                else if (itemRoll < 40)
                {
                    storeItem = rnd.Next(0, tier5ridepod.Length);
                    itemID = tier5ridepod[storeItem];
                }
                else if (itemRoll < 90)
                {
                    storeItem = rnd.Next(0, tier4ridepod.Length);
                    itemID = tier4ridepod[storeItem];
                }
                else if (itemRoll < 200)
                {
                    storeItem = rnd.Next(0, tier3ridepod.Length);
                    itemID = tier3ridepod[storeItem];
                }
                else if (itemRoll < 400)
                {
                    storeItem = rnd.Next(0, tier2ridepod.Length);
                    itemID = tier2ridepod[storeItem];
                }
                else
                {
                    storeItem = rnd.Next(0, tier1ridepod.Length);
                    itemID = tier1ridepod[storeItem];
                }

                itemRoll = rnd.Next(50);
                if (itemRoll == 0)
                {
                    itemAmount = 2;
                }
                else
                {
                    itemAmount = 1;
                }
            }
            else
            {
                itemRoll = rnd.Next(100);

                if (itemRoll < 10)
                {
                    itemRoll = rnd.Next(120);
                    if (itemRoll < 5)
                    {
                        //raregems
                        storeItem = rnd.Next(0, tierraregems.Length);
                        itemID = tierraregems[storeItem];

                        itemRoll = rnd.Next(20);
                        if (itemRoll == 0)
                        {
                            itemAmount = 2;
                        }
                        else
                        {
                            itemAmount = 1;
                        }
                    }
                    else if (itemRoll < 20)
                    {
                        //coins
                        storeItem = rnd.Next(0, tiercoins.Length);
                        itemID = tiercoins[storeItem];

                        itemRoll = rnd.Next(100);
                        if (itemRoll == 0)
                        {
                            itemAmount = 3;
                        }
                        else if (itemRoll < 10)
                        {
                            itemAmount = 2;
                        }
                        else
                        {
                            itemAmount = 1;
                        }

                    }
                    else if (itemRoll < 40)
                    {
                        //gems
                        storeItem = rnd.Next(0, tiergems.Length);
                        itemID = tiergems[storeItem];

                        itemRoll = rnd.Next(100);
                        if (itemRoll == 0)
                        {
                            itemAmount = 3;
                        }
                        else if (itemRoll < 10)
                        {
                            itemAmount = 2;
                        }
                        else
                        {
                            itemAmount = 1;
                        }
                    }
                    else
                    {
                        //attachments
                        storeItem = rnd.Next(0, tierattachments.Length);
                        itemID = tierattachments[storeItem];

                        itemRoll = rnd.Next(100);
                        if (itemRoll < 5)
                        {
                            itemAmount = rnd.Next(5, 10);
                        }
                        else if (itemRoll < 10)
                        {
                            itemAmount = rnd.Next(3, 8);
                        }
                        else if (itemRoll < 30)
                        {
                            itemAmount = rnd.Next(1, 5);
                        }
                        else
                        {
                            itemAmount = rnd.Next(1, 3);
                        }
                    }
                }
                else
                {
                    itemRoll = rnd.Next(100);

                    if (itemRoll < 10)
                    {
                        itemRoll = rnd.Next(100);
                        if (itemRoll < 50)
                        {
                            //clothes
                            storeItem = rnd.Next(0, tierclothes.Length);
                            itemID = tierclothes[storeItem];

                            itemRoll = rnd.Next(100);
                            if (itemRoll < 10)
                            {
                                itemAmount = 2;
                            }
                            else
                            {
                                itemAmount = 1;
                            }

                        }
                        else
                        {
                            //fish
                            storeItem = rnd.Next(0, tierfish.Length);
                            itemID = tierfish[storeItem];

                            itemRoll = rnd.Next(100);
                            if (itemRoll < 10)
                            {
                                itemAmount = 2;
                            }
                            else
                            {
                                itemAmount = 1;
                            }
                        }
                    }
                    else
                    {                   
                        //items
                        itemRoll = rnd.Next(100);
                        if (itemRoll < 5)
                        {
                            storeItem = rnd.Next(0, tier3items.Length);
                            itemID = tier3items[storeItem];

                            itemRoll = rnd.Next(100);
                            if (itemRoll < 10)
                            {
                                itemAmount = 2;
                            }
                            else
                            {
                                itemAmount = 1;
                            }
                        }
                        else if (itemRoll < 20)
                        {
                            storeItem = rnd.Next(0, tier2items.Length);
                            itemID = tier2items[storeItem];

                            itemRoll = rnd.Next(100);
                            if (itemRoll < 10)
                            {
                                itemAmount = rnd.Next(2, 7);
                            }
                            else if (itemRoll < 30)
                            {
                                itemAmount = rnd.Next(1, 5);
                            }
                            else 
                            {
                                itemAmount = rnd.Next(1, 3);
                            }

                        }
                        else
                        {
                            storeItem = rnd.Next(0, tier1items.Length);
                            itemID = tier1items[storeItem];

                            itemRoll = rnd.Next(100);

                            if (itemRoll < 5)
                            {
                                itemAmount = rnd.Next(5, 16);
                            }
                            else if ( itemRoll < 20)
                            {
                                itemAmount = rnd.Next(3, 10);
                            }
                            else if (itemRoll < 40)
                            {
                                itemAmount = rnd.Next(2, 7);
                            }
                            else
                            {
                                itemAmount = rnd.Next(1, 5);
                            }
                        }
                        
                    }
                }
            }
            return itemID;
        }

    }
}

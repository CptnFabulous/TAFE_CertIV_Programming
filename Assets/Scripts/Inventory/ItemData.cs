using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemID)
    {
        string name = "";
        int value = 0;
        string description = "";
        string icon = "";
        string mesh = "";
        ItemType type = ItemType.Food;
        int heal = 0;
        int damage = 0;
        int armour = 0;
        int amount = 0;

        switch(itemID)
        {
            #region Food 0-99
            case 0:
                name = "Meat";
                value = 15;
                description = "Delicious, hearty meat. Good for building muscle mass, bad for gaining psychic powers.";
                icon = "Meat_Icon";
                mesh = "Meat_Mesh";
                type = ItemType.Food;
                heal = 20;
                amount = 1;
            break;

            case 1:
                name = "Chicken";
                value = 15;
                description = "A piece of chicken. It might taste like everything, but you'll still need other food in your diet.";
                icon = "Chicken_Icon";
                mesh = "Chicken_Mesh";
                type = ItemType.Food;
                heal = 15;
                amount = 1;
            break;

            case 2:
                name = "Bread";
                value = 15;
                description = "Bread provides carbohydrates, and you can wrap it around other foods to make it easier and cleaner to eat. Scientists refer to this serving method as a 'sandwich'.";
                icon = "Bread_Icon";
                mesh = "Bread_Mesh";
                type = ItemType.Food;
                heal = 15;
                amount = 1;
            break;
            #endregion

            #region Weapon 100-199
            case 100:
                name = "Longsword";
                value = 50;
                description = "A long sword for slashing at people from a longer distance away. The explanation is the only thing not long about this weapon.";
                icon = "Longsword_Icon";
                mesh = "Longsword_Mesh";
                type = ItemType.Weapon;
                damage = 15;
                amount = 1;
            break;
            case 101:
                name = "Shortsword";
                value = 50;
                description = "A smaller sword suitable for slashing and stabbing in tight spaces, such as a closet or a bedroom. It's not the size that counts, it's how you use it. Gosh, it sure is getting hot in here.";
                icon = "Shortsword_Icon";
                mesh = "Shortsword_Mesh";
                type = ItemType.Weapon;
                damage = 15;
                amount = 1;
            break;
            case 102:
                name = "Battleaxe";
                value = 50;
                description = "What this weapon lacks in range or dexterity, it makes up for with the ability to simply chop stuff up like a total badass. What kind of nerd would use a sword when you can decapitate a guy with one of these?";
                icon = "Battleaxe_Icon";
                mesh = "Battleaxe_Mesh";
                type = ItemType.Weapon;
                damage = 15;
                amount = 1;
            break;
            #endregion

            #region Apparel 200-299
            case 200:
                name = "Steel Helmet";
                value = 50;
                description = "This braces your bonce against blades, bludgeons, bullets, bombs and broken bottles in barfights.";
                icon = "Steel_Helmet_Icon";
                mesh = "Steel_Helmet_Mesh";
                type = ItemType.Apparel;
                armour = 15;
                amount = 1;
            break;
            case 201:
                name = "Wizard's Hat";
                value = 50;
                description = "No self-respecting sorceror goes without one of these fabric wonders. It increases your mana capacity so you can toss fireballs at people when they make fun of you for wearing such a stupid looking hat.";
                icon = "Wizard_Hat_Icon";
                mesh = "Wizard_Hat_Mesh";
                type = ItemType.Apparel;
                armour = 15;
                amount = 1;
            break;
            case 202:
                name = "Stylish Cap";
                value = 50;
                description = "This sporty number might have the defensive capabilities of an eggshell, but it'll make you look fabulous. Next time you're fighting a bandit, just show them pictures of all the women (or men) you've slept with, and they'll be too humiliated to kill you!";
                icon = "Stylish_Cap_Icon";
                mesh = "Stylish_Cap_Mesh";
                type = ItemType.Apparel;
                armour = 15;
                amount = 1;
            break;
            #endregion

            #region Crafting 300-399
            case 300:
                name = "Steel Plates";
                value = 10;
                description = "Created by smelting together iron and carbon, this tough alloy can be shaped into a myriad of useful components. Nothing funny to say here, it's literally just a piece of metal.";
                icon = "Steel_Plates_Icon";
                mesh = "Steel_Plates_Mesh";
                type = ItemType.Crafting;
                amount = 1;
            break;
            case 301:
                name = "Wooden Planks";
                value = 10;
                description = "Slabs of sturdy hardwood. When you build something with this stuff, it means that thing is at least partially made from the mutilated corpse of a tree. Brutal.";
                icon = "Wooden_Planks_Icon";
                mesh = "Wooden_Planks_Mesh";
                type = ItemType.Crafting;
                amount = 1;
            break;
            case 302:
                name = "Leather";
                value = 10;
                description = "Channel your inner serial killer by slaughtering an animal, peeling off their skin, treating it with chemicals and making clothing with it. Plus it's stylish, comfortable and durable!";
                icon = "Leather_Icon";
                mesh = "Leather_Mesh";
                type = ItemType.Crafting;
                amount = 1;
            break;
            #endregion

            #region Quest 400-499
            case 400:
                name = "Mysterious Documents";
                value = 10;
                description = "A stack of paper documents detailing the secret machinations of the organisation you're delivering them for. It's imbued with a curse that makes it violently explode if you try to read them.";
                icon = "Documents_Icon";
                mesh = "Documents_Mesh";
                type = ItemType.Quest;
                amount = 1;
            break;
            case 401:
                name = "Magical Macguffin";
                value = 10;
                description = "A complicated magical device that is apparently vital to securing the fate of the world, and must not fall into the hands of the enemy. But does anybody know what it does? It could be a back massager for all we know!";
                icon = "Magical_Macguffin_Icon";
                mesh = "Magical_Macguffin_Mesh";
                type = ItemType.Quest;
                amount = 1;
            break;
            case 402:
                name = "King Jeff";
                value = 78435420;
                description = "You've been tasked with escorting the king from his old castle to his new one. You've stuffed him in your enchanted bag of holding, since it's easier than escorting a frail old man through bandit country.";
                icon = "King_Jeff_Icon";
                mesh = "King_Jeff_Mesh";
                type = ItemType.Quest;
                amount = 1;
            break;
            #endregion

            #region Ingredients 500-599
            case 500:
                name = "Petrol";
                value = 10;
                description = "This highly flammable liquid has many applications in machinery and warfare, and many conflicts have been started over it. Sounds awfully familiar.";
                icon = "Petrol_Icon";
                mesh = "Petrol_Mesh";
                type = ItemType.Ingredients;
                amount = 1;
            break;
            case 501:
                name = "Salt";
                value = 10;
                description = "This crystalline powder can be used for chemistry and making food taste better. It's easily acquired by evaporating seawater, or emanating off sore losers of dice games in your local tavern.";
                icon = "Salt_Icon";
                mesh = "Salt_Mesh";
                type = ItemType.Ingredients;
                amount = 1;
            break;
            case 502:
                name = "Eyeball";
                value = 10;
                description = "There are two types of people in the world; those who might wonder what poor creature's head this eyeball was scooped out of, and those who will use it to cook some grisly elixirs. Or bypass retinal scan spells. Or hold it in your hand and perform an impression of the monster from that one Guillermo Del Toro movie.";
                icon = "Eyeball_Icon";
                mesh = "Eyeball_Mesh";
                type = ItemType.Apparel;
                amount = 1;
            break;
                #endregion

                #region Potions 600-699

                #endregion

                #region Scrolls 700-799

                #endregion

        }
        Item temp = new Item
        {
            Name = name,
            Description = description,
            ID = itemID,
            Value = value,
            Damage = damage,
            Armour = armour,
            Amount = amount,
            Heal = heal,
            Type = type,
            Mesh = Resources.Load("Prefabs/" + mesh) as GameObject,
            Icon = Resources.Load("Icons/" + icon) as Texture2D

        };
        return temp;
    }
}

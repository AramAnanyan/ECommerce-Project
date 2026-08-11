using System.ComponentModel;

namespace ECommerce.Domain.Enums;

public enum ProductCategory
{
    [Description("Electronics")]
    Electronics = 1,

    [Description("Laptops")]
    Laptops = 2,

    [Description("Audio")]
    Audio = 3,

    [Description("Accessories")]
    Accessories = 4,

    [Description("Fashion")]
    Fashion = 18,

    [Description("Home")]
    Home = 19,

    [Description("Toys")]
    Toys = 20,

    [Description("Sport")]
    Sport = 21,

    [Description("Furniture")]
    Furniture = 22,

    [Description("Cookware")]
    Cookware = 23,

    [Description("Appliances")]
    Appliances = 24,

    [Description("Board games")]
    BoardGames = 25,

    [Description("Action figures")]
    ActionFigures = 26,

    [Description("Crafts")]
    Crafts = 27,

    [Description("Clothing")]
    Clothing = 28,

    [Description("Footwear")]
    Footwear = 29,

    [Description("Gym")]
    Gym = 30,

    [Description("Camping gear")]
    CampingGear = 31,

    [Description("Bicycles")]
    Bicycles = 32,

    [Description("Athletic wear")]
    AthleticWear = 33
}

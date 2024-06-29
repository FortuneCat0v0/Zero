﻿namespace ET
{
    public enum ItemType
    {
        Equipment,
        Material,
        Consume
    }

    public enum ItemOpType
    {
        Add,
        Remove,
    }

    public enum ItemContainerType
    {
        Bag = 0,
        Equipment = 1,
    }

    public enum EquipmentType
    {
        None = 0, // 不可装备
        Head = 1, // 头盔
        Clothes = 2, // 衣服
        Shoes = 3, // 鞋子
        Ring = 4, // 戒指
        Weapon = 5, // 武器
        Shield = 6, // 盾牌
    }

    public enum EquipPosition
    {
        Head,
        Body,
        Underpants,
        LeftArm,
        RightArm,
        LeftLeg,
        RightLeg,
    }

    public enum EquipOp
    {
        Load,
        Unload,
    }

    public enum EntryType
    {
        Common = 1,
        Special = 2,
    }
}
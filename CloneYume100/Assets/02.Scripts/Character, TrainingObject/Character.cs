using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public enum LeaderSkill
    {
        None,
        HealUp, // ȸ���� ���� ��ų
        AttackUp // ���ݷ� ���� ��ų
    }

    public enum BattleSkill
    {
        None,
        LineDestroy, // �ǽ� �ٷ� ����
        ColorDestroy, // �ش� �Ӽ��� �ǽ� ����
        Heal, // ȸ��
        Change, // �ǽ� ��ȯ
        TimeUp // �ð� ȸ��
    }

    public enum CharacterColor
    {
        Red,
        Blue,
        Green,
        Yellow,
        Pupple
    }

    public int characterNum; // ĳ���� ��ȣ(ĳ���� ����Ʈ���� �� ��°����)

    public string chaName; // �̸�
    public int lv = 1; // Lv
    public int rare; // ���
    public CharacterColor color; // �Ӽ�
    public int attack; // ���ݷ�
    public int heal; // ȸ����
    public int hp;
    public BattleSkill battleSkill; // ��Ʋ ��ų
    public LeaderSkill leaderSkill; // ���� ��ų

    public Sprite characterImage; // ĳ���� �̹���
    public Sprite starsImage; // ��� �̹���
    public Sprite colorImage; // �Ӽ� �̹���

    public Character(int num, string name, int rare, CharacterColor color, int attack, int heal, int hp, BattleSkill bSkill, LeaderSkill lSkill, Sprite chaImage, Sprite starsImage, Sprite colorImage)
    {
        characterNum = num;
        chaName = name;
        this.rare = rare;
        this.color = color;
        this.attack = attack;
        this.heal = heal;
        this.hp = hp;
        battleSkill = bSkill;
        leaderSkill = lSkill;
        characterImage = chaImage;
        this.starsImage = starsImage;
        this.colorImage = colorImage;
    }
    
    protected void LevelUp() // ���� �� �Լ�
    {
        lv += 1;
        attack += 10;
        heal += 10;
        hp += 10;
    }
}

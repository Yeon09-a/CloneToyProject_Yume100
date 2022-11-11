using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public enum LeaderSkill
    {
        None,
        HealUp, // 회복력 증가 스킬
        AttackUp // 공격력 증가 스킬
    }

    public enum BattleSkill
    {
        None,
        LineDestroy, // 피스 줄로 제거
        ColorDestroy, // 해당 속성의 피스 제거
        Heal, // 회복
        Change, // 피스 변환
        TimeUp // 시간 회복
    }

    public enum CharacterColor
    {
        Red,
        Blue,
        Green,
        Yellow,
        Pupple
    }

    public int characterNum; // 캐릭터 번호(캐릭터 리스트에서 몇 번째인지)

    public string chaName; // 이름
    public int lv = 1; // Lv
    public int rare; // 레어도
    public CharacterColor color; // 속성
    public int attack; // 공격력
    public int heal; // 회복력
    public int hp;
    public BattleSkill battleSkill; // 배틀 스킬
    public LeaderSkill leaderSkill; // 리더 스킬

    public Sprite characterImage; // 캐릭터 이미지
    public Sprite starsImage; // 레어도 이미지
    public Sprite colorImage; // 속성 이미지

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
    
    protected void LevelUp() // 레벨 업 함수
    {
        lv += 1;
        attack += 10;
        heal += 10;
        hp += 10;
    }
}

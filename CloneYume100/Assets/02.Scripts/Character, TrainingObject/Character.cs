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
        Purple
    }

    public int characterNum; // 캐릭터 번호(캐릭터 리스트에서 몇 번째인지)
    public int getOrderNum; // 몇 번째로 획득하였는지(획득 순서)
    
    public string chaName; // 이름
    public int lv = 1; // Lv
    public int rare; // 레어도
    public CharacterColor color; // 속성
    public int attack; // 공격력
    public int heal; // 회복력
    public int hp;
    public int battlePiece; // 배틀 스킬 필요 피스
    public BattleSkill battleSkill; // 배틀 스킬
    public LeaderSkill leaderSkill; // 리더 스킬
    public int battleSkillInt; // 배틀 스킬에 필요한 정수(피스 개수나 회복 초 등)
    public int leaderSkillInt; // 리더 스킬에 필요한 정수(증가 % 등)

    public Sprite characterImage; // 캐릭터 이미지
    public Sprite starsImage; // 레어도 이미지
    public Sprite colorImage; // 속성 이미지

    public string battleSkillName;
    public string leaderSkillName;

    public Character(int num, string name, int rare, CharacterColor color, int attack, int heal, int hp, BattleSkill bSkill, LeaderSkill lSkill, Sprite chaImage, Sprite starsImage, Sprite colorImage, string battleSkillInfo, int battlePiece, int battleInt, string leaderSkillInfo, int leaderInt)
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
        battleSkillName = battleSkillInfo;
        this.battlePiece = battlePiece;
        battleSkillInt = battleInt;
        leaderSkillName = leaderSkillInfo;
        leaderSkillInt = leaderInt;
    }
    
    protected void LevelUp() // 레벨 업 함수
    {
        lv += 1;
        attack += 10;
        heal += 10;
        hp += 10;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
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

    protected string chaName; // 이름
    protected int lv = 1; // Lv
    protected int rare; // 레어도
    protected CharacterColor color; // 속성
    protected int attack; // 공격력
    protected int heal; // 회복력
    protected int hp;
    protected BattleSkill battleSkill; // 배틀 스킬
    protected LeaderSkill leaderSkill; // 리더 스킬

    protected void LevelUp() // 레벨 업 함수
    {
        lv += 1;
        attack += 10;
        heal += 10;
        hp += 10;
    }
}

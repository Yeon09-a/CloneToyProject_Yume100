using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
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

    protected string chaName; // �̸�
    protected int lv = 1; // Lv
    protected int rare; // ���
    protected CharacterColor color; // �Ӽ�
    protected int attack; // ���ݷ�
    protected int heal; // ȸ����
    protected int hp;
    protected BattleSkill battleSkill; // ��Ʋ ��ų
    protected LeaderSkill leaderSkill; // ���� ��ų

    protected void LevelUp() // ���� �� �Լ�
    {
        lv += 1;
        attack += 10;
        heal += 10;
        hp += 10;
    }
}

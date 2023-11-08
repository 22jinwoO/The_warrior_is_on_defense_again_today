//       �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
//      | ArmorCalculate ��ũ��Ʈ�� ��� ���� ��罽 ���� ��ũ��Ʈ (�Ƹ�Ÿ���� ��罽 ���� Ÿ���� �� ���) |
//       �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailArmor : ArmorCalculate
{
    public override float DecreaseDamaged(unit_Data attackType, unit_Data ArmorType)  // ���ݴ����� �� ȣ���ϴ°� ������ ��
    {
        if (ArmorType.m_eUnit_Defense_Property != eUnit_Defense_Property_States.mail_Armor) // ��� Ÿ���� ��罽 ������ �ƴϸ�
        {
            return 0f;
        }
        float attackDamge = 0;

        switch (attackType.m_eUnit_Attack_Property)  // ���� Ÿ�� ����
        {
            case eUnit_Attack_Property_States.slash_Attack: // ���� ���� �� ��
                attackDamge = attackType.unit_Attack_Damage * 1.0f;
                break;

            case eUnit_Attack_Property_States.piercing_Attack: // ������� �� ��
                attackDamge = attackType.unit_Attack_Damage * 0.6f;
                break;

            case eUnit_Attack_Property_States.crushing_attack: // �м���� �� ��
                attackDamge = attackType.unit_Attack_Damage * 1.5f;
                break;

            default:
                break;
        }

        return attackDamge;


    }
}

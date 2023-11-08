//       �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
//      | �÷��̾� �����̶�� �������� ��� �ϳ��� Ŭ������ ���� �ѹ��� ����|
//       �ѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤѤ�
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


// �Լ��̸��� ��縻�� ���� ����, enum�� �����̸� �տ� �ҹ��� e �ۼ�, ������ ī��ǥ������� �ҹ��� ���� �ܾ� ù���� �빮��
[Serializable]
public struct unit_Data    // ���� ������ �������� ����ü
{
    public string m_unit_Name;            // ���� �̸�
    public float m_unit_Health;             // ���� ü��
    public eUnit_Attack_Property_States m_eUnit_Attack_Property;    // ���� ���ݼӼ�
    public float unit_Attack_Damage;    // ���� ���� ������
    public eUnit_Defense_Property_States m_eUnit_Defense_Property; // ���� ���Ӽ�
    public string m_unit_Description;     // ���� ����
    public string m_unit_Type;            // ���� Ÿ��
    public float m_unit_MoveSpeed;        // ���� �̵��ӵ�
    public float m_unit_Outlook;          // ���� �þ�
    public float m_unit_Attack_Range;     // ���� ���� ����

}

public enum eUnit_Attack_Property_States  // ���� ���� Ÿ��
{
    Default = 0,
    slash_Attack,       // ���� ����
    piercing_Attack,    // ���� ����
    crushing_attack     // �м� ����
}

public enum eUnit_Defense_Property_States // ���� ��� Ÿ��
{
    Default = 0,
    plate_Armor,       // �Ǳ� ����
    gambeson_Armor,    // õ����
    mail_Armor         // ��罽 ����
}

// ���� ųŸ�Կ� ���� ���� Ž�� �Լ� �߻�Ŭ������ ���� �� ����Ͽ� ųŸ�Կ� �ش��ϴ� ���� Ž���Լ� ����

public enum eUnit_Action_States           // ���� �ൿ
{
    Default = 0,
    unit_Idle,          // ���
    unit_Move,          // �̵�
    unit_Tracking,      // ����
    unit_Attack,        // ����
    unit_Boundary       // Ȧ�� �� �ֺ� ���
}


public abstract class UnitInfo : MonoBehaviour, ISearchForNearEnemy
{
    public unit_Data m_unitData; // ���� ������ ����ü ����

    public eUnit_Action_States m_enum_Unit_Action_Type;               // ���� �ൿ ���� ����
    public ArmorCalculate m_this_Unit_Armor_Property;



    public abstract void InitUnitInfoSetting();     // ���� ���� �ʱ�ȭ �����ִ� �Լ�

    public virtual void Act_By_Unit()  // ���� �ൿ ���������ִ� �Լ�
    {
        switch (m_enum_Unit_Action_Type)  // ���� �ൿ ����
        {
            case eUnit_Action_States.unit_Idle: // ���� ��� ����

                break;

            case eUnit_Action_States.unit_Move: // ���� �̵�

                break;

            case eUnit_Action_States.unit_Tracking: // ������ ���� ����

                break;
            case eUnit_Action_States.unit_Attack:   // ������ ���� ����

                break;

            case eUnit_Action_States.unit_Boundary: // ���� Ȧ��(���ڸ� ���)

                break;

            default:
                print("case ���� ����");
                break;
        }
    }
    public void BeAttacked_By_OtherUnit(Collider other) // �⺻���� �� ���� ��ų ���� �� �� �� ������ ��...
    {
        print("�浹����");

        switch (m_unitData.m_eUnit_Defense_Property)
        {
            case eUnit_Defense_Property_States.Default:
                break;

            case eUnit_Defense_Property_States.plate_Armor:
                break;

            case eUnit_Defense_Property_States.gambeson_Armor:  // ���� ��� Ÿ���� õ ���� �� ��
                unit_Data otherUnitData = other.GetComponent<UnitInfo>().m_unitData;
                print(m_this_Unit_Armor_Property.DecreaseDamaged(m_unitData, otherUnitData));
                m_unitData.m_unit_Health -= m_this_Unit_Armor_Property.DecreaseDamaged(m_unitData, otherUnitData);
                print(gameObject.name + "�� ���� ü��" + m_unitData.m_unit_Health);
                break;

            case eUnit_Defense_Property_States.mail_Armor:
                break;

            default:
                break;
        }

    }

    // ����ü �ʵ� �̴ϼ� ����¡�� C# 9.0 ���� ������ ���� �ʱ� ������ Ŭ������ ���� ����

    public LayerMask m_layerMask = 0;   // ���������Ǿ� ���̾� ����ũ ����

    public Transform m_targetUnit = null;   // ������ Ÿ������ �� ���


    public void Search_For_Near_Enemy() // ���� ����� �� Ž���ϴ� �Լ�
    {
        Collider[] _cols = Physics.OverlapSphere(transform.position, m_unitData.m_unit_Attack_Range, m_layerMask); // ������ ���Ǿ� ����

        Transform _shortestTarget = null;  // ���� ����� ���� �ǹ��ϴ� ����

        if (_cols.Length < 0)  // Ž���� ���� ���ٸ� �Լ� Ż��
        {
            return;
        }

        float _shortestDistance = Mathf.Infinity;

        foreach (var _colTarget in _cols)
        {
            float _distance = Vector3.SqrMagnitude(transform.position - _colTarget.transform.position);
            if (_shortestDistance > _distance)
            {
                _shortestDistance = _distance;
                _shortestTarget = _colTarget.transform;
            }
        }

        m_targetUnit = _shortestTarget;
    }

    public void Look_At_The_Target()    // ������ Ÿ���� ���� ���� �� Ÿ�� ������ ���� ȸ���Ͽ� Ÿ���� �ٶ󺸴� �Լ�
    {
        Quaternion _lookRotation = Quaternion.LookRotation(m_targetUnit.position);  // Ÿ�� ������ �ٶ󺸴� ����

        Vector3 _euler = Quaternion.RotateTowards(transform.rotation, _lookRotation, 3f * Time.deltaTime).eulerAngles;

        transform.rotation = Quaternion.Euler(0, _euler.y, 0);

        Quaternion _fireRotation = Quaternion.Euler(0, _lookRotation.eulerAngles.y, 0); // ������ �߻��� �� �ִ� ������ ����


        if (Quaternion.Angle(transform.rotation, _fireRotation) < 5f)
        {
            // 1. ���� �ӵ� ��Ÿ�� ����

            // 2. ���ݼӵ� ��Ÿ���� 0���� �۾����ٸ� �߻� �� ���ݼӵ� ������ �ʱⰪ �ٽ� �־���

            Debug.Log("����!!!");
        }
    }
}

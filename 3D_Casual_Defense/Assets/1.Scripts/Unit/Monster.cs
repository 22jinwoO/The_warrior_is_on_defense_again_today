using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Monster : UnitInfo
{
    // Start is called before the first frame update
    void Awake()
    {
        m_this_Unit_Armor_Property = new GambesonArmor();

        InitUnitInfoSetting();

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Search_For_Near_Enemy", 1f);
        if (m_targetUnit != null)
        {
            //Look_At_The_Target();
            Debug.Log("�� Ž�� �Ϸ�!!");
        }
    }

    public override void InitUnitInfoSetting()
    {

        m_unitData.m_unit_Name = "����";            // ���� �̸�
        m_unitData.m_unit_Health = 200f;             // ���� ü��
        m_unitData.m_eUnit_Attack_Property = eUnit_Attack_Property_States.slash_Attack;    // ���� ���ݼӼ�
        m_unitData.unit_Attack_Damage = 1f;    // ���� ���� ������
        m_unitData.m_eUnit_Defense_Property = eUnit_Defense_Property_States.gambeson_Armor;   // ���� ���Ӽ�
        m_unitData.m_unit_Description = "�����Դϴ�";     // ���� ����
        m_unitData.m_unit_Type = "����";            // ���� Ÿ��
        m_unitData.m_unit_MoveSpeed = 1f;        // ���� �̵��ӵ�
        m_unitData.m_unit_Outlook = 1f;          // ���� �þ�
        m_unitData.m_unit_Attack_Range = 1f;     // ���� ���� ����
    }

    private void OnTriggerEnter(Collider other)
    {
        BeAttacked_By_OtherUnit(other);
    }


}

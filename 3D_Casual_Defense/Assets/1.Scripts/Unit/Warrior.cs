using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

//[RequireComponent(typeof(Animator))]
public class Warrior : UnitInfo
{
    private void Awake()
    {
        anim=GetComponent<Animator>();
        _this_Unit_Armor_Property = new GambesonArmor();
        nav = GetComponent<NavMeshAgent>();
        //InitUnitInfoSetting();

    }

    private void Update()
    {

        // �⺻ ������ �������� Ȯ��
        _can_Base_Attack = _unitData._unit_Attack_CoolTime >= _unitData._unit_Attack_Speed ? true : false;

        // ��ų ������ �������� Ȯ��
        _can_Skill_Attack =  _unitData._unit_Current_Skill_CoolTime >= _unitData._unit_Skill_CoolTime ? true : false;

        //���� ��ų ���� ��Ÿ���� ������ ��ų ���� ��Ÿ�� ���� ���ٸ� ��Ÿ�� �����ֱ�
        if (_unitData._unit_Skill_CoolTime>= _unitData._unit_Current_Skill_CoolTime)
        {
            _unitData._unit_Current_Skill_CoolTime += Time.deltaTime;
        }

        //���� �⺻ ���� ��Ÿ���� ������ �⺻ ���ݼӵ� ���� ���ٸ� ��Ÿ�� �����ֱ�
        if (_unitData._unit_Attack_Speed>=_unitData._unit_Attack_CoolTime)
        {
            _unitData._unit_Attack_CoolTime += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray,out RaycastHit hit))
            {
                movePos = hit.point;
                _enum_Unit_Action_Type = eUnit_Action_States.unit_Move;
            }
        }
        //Act_By_Unit();
    }


//    public override void InitUnitInfoSetting()
//    {

//        _unitData._unit_Name = "���";            // ���� �̸�
//        _unitData._unit_Health = 200f;             // ���� ü��
//        _unitData._eUnit_Attack_Property = eUnit_Attack_Property_States.slash_Attack;    // ���� ���ݼӼ�
//        _unitData._unit_Attack_Damage = 1f;    // ���� ���� ������
//        _unitData._unit_Skill_Attack_Damage = 6f;    // ���� ���� ������
//        _unitData._eUnit_Defense_Property = eUnit_Defense_Property_States.gambeson_Armor;   // ���� ���Ӽ�
//        _unitData._unit_Description = "����Դϴ�";     // ���� ����
//        _unitData._unit_Type = "���";            // ���� Ÿ��
//        _unitData._unit_MoveSpeed = 1f;        // ���� �̵��ӵ�
//        _unitData._unit_Outlook = 8f;          // ���� �þ�
//        _unitData._unit_Attack_Range = 4f;     // ���� ���� ����
//        _unitData._unit_Attack_Speed=3f;        // ���� ���� �ӵ�
//        _unitData._unit_Attack_CoolTime = 0f;     // ���� �⺻ ���� ��Ÿ��
//        _unitData._unit_Skill_CoolTime = 8f;     // ���� ��ų ���� ��Ÿ��
//}


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _unitData._unit_Outlook);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _unitData._unit_Attack_Range);
    }
    private void OnTriggerEnter(Collider other)
    {

        // Ÿ�� ���� �����ϱ� Ÿ�� �̸� ���ϴ°�
        // �갡 ���鼭 �浹�ν��� �� �� �ٵ� �浹�� �ֵ��� ����Ʈ�� �־���. �������� Ÿ������ list.where //


        //if (other.CompareTag("Orc"))
        //{
        //    if (other.name==_targetUnit.name)
        //    {
        //        //dd ���� ���� Ÿ�����ܤ���. 
        //        other.GetComponent<UnitInfo>().BeAttacked_By_OtherUnit(transform);
        //    }


        //}
    }
}


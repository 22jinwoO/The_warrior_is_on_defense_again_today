using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Stage1_TextManager : Singleton<Stage1_TextManager>
{
    public MonsterSpawnManager monsterSpawnManagerCs;

    [SerializeField]
    private UI_PopUpManager popUpManager;

    // 몬스터 생성 주기
    public TextMeshProUGUI currentWave_IntervalTxt;

    // 현재 웨이브 텍스트
    public TextMeshProUGUI currentWaveTxt;

    // 현재 웨이브 처치된 몬스터 수 텍스트
    public TextMeshProUGUI currentWaveDeadMonsterTxt;

    // 성 내구도 텍스트
    public TextMeshProUGUI castleHpTxt;

    // 팝업 타이틀 텍스트
    public TextMeshProUGUI popUpTitleTxt;

    // 팝업 메세지 텍스트
    public TextMeshProUGUI popUpMessageTxt;


    [SerializeField]
    float hpTimeValue;

    // Update is called once per frame
    //void Update()
    //{
    //    //currentWaveTxt.text = monsterSpawnManagerCs.currentWave.wave_Name;
    //    currentWave_IntervalTxt.text= "웨이브 대기 시간 : "+monsterSpawnManagerCs.currentWave.wave_StartTime.ToString();

    //}
    private void Awake()
    {
        hpTimeValue = 30f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerWinTxt();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PlayerLoseTxt();
        }
    }

    public void PlayerWinTxt()
    {
        popUpTitleTxt.text = "전투승리";
        popUpMessageTxt.text = "오크들로부터 성을 안전하게 지켰습니다!";
    }

    public void PlayerLoseTxt()
    {
        popUpTitleTxt.text = "전투패배";
        popUpMessageTxt.text = "오크들이 성을 장악했습니다!..";
    }


    public void CountDeadMonster()
    {
        currentWaveDeadMonsterTxt.text = ($"처치한 몬스터 수 {monsterSpawnManagerCs.currentWave.deathMonsterCnt} / {monsterSpawnManagerCs.currentWave.wave_maxMonsterCount}");
    }

    public void ShowCastleHpTxt()
    {
        popUpManager.castleHpBar.fillAmount = Castle.Instance._castle_Hp / Castle.Instance._castle_maxHp;

        // hp 바 연출 코드 -1씩 되서 적용이 안됨
        //popUpManager.castleHpBar.fillAmount = Mathf.Lerp(popUpManager.castleHpBar.fillAmount, Castle.Instance._castle_Hp/Castle.Instance._castle_maxHp, Time.deltaTime* hpTimeValue);

        if (Castle.Instance._castle_Hp <= 25f)
            popUpManager.castleHpBar.color = Color.red;
        else if(Castle.Instance._castle_Hp <= 50f)
            popUpManager.castleHpBar.color = new Color(1, 0.395f, 0);
        castleHpTxt.text = ($"{Castle.Instance._castle_Hp} / {Castle.Instance._castle_maxHp}");
    }
}

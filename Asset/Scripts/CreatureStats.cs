using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreatureStats : MonoBehaviour
{
    PhaseManager phaseManager;

    //�򥻼ƭ�
    [SerializeField] int maxHp = 50;
    int block;
    int currentHp;    
    int actionPoint = 1;
    public int ActionPoint {  get { return actionPoint; } }

    //�������
    int sliderHp;
    int HpDifference;
    [SerializeField] Slider HpSlider;
    [SerializeField] Image iconBlock;
    [SerializeField] Image blockFill;
    [SerializeField] Image cursor;
    [SerializeField] TextMeshProUGUI textHp;
    [SerializeField] TextMeshProUGUI textBlock;
    [SerializeField] TextMeshProUGUI skillEffect;
    //�����ֳt��
    [SerializeField] float HpChangeSpeed;
    float damageTimer;

    void Awake()
    {
        phaseManager = FindObjectOfType<PhaseManager>();
    }

    void Start()
    {
        currentHp = maxHp;
        sliderHp = currentHp;
        cursor.enabled = false;
        UpdateHpBar();
        UpdateBlock();
    }

    void Update()
    {
        UpdateHpBar();
    }

    public void TakeDamage(int skillResult)
    {
        Debug.Log("damage");
        if (skillResult <= block)
        {
            block -= skillResult;
        } 
        else
        {
            currentHp = currentHp - Mathf.Abs(block - skillResult);
            block = 0;
        }

        HpDifference = sliderHp - currentHp;
        UpdateBlock();
        SkillEffectText(skillResult, Color.red, "-");
        ShowCursor(false);
    }

    public void Heal(int skillResult)
    {
        Debug.Log("heal");
        currentHp += skillResult;
        HpDifference = currentHp - sliderHp;
        SkillEffectText(skillResult, Color.green, "+");
        UpdateBlock();
        ShowCursor(false);
    }

    public void Block(int skillResult)
    {
        Debug.Log("block");
        block += skillResult;
        SkillEffectText(skillResult, Color.gray, "+");
        UpdateBlock();
        ShowCursor(false);
    }

    void SkillEffectText(int skillResult, Color textColor, string status)
    {
        skillEffect.text = status + skillResult;
        skillEffect.color = textColor;
        Instantiate(skillEffect, transform.position, Quaternion.identity, gameObject.transform);
        Debug.Log(skillResult);
    }
    
    void UpdateHpBar()
    {
        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        if (HpSlider != null)
        {
            HpSlider.maxValue = maxHp;
            HpSlider.value = sliderHp;
        }

        damageTimer += Time.deltaTime;
        float timer = HpDifference * Time.deltaTime / HpChangeSpeed;

        if (currentHp < sliderHp && damageTimer >= timer)
        {
            sliderHp--;
            damageTimer = 0;
        }
        else if (currentHp > sliderHp && damageTimer >= timer)
        {
            sliderHp++;
            damageTimer = 0;
        }
        else
        {
            return;
        }

        textHp.text = sliderHp.ToString() + "/" + maxHp;
        Death();
    }

    void UpdateBlock()
    {
        if (block > 0)
        {
            blockFill.enabled = true;
            iconBlock.enabled = true;
            textBlock.enabled = true;
            textBlock.text = block.ToString();
        }
        else
        {
            blockFill.enabled = false;
            iconBlock.enabled = false;
            textBlock.enabled = false;
        }

        ShowCursor(false);
    }

    public void ShowCursor(bool show)
    {
        cursor.enabled = show;
    }

    public void Buff(int skillResult)
    {
        //�٤����D���
    }

    

    void Death()
    {
        if (currentHp <= 0)
        {
            Destroy(gameObject);
        }
    }
}

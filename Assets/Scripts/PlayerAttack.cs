using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LightComboState
{
    NONE,
    LIGHT_1,
    LIGHT_2
}

public class PlayerAttack : MonoBehaviour
{

    public bool isAttacking;
    public Attack punch;
    public LightComboState lightComboState;
    public Rigidbody m_Rigidbody;

    public float default_Combo_Timer = 2f;
    public float current_Combo_Timer;

    public bool isInCombo;
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    public void Start()
    {
        isInCombo = false;
        isAttacking = false;
        lightComboState = LightComboState.NONE;
        current_Combo_Timer = default_Combo_Timer;

    }

    private void Update()
    {

        ResetComboState();

        if (Input.GetKeyDown(KeyCode.O) && !isAttacking)
        {
            isAttacking = true;
            isInCombo = true;
            m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
            // Si on veut avoir un timer différent entre chaques combo, il faut bouger l'afféctation du current combo timer dans les if ci-dessous et affecter current combo timer avec des valeurs paramétrés au préalable
            current_Combo_Timer = default_Combo_Timer;
            lightComboState++;

            if ((int) lightComboState >= 3)
            {
                StartCoroutine(CurrentAttackComplete(0.7f));
                return;
            }

            if (lightComboState == LightComboState.LIGHT_1)
            {
                // Joue attaque 1 du combo de coup légé
                Debug.Log("Coup léger 1");
                
                StartCoroutine(CurrentAttackComplete(0.7f));

            }

            if (lightComboState == LightComboState.LIGHT_2)
            {
                // Joue attaque 2 du combo de coup légé
                Debug.Log("Coup léger 2");
                StartCoroutine(CurrentAttackComplete(0.7f));
            }

            if (lightComboState == LightComboState.NONE)
            {
                Debug.Log("bite");
            }
            Debug.Log(lightComboState);
        }

        if (Input.GetKeyDown(KeyCode.P) && !isAttacking)
        {
            isAttacking = true;
            m_Rigidbody.velocity = new Vector2(0f, m_Rigidbody.velocity.y); // déplacements horizontaux
            // Joue le coup lourd
            Debug.Log("Coup lourd");
            StartCoroutine(CurrentAttackComplete(5f));
        }
    }

    IEnumerator CurrentAttackComplete(float time)
    {
        yield return new WaitForSeconds(time);
        isAttacking = false;
    }

    void ResetComboState()
    {
        if (isInCombo)
        {
            current_Combo_Timer -= Time.deltaTime;

            if (current_Combo_Timer <= 0f)
            {
                lightComboState = LightComboState.NONE;

                isInCombo = false;
                current_Combo_Timer = default_Combo_Timer;
            }
         }
    }

}

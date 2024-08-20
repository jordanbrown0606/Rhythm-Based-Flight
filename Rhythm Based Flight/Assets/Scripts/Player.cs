using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private int _curHealth;
    [SerializeField] private int _maxHealth = 20;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Image _sliderFill;

    public void TakeDamage(int damage)
    {
        _curHealth -= damage;
        UpdateHealthBar();

        if (_curHealth <= 0)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(RestartGame());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _curHealth = _maxHealth;
    }

    private void UpdateHealthBar()
    {
        _healthBar.value = _curHealth;

        if (_healthBar.value <= 2 )
        {
            _sliderFill.color = Color.red;
        }
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

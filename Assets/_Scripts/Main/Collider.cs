using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Collider : MonoBehaviour
{
    [SerializeField] private GameObject _UIBox;
    [SerializeField] private GameObject _UIBep;
    bool _enabled = false;
    private void Update()
    {
        if (_enabled)
        {
            if (Input.GetKey(KeyCode.E))
            {
                _UIBep.SetActive(true);
                Time.timeScale = 0;
            }
            else  if (Input.GetKey(KeyCode.Escape))
            {
                _UIBep.SetActive(false);
                Time.timeScale = 1;
            }
        }
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            _UIBox.transform.position = new Vector2(transform.position.x + 1.8f, transform.position.y + 2.4f);
            _UIBox.SetActive(true);
            _enabled = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Box"))
        {
            _UIBox.SetActive(false);
            _enabled = false;
        }
    }

}

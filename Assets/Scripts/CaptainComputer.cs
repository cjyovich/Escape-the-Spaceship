using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* Class to handle the computer in Room Two - emails.
 */

public class CaptainComputer : MonoBehaviour
{
    public Text logonText;
    public Text input;

    public Button checkMail;

    public Image mailbox;
    public Image email1;
    public Image email2;
    public Image email3;

    void Start()
    {
        logonText.enabled = false;
        checkMail.gameObject.SetActive(false);
        mailbox.gameObject.SetActive(false);
        email1.gameObject.SetActive(false);
        email2.gameObject.SetActive(false);
        email3.gameObject.SetActive(false);
    }

    public void checkPassword(string newText)
    {
        string correctPassword = "andromeda";

        if (newText.CompareTo(correctPassword) == 0)
        {
            logonText.enabled = true;
            checkMail.gameObject.SetActive(true);
            input.enabled = false;
        }
    }

    public void openMail(Image email)
    {
        email.gameObject.SetActive(true);
    }

    public void closeMail(Image email)
    {
        email.gameObject.SetActive(false);
    }
}

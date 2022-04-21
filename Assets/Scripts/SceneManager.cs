using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneManager : MonoBehaviour
{

    [SerializeField] private GameObject m_registerUI            = null;
    [SerializeField] private GameObject m_loginUI               = null;
    [SerializeField] private TextMeshProUGUI m_text = null;
    [SerializeField] private TMP_InputField m_userNameInput = null;
    [SerializeField] private TMP_InputField m_emailInput = null;
    [SerializeField] private TMP_InputField m_password = null;
    [SerializeField] private TMP_InputField m_reEnterPassword = null;

    private NetWorkManager m_networkManager = null;

    private void Awake()
    {
        m_networkManager = GameObject.FindObjectOfType<NetWorkManager>();
    }

    public void SubmitRegister()
    {
        if(m_userNameInput.text == "" || m_emailInput.text == "" || m_password.text == "" || m_reEnterPassword.text == "")
        {
            m_text.text = "Por favor llena los campos faltantes";
            return;
        }

        m_networkManager = GameObject.FindObjectOfType<NetWorkManager>();

        if (m_password.text == m_reEnterPassword.text)
        {

            m_networkManager.CreateUser(m_userNameInput.text, m_emailInput.text, m_password.text, delegate (NetWorkManager.Response response)
            {
                m_text.text = response.message;
            });
        }
        else
        {
            m_text.text = "Contraseñas no son iguales, por favor, verificar";
        }
    }


    public void ShowLogin()
    {
        m_registerUI.SetActive(false);
        m_loginUI.SetActive(true);
    }

    public void ShowRegister()
    {
        m_registerUI.SetActive(true);
        m_loginUI.SetActive(false);
    }

}

using System;
using System.Collections.Generic;
using UnityEngine;

public class NetWorkManager : MonoBehaviour
{

    public void CreateUser(string userName , string email , string pass ,  Action<Response> response)
        {
            StartCoroutine(Co_CreateUser(userName, email, pass, response));
        }

    private void StartCoroutine(IEnumerable<IEnumerator> enumerable)
    {
        throw new NotImplementedException();
    }

    private void StartCoroutine(IEnumerator enumerator)
    {
        throw new NotImplementedException();
    }

    private IEnumerable<IEnumerator> Co_CreateUser(string userName , string email , string pass , Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName" , userName);
        form.AddField("email", email);
        form.AddField("pass", pass);

        WWW w = new WWW("http://localhost/Game/createUser.php" , form);

        yield return (IEnumerator)w;


        response(JsonUtility.FromJson<Response>(w.text) );

    }
    [Serializable]
    public class Response
    {
        public bool done              = false;
        public string       message = "";
    }

}

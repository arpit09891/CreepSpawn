using UnityEngine;
using Boomlagoon.JSON;
using System.Collections;
using UnityEngine.Networking;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestAPIInterface : MonoBehaviour {
	private const string BaseURL = "http://polished-silence-8960.getsandbox.com/";

    public Text userName;
    public Text password;
    public GameObject wrongUsername;

    User newUser;
	public List<User> listOfUsers = new List<User> ();

	[System.Serializable]
	public class User{
		public string username;
		public string password;
	}
		
	/**********************************************************GET************************************************/
	private void GetData(){
		WWW www = new WWW (BaseURL + "users");
		StartCoroutine (FetchDataFromSandbox (www));
	}

	IEnumerator FetchDataFromSandbox(WWW www){
		yield return www;
		if (www.error == "") {
			string data = www.text;
			JSONArray jsonArray = JSONArray.Parse (data);
			if (jsonArray == null) {
				Debug.LogError ("Empty Json");
			} else {
				Debug.Log ("length is" + jsonArray.Length);
				Debug.Log (jsonArray);

				for (int i = 0; i < jsonArray.Length; i++) {
					newUser = new User ();
					if(jsonArray[i].Obj["username"] != null) 
						newUser.username = jsonArray[i].Obj["username"].Str;
					if(jsonArray[i].Obj["password"] != null) 
						newUser.password = jsonArray[i].Obj["password"].Str;		
					listOfUsers.Add (newUser);
				}
			}
		} else {
			Debug.LogError (www.error);
		}
	}

	/**********************************************************END GET************************************************/
		
	/**********************************************************POST************************************************/
	private void PostData(string urlAddress, string newData){
		StartCoroutine( PostRequest(urlAddress,newData));
	}

	IEnumerator PostRequest(string url, string bodyJsonString) {
		var request = new UnityWebRequest(url, "POST");
		byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
		request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
		request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");

		yield return request.Send();
		Debug.Log("Response: " + request.downloadHandler.text);
        SceneManager.LoadScene(0);
    }
	/*********************************************************END POST********************************************/

	/*********************************************************DELETE********************************************/

	private void DeleteData(string urlAddress, string newData){
		StartCoroutine( DeleteRequest(urlAddress,newData));
	}

	IEnumerator DeleteRequest(string url, string bodyJsonString) {
		var request = new UnityWebRequest(url, "DELETE");
		byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(bodyJsonString);
		request.uploadHandler = (UploadHandler) new UploadHandlerRaw(bodyRaw);
		request.downloadHandler = (DownloadHandler) new DownloadHandlerBuffer();
		request.SetRequestHeader("Content-Type", "application/json");

		yield return request.Send();
		Debug.Log("Response: " + request.downloadHandler.text);
	}

	void Start(){
		//GET	
		GetData ();
	}

    public void loginButton()
    {
        foreach(User user in listOfUsers)
        {
            if(user.username == userName.text)
            {
                if(user.password == password.text)
                {
                    SceneManager.LoadScene(2);
                }
                else
                {
                    wrongUsername.SetActive(true);
                }

            }
            else
            {
                wrongUsername.SetActive(true);
            }
        }
    }

    public void SubmitButton()
    {
        string newData = "{\"username\":\""+userName.text+"\",\"password\":\""+password.text+"\"}";
        PostData(BaseURL + "users", newData);
    }

    public void SignUp()
    {
        SceneManager.LoadScene(1);
    }

    public void DeleteButton()
    {
        string deleteUser = userName.text;
        if (userName.text != "")
        {
            string deleteData ="null";
            DeleteData(BaseURL + "users/" + "/" + deleteUser, deleteData);
            foreach (User user in listOfUsers)
            {
                if (user.username == userName.text && user.password == password.text)
                {
                    listOfUsers.Remove(user);
                }
            }
        }
    }
}


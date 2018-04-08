using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Net;
using System.Net.Sockets;
using UnityEngine.SceneManagement;

public class MainAPI : MonoBehaviour {

    private string locationName;
    private Location location;
    private Items items;
    public int COUNT;

    [System.Serializable]
    public class Location
    {
        public int id;
        public string name;
        public int waves;
    }

    [System.Serializable]
    public class UserItems
    {
        public string email;
        public string itemName;

        public void setEmail(string email)
        {
            this.email = email;
        }

        public void setItemName(string itemName)
        {
            this.itemName = itemName;
        }
    }
    [System.Serializable]
    public class Item
    {
        public int id;
        public string name;

        public void setId(int id)
        {
            this.id = id;
        }

        public void setName(string name)
        {
            this.name = name;
        }
    }
    [System.Serializable]
    public class Items
    {
        public Item[] items;

        [System.Serializable]
        public class Item
        {
            public int id;
            public string name;

            public void setId(int id)
            {
                this.id = id;
            }

            public void setName(string name)
            {
                this.name = name;
            }
        }

        public Item[] getItems()
        {
            return items;
        }

    }
    [System.Serializable]
    public class UserEmail
    {
        public string email;

        public void setEmail(string email)
        {
            this.email = email;
        }
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //COUNT = location.waves;
	}

    public int getLocationWaves(int locationIndex)
    {
        StartCoroutine(UploadLocationInfo(locationIndex));
        return location.waves;
    }

    public void setUserItem(string email,string itemName)
    {
        StartCoroutine(UploadCatchingItem(email,itemName));
    }

    public void getUserItems(string email)
    {
        StartCoroutine(UploadUserItem(email));
        
    }
    IEnumerator UploadLocationInfo(int locationIndex)
    {
        switch (locationIndex)
        {
            case 0:
                locationName = "Japan";
                break;
            case 1:
                locationName = "Russia";
                break;
            default:

                break;
        }
        UnityWebRequest www = UnityWebRequest.Get("http://localhost:8080/api/locations/"+locationName);
        yield return www.SendWebRequest();


        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        if (www.downloadHandler.text != "Bad Registration")
        {

            location = (Location)JsonUtility.FromJson<Location>(www.downloadHandler.text);
            Debug.Log("UUUUUU");
            Debug.Log(location.name);
            Debug.Log("UUUUU");
            Debug.Log(www.downloadHandler.text);
        }
    }

    IEnumerator UploadCatchingItem(string email, string itemName)
    {
       /* WWWForm form = new WWWForm();

        UnityWebRequest www = UnityWebRequest.Post("http://localhost:8080/api/locations/",form);
        yield return www.SendWebRequest();*/

        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        UserItems userItems = new UserItems();
        userItems.setEmail(email);
        userItems.setItemName(itemName);
        // convert json string to byte
        string json = JsonUtility.ToJson(userItems);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);

        www = new WWW("http://localhost:8080/api/setItem", formData, postHeader);

        yield return www;

    }

    IEnumerator UploadUserItem(string email)
    {
      
        WWW www;
        Hashtable postHeader = new Hashtable();
        postHeader.Add("Content-Type", "application/json");

        UserEmail ue = new UserEmail();
        ue.setEmail(email);
        // convert json string to byte
        string json = JsonUtility.ToJson(ue);
        var formData = System.Text.Encoding.UTF8.GetBytes(json);

        www = new WWW("http://localhost:8080/api/getItems", formData, postHeader);

        yield return www;

        //location = (Location)JsonUtility.FromJson<Location>(www.downloadHandler.text);
        items = (Items)JsonUtility.FromJson<Items>(www.text);

        //Debug.Log(items[0].name);
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBehaviour : MonoBehaviour
{
    public List<GameObject> itemList;
    public List<GameObject> slots;
    public List<GameObject> emptyList;

    private Camera menuCamera;
    private vnc.Samples.SamplePlayer playerController1;
    private vnc.RetroController playerController2;
    private Material menuFade;
    private Color menuAlpha;
    private GameObject itemDisk;
    private GameObject playerCrosshair;
    private Text itemLabel;

    private bool isOpened;
    private Quaternion _targetRot;
    private int itemDiskAngle;

    private int slotSelected;

    // private GameObject item1;
    // private GameObject item2;
    // private GameObject item3;
    // private GameObject item4;
    // private GameObject item5;
    // private GameObject item6;
    // private GameObject item7;
    // private GameObject item8;

    private GameObject empty1;

    [HideInInspector]
    public List<string> items;

    private AudioSource emptySound;
    private AudioSource choseSound;

    // Start is called before the first frame update
    void Start()
    {
        items = new List<string>();

        itemLabel = GameObject.Find("ItemLabelContainer").GetComponent<Text>();
        itemLabel.text = "";

        // item1 = GameObject.Find("Item1");
        // item2 = GameObject.Find("Item2");
        // item3 = GameObject.Find("Item3");
        // item4 = GameObject.Find("Item4");
        // item5 = GameObject.Find("Item5");
        // item6 = GameObject.Find("Item6");
        // item7 = GameObject.Find("Item7");
        // item8 = GameObject.Find("Item8");

        slotSelected = 1;
        itemDiskAngle = -90;

        isOpened = false;

        playerController1 = GameObject.Find("Player_Test").GetComponent<vnc.Samples.SamplePlayer>();
        playerController2 = GameObject.Find("Player_Test").GetComponent<vnc.RetroController>();

        playerCrosshair = GameObject.Find("Crosshair");

        emptySound = GameObject.Find("SelectEmptySound").GetComponent<AudioSource>();
        choseSound = GameObject.Find("ChoseItemSound").GetComponent<AudioSource>();

        menuCamera = gameObject.GetComponent<Camera>();
        menuCamera.enabled = false;

        menuFade = GameObject.Find("MenuFade").GetComponent<MeshRenderer>().material;
        menuAlpha = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        menuFade.SetColor("_Color", menuAlpha);

        itemDisk = GameObject.Find("ItemDisk");
        _targetRot = Quaternion.Euler(0, -90, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            isOpened = !isOpened;
            playerController1.enabled = !playerController1.enabled;
            playerController2.enabled = !playerController2.enabled;
            menuCamera.enabled = !menuCamera.enabled;

            if(isOpened){
                //menuFade.SetFloat("_Metallic", .55f);
                menuAlpha = new Color(0.0f, 0.0f, 0.0f, .5f);
                menuFade.SetColor("_Color", menuAlpha);
                playerCrosshair.SetActive(false);
                itemLabel.text = "";
            } else {
                //menuFade.SetFloat("_Metallic", 0f);
                menuAlpha = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                menuFade.SetColor("_Color", menuAlpha);
                playerCrosshair.SetActive(true);
                itemLabel.text = "";
            }
        }

        if (isOpened) {
            if (Input.GetKeyDown(KeyCode.A)) {
                //_targetRot = Quaternion.AngleAxis(itemDiskAngle - 45, itemDisk.transform.up);
                _targetRot = Quaternion.Euler(0, itemDiskAngle - 45, 0);
                itemDiskAngle -= 45;

                if(slotSelected == 8){
                    slotSelected = 1;
                } else {
                    slotSelected = slotSelected + 1;
                }
                choseSound.Play();
                Debug.Log(slotSelected);
            } else if (Input.GetKeyDown(KeyCode.D)) {
                //_targetRot = Quaternion.AngleAxis(itemDiskAngle + 45, itemDisk.transform.up);
                _targetRot = Quaternion.Euler(0, itemDiskAngle + 45, 0);
                itemDiskAngle += 45;

                if(slotSelected == 1){
                    slotSelected = 8;
                } else {
                    slotSelected = slotSelected - 1;
                }
                choseSound.Play();
                Debug.Log(slotSelected);
            }

            // INPUT TO SELECT ITEM
            if (Input.GetKeyDown(KeyCode.E)) {
                if(itemLabel.text == "Empty"){
                    emptySound.Play();
                }
            }
        }

        if(slotSelected == 1){
            slots[0].transform.Rotate(Vector3.up * (100f * Time.deltaTime));
            itemLabel.text = isOpened ? (items.Count > 0 ? items[slotSelected - 1] : "Empty") : "";
        } else if (slotSelected == 2){
            slots[1].transform.Rotate(Vector3.up * (100f * Time.deltaTime));
            itemLabel.text = isOpened ? (items.Count > 1 ? items[slotSelected - 1] : "Empty") : "";
        } else if (slotSelected == 3){
            slots[2].transform.Rotate(Vector3.up * (100f * Time.deltaTime));
            itemLabel.text = isOpened ? (items.Count > 2 ? items[slotSelected - 1] : "Empty") : "";
        } else if (slotSelected == 4){
            slots[3].transform.Rotate(Vector3.up * (100f * Time.deltaTime));
            itemLabel.text = isOpened ? (items.Count > 3 ? items[slotSelected - 1] : "Empty") : "";
        } else if (slotSelected == 5){
            slots[4].transform.Rotate(Vector3.up * (100f * Time.deltaTime));
            itemLabel.text = isOpened ? (items.Count > 4 ? items[slotSelected - 1] : "Empty") : "";
        } else if (slotSelected == 6){
            slots[5].transform.Rotate(Vector3.up * (100f * Time.deltaTime));
            itemLabel.text = isOpened ? (items.Count > 5 ? items[slotSelected - 1] : "Empty") : "";
        } else if (slotSelected == 7){
            slots[6].transform.Rotate(Vector3.up * (100f * Time.deltaTime));
            itemLabel.text = isOpened ? (items.Count > 6 ? items[slotSelected - 1] : "Empty") : "";
        } else if (slotSelected == 8){
            slots[7].transform.Rotate(Vector3.up * (100f * Time.deltaTime));
            itemLabel.text = isOpened ? (items.Count > 7 ? items[slotSelected - 1] : "Empty") : "";
        }

        itemDisk.transform.localRotation = Quaternion.Lerp(itemDisk.transform.localRotation, _targetRot, 5f * Time.deltaTime);
    }

    // THIS IS CALLED ON ACTIONCONTROLLERBR SCRIPT
    public void GetItem(string itemName) {
        Debug.Log("Get item: " + itemName);
        if(items.Count < 8) {
            items.Add(itemName);
            Debug.Log(items.Count);
            // ESSA PARTE PRECISA DE AUTOMAÇÃO
            // PRECISA TROCAR O ITEM1 E EMPTY1 PARA VARIÁVEIS
            for (int i = 0; i < itemList.Count; i++){
                if(itemName == itemList[i].name){
                    GameObject item = Instantiate(itemList[i], new Vector3(slots[items.Count - 1].transform.position.x,slots[items.Count - 1].transform.position.y,slots[items.Count - 1].transform.position.z), transform.rotation) as GameObject;
                    item.transform.parent = slots[items.Count - 1].transform;
                    emptyList[items.Count - 1].SetActive(false);
                }
            }
        } else {
            Debug.Log("Não pode carregar mais items!");
        }
    }
}

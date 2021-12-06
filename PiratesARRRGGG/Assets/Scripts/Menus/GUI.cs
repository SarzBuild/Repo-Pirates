using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    private static GUI _instance;

    public static GUI Instance
    {
        get
        {
            if (_instance != null) return _instance;

            var singleton = FindObjectOfType<GUI>();
            if (singleton != null) return _instance;

            var go = new GameObject();
            _instance = go.AddComponent<GUI>();
            return _instance;
        }
    }

    [Header("Battle System Reference")] [SerializeField]
    public BattleSystem BattleSystem;

    
    [SerializeField] public Transform PlayerTransfrom;
    [SerializeField] public Transform EnemyTransfrom;

    [SerializeField] public GameObject Plate;
    [SerializeField] public GameObject FloatingText;
    [SerializeField] public Vector3 Offset;

    [SerializeField] public Transform MessageArea;

    [SerializeField] public Transform Ability1;
    [SerializeField] public Transform Ability2;
    [SerializeField] public Transform Ability3;
    [SerializeField] public Transform Ability4;

    [SerializeField] public GameObject Menu;
    [SerializeField] public GameObject MenuTextArea;

    [SerializeField] [HideInInspector] private TMP_Text _ability1Text;
    [SerializeField] [HideInInspector] private TMP_Text _ability2Text;
    [SerializeField] [HideInInspector] private TMP_Text _ability3Text;
    [SerializeField] [HideInInspector] private TMP_Text _ability4Text;

    [SerializeField] [HideInInspector] private TMP_Text _messagetAreaText;

    [SerializeField] [HideInInspector] private TMP_Text _playerName;
    [SerializeField] [HideInInspector] private TMP_Text _enemyName;
    [SerializeField] [HideInInspector] private Image _playerHealthFill;
    [SerializeField] [HideInInspector] private Image _enemyHealthFill;

    [SerializeField] [HideInInspector] private float _tempCurrentHealthPlayer;
    [SerializeField] [HideInInspector] private float _tempCurrentHealthEnemy;

    [SerializeField] [HideInInspector] private bool _menuOpened;
    [SerializeField] [HideInInspector] private bool _lock;


    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);
        else _instance = this;
    }

    private void OnEnable()
    {
        _ability1Text = Ability1.GetComponentInChildren<TMP_Text>();
        _ability2Text = Ability2.GetComponentInChildren<TMP_Text>();
        _ability3Text = Ability3.GetComponentInChildren<TMP_Text>();
        _ability4Text = Ability4.GetComponentInChildren<TMP_Text>();
        _messagetAreaText = MessageArea.GetComponentInChildren<TMP_Text>();

        SpawnPlates(PlayerTransfrom.position, _playerName, _playerHealthFill);
        SpawnPlates(EnemyTransfrom.position, _enemyName, _enemyHealthFill);
    }

    private void Start()
    {
        SetPlateNames(_playerName, BattleSystem.Player);
        SetPlateNames(_enemyName, BattleSystem.Enemy);
        _tempCurrentHealthEnemy = BattleSystem.Enemy.Stats.MaxHealth;
        _tempCurrentHealthPlayer = BattleSystem.Player.Stats.MaxHealth;
        _lock = false;
        Menu.SetActive(false);
    }

    private void Update()
    {
        CheckAbilitiesIndexPosition();
        UpdateHealth(_tempCurrentHealthPlayer, BattleSystem.Player, _playerHealthFill);
        UpdateHealth(_tempCurrentHealthEnemy, BattleSystem.Enemy, _enemyHealthFill);
        if(Input.GetKeyDown(KeyCode.Escape)) OpenMenu();
        
    }

    private void CheckAbilitiesIndexPosition()
    {
        CheckAbility(Ability1, 0, _ability1Text);
        CheckAbility(Ability2, 1, _ability2Text);
        CheckAbility(Ability3, 2, _ability3Text);
        CheckAbility(Ability4, 3, _ability4Text);
    }

    private void CheckAbility(Transform ability, int index, TMP_Text text)
    {
        if (BattleSystem.Player.Stats.Abilities[index] != null)
        {
            if (!ability.gameObject.activeSelf) ability.gameObject.SetActive(true);
            text.text = BattleSystem.Player.Stats.Abilities[index].AbilityName;
        }
        else if (BattleSystem.Player.Stats.Abilities[index] == null) ability.gameObject.SetActive(false);
    }

    private void SpawnPlates(Vector3 position, TMP_Text name, Image fill)
    {
        var tempObject = Instantiate(Plate, position + Offset, Quaternion.identity, transform);
        if (name == _playerName && fill == _playerHealthFill)
        {
            _playerName = tempObject.GetComponentInChildren<TMP_Text>();
            _playerHealthFill = tempObject.transform.GetChild(2).GetChild(1).GetComponent<Image>();
            return;
        }

        _enemyName = tempObject.GetComponentInChildren<TMP_Text>();
        _enemyHealthFill = tempObject.transform.GetChild(2).GetChild(1).GetComponent<Image>();
    }

    private void SetPlateNames(TMP_Text name, CombatantController combatantName) =>
        name.text = combatantName.Stats.EntityName;

    private void UpdateHealth(float tempVar, CombatantController entity, Image fill)
    {
        if (Math.Abs(tempVar - entity.Stats.CurrentHealth) < 1) return;
        fill.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(0, entity.Stats.MaxHealth, entity.Stats.CurrentHealth));
        
        _tempCurrentHealthPlayer = entity.Stats.CurrentHealth;
        _tempCurrentHealthEnemy = entity.Stats.CurrentHealth;
    }

    public void SetText(string text) => _messagetAreaText.text = text;

    public void SpawnFloatingDamage(Transform position, string text, Color32 color)
    {
        var tempObject = Instantiate(FloatingText, position.position, Quaternion.identity, transform)
            .GetComponentInChildren<TMP_Text>();
        tempObject.text = text;
        tempObject.color = color;
    }

    public void SetEndMessage(string text, Color32 color)
    {
        OpenMenu();
        _lock = true;
        var tempObject = MenuTextArea.GetComponent<TMP_Text>();
        tempObject.text = text;
        tempObject.color = color;
    }

    private void OpenMenu()
    {
        if(_lock) return;
        
        if (_menuOpened)
        {
            Menu.SetActive(false);
            _menuOpened = false;
            return;
        }
        Menu.SetActive(true);
        _menuOpened = true;
    }


}

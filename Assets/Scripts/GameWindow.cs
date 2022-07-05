using TMPro;
using UnityEngine;

public class GameWindow : Window
{
    private const int MaxCountBlocks = 40;
    private const int BlockPrice = 15;

    [SerializeField]
    private TextMeshProUGUI _maxCountBlocks = null;
    [SerializeField]
    private TextMeshProUGUI _currentCountBlocks = null;
    [SerializeField]
    private TextMeshProUGUI _money = null;

    public static int _countBlocks { get; private set; }

    private void OnEnable()
    {
      PlayerController.Sold += PlayerController_Sold;
      Harvest.TookTheGrass += Harvest_TookTheGrass;
    }

    private void Start()
    {
        _maxCountBlocks.text = MaxCountBlocks.ToString();
    }

    private void OnDisable()
   {
        PlayerController.Sold -= PlayerController_Sold;
        Harvest.TookTheGrass -= Harvest_TookTheGrass;
   }
   
   private void PlayerController_Sold()
   {
        _money.text = $" $ {_countBlocks * BlockPrice}";
        _countBlocks = 0;
        _currentCountBlocks.text = _countBlocks.ToString();
   }
   
   private void Harvest_TookTheGrass()
   {
        _countBlocks++;
        _currentCountBlocks.text = _countBlocks.ToString();
   }
}

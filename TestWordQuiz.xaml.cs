using System.ComponentModel;
using System.Diagnostics;

namespace RizkyApps;

public partial class TestWordQuiz : ContentPage, INotifyPropertyChanged
{
    public string NotifMsg
    {
        get => sNotifMsg;
        set
        {
            sNotifMsg = value;
            OnPropertyChanged();
        }
    }
    public string Spotlight
	{
		get => sSpotlight;
		set
		{
            sSpotlight = value;
			OnPropertyChanged();
        }
	}
    public List<char> Letters
    {
        get => lLetters;
        set
        {
            lLetters = value;
            OnPropertyChanged();
        }
    }

    const int maxMistake = 10;

    int iMistake;
    List<string> listWord;
	string sAnswer;
	string sNotifMsg;
	List<char> lGuessed;
	List<char> lLetters;
	private string sSpotlight;

	public TestWordQuiz()
	{
		InitializeComponent();
		FirstLoad();
    }

	private void FirstLoad()
	{
        iMistake = 0;
        sNotifMsg = string.Empty;
        lGuessed = new List<char>();
        lLetters = new List<char>();
		Letters.AddRange("abcdefghijklmnopqrstuvwxyz");
        SetWord();
        GetWord();
		CheckWord();
		BindingContext = this;
        lblErrorTotal.Text = $"Error {iMistake} of {maxMistake}";
    }

	private void SetWord()
	{
		listWord = new List<string>()
		{
			"Baju", "Lemari", "Kulkas", "Buku", "Meja", "Sarung", "Tikar", "Botol", "Bulu"
		};
    }

	private void GetWord()
    {
        sAnswer = listWord[new Random().Next(0, listWord.Count - 1)].ToUpper();
		Debug.WriteLine(sAnswer);
    }

	private void CheckWord()
	{
		var temp = sAnswer.Select(x => (lGuessed.IndexOf(x) >= 0 ? x : '_')).ToArray();
		Spotlight = string.Join(" ", temp);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		var btn = sender as Button;
		if (btn != null)
		{
			var letter = btn.Text.ToUpper();
			btn.IsEnabled = false;
			CheckLetter(letter[0]);
        }
    }

	private void CheckLetter(char dat)
	{
		if (lGuessed.IndexOf(dat) == -1)
		{
            lGuessed.Add(dat);
        }
        if (sAnswer.IndexOf(dat) >= 0)
        {
            CheckWord();
            CheckIfWinLose();
        }
        else if (sAnswer.IndexOf(dat) == -1)
        {
            iMistake++;
            CheckIfWinLose();
        }
    }
	private void CheckIfWinLose()
	{
        if (Spotlight.Replace(" ", "") == sAnswer)
        {
            NotifMsg = "You Win";
            lblNotifMsg.TextColor = Color.FromRgb(50, 120, 50);
            btnReset.IsVisible = true;
            lblNotifMsg.IsVisible = true;
        }

        if (iMistake >= maxMistake)
        {
            NotifMsg = "You Lose";
            lblNotifMsg.TextColor = Color.FromRgb(120, 50, 50);
            SetAllLettersButton(false);
            btnReset.IsVisible = true;
            lblNotifMsg.IsVisible = true;
        }

        lblErrorTotal.Text = $"Error {iMistake} of {maxMistake}";
    }

    private void SetAllLettersButton(bool IsEnable)
    {
        foreach (var dat in LettersContainer.Children)
        {
            var btn = dat as Button;
            if (btn != null)
            {
                btn.IsEnabled = IsEnable;
            }
        }
    }

    private void btnReset_Clicked(object sender, EventArgs e)
    {
        FirstLoad();
        SetAllLettersButton(true);
        btnReset.IsVisible = false;
        lblNotifMsg.IsVisible = false;
    }
}
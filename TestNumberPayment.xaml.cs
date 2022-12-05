namespace RizkyApps;

public partial class TestNumberPayment : ContentPage
{
	private double dAmount;
	private int iTip;
	private int iSplit;

	public TestNumberPayment()
	{
		InitializeComponent();
        SetLoadData();
    }

    private void SetLoadData()
    {
        dAmount = 0;
        iTip = 0;
        iSplit = 1;
    }

    private void txtAmount_Completed(object sender, EventArgs e)
    {
        CalculateAmount();
    }

    private void sldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        iTip = (int) sldTip.Value;
        lblSldTip.Text = iTip <= 0 ? "Choose Tip : " : "Choose Tip : " + iTip.ToString() + "%";
        CalculateAmount();
    }

    private void CalculateAmount()
    {
        dAmount = string.IsNullOrWhiteSpace(txtAmount.Text) ? 0 : Convert.ToDouble(txtAmount.Text);

        var dtotalTip = (double) (dAmount * iTip) / 100;
        var dTipPerSplit = (double) dtotalTip / iSplit;
        var dTotalPerSplit = (double)(dAmount + dtotalTip) / iSplit;
        var dSubtotal = (double) dAmount / iSplit;

        lblTotal.Text = "Rp " + Math.Round(dTotalPerSplit).ToString();
        lblTotal.FontSize = lblTotal.Text.Length > 8 ? 10 : 25;

        lblTip.Text = "Rp " + Math.Round(dTipPerSplit).ToString();
        lblSubtotal.Text = "Rp " + Math.Round(dSubtotal).ToString();
    }

    private void btnTip10_Clicked(object sender, EventArgs e)
    {
        sldTip.Value = 10;
    }

    private void btnTip15_Clicked(object sender, EventArgs e)
    {
        sldTip.Value = 15;
    }

    private void btnTip20_Clicked(object sender, EventArgs e)
    {
        sldTip.Value = 20;
    }

    private void btnMinus_Clicked(object sender, EventArgs e)
    {
        EditSplit(-1);
    }

    private void btnPlus_Clicked(object sender, EventArgs e)
    {
        EditSplit(1);
    }

    private void EditSplit(int iValue)
    {
        iSplit = (iSplit + iValue) <= 0 ? 1 : iSplit + iValue;
        lblTotalSplit.Text = iSplit.ToString();
        CalculateAmount();
    }
}
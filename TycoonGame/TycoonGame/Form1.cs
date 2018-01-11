using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TycoonGame
{
    public partial class Form1 : Form
    {
        private int Fame = 0;
        private decimal Money = 20;
        private decimal AutoIncome = 0;
        private decimal CompanyShares = 100;
        //PRICE CHANGE REQUIREMENTS
        private int FoodBuisnessStatusInt = 15;
        private int RealEstateStatusInt = 40;
        private int FashionBuisnessStatusInt = 85;

        private int ElectronicBuisnessStatusInt = 90;
        private int VehicleBuisnessStatusInt = 100;
        private int OilSectorStatusInt = 120;

        //SETTING THE PRICES
        private int FoodPrices = 20;
        private int RealEstatePrices = 50;
        private int FashionPrices = 100;

        private int ElectronicsPrices = 200;
        private int VehiclePrices = 400;
        private int OilPrices = 1000;

        Random rnd = new Random();

        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//

        //
        //INITIALIZATION
        //
        public Form1()
        {
            InitializeComponent();
            string AutoIncomeText = AutoIncome.ToString();
            string DisplayMoney = Money.ToString();
            string CompanySharesDisplay = CompanyShares.ToString();
            CurrentMoneyNumber.Text = DisplayMoney + "$";
            AutoIncomeNumber.Text = AutoIncomeText + "$";
            CompanySharesPrecentage.Text = CompanySharesDisplay + "%";

            //FIRST DESCRIPTION
            Info1.MouseHover -= MouseHoverEvent;
            Info1.MouseHover += MouseHoverEvent;

            Info1.MouseLeave -= MouseHoverEvent1;
            Info1.MouseLeave += MouseHoverEvent1;

            //SECOND DESCRIPTION
            Info2.MouseHover -= MouseHoverEvent2;
            Info2.MouseHover += MouseHoverEvent2;

            Info2.MouseLeave -= MouseHoverEvent3;
            Info2.MouseLeave += MouseHoverEvent3;

            //THIRD DESCRIPTION
            Info3.MouseHover -= MouseHoverEvent4;
            Info3.MouseHover += MouseHoverEvent4;

            Info3.MouseLeave -= MouseHoverEvent5;
            Info3.MouseLeave += MouseHoverEvent5;
        }

        //FIRST DESCRIPTION
        void MouseHoverEvent(object sender, EventArgs e)
        {
            MarketStatusDesc.Text = "The Market Status determines how much the select \n buisness costs. It gets higher and lower as the game \n progresses, but it should never go a lot over 100.\n As your fame increases, the Status starts to \n change more radically.";
        }
        void MouseHoverEvent1(object sender, EventArgs e)
        {
            MarketStatusDesc.Text = "";
        }

        //SECOND DESCRIPTION
        void MouseHoverEvent2(object sender, EventArgs e)
        {
            SharesQ.Text = "You can Invest in other companies, taking 25% of your \n total money in a risky endevaour, that might not pay off. \n You can also buy and sell shares.If your shares are at 100 %, \n then you get 100 % of your auto-income, as the stock shares \n get lower, you start getting the same precentage of Income \n as you have current stock.";
        }
        void MouseHoverEvent3(object sender, EventArgs e)
        {
            SharesQ.Text = "";
        }

        //THIRD DECRIPTION
        void MouseHoverEvent4(object sender, EventArgs e)
        {
            BuyingQ.Text = "You can buy 6 types of buisnesses, \n most are locked behind a Fame \n requirement, which goes up to 10. \n Get fame by buying Ads or Sponsorship.";
        }
        void MouseHoverEvent5(object sender, EventArgs e)
        {
            BuyingQ.Text = "";
        }
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //
        //COMPANY NAME CHANGER MECHANIC
        //
        private void CompanyNameConfirmationButton_Click_1(object sender, EventArgs e)
        {
            //COMPANY NAME CHANGER
            PlayerChosenName.Text = EnterCompanyName.Text;
            Controls.Remove(EnterCompanyName);
            CompanyNameConfirmationButton.Visible = false;
            EnterCompanyName.Visible = false;
        }

        //
        //TIMER, NATURAL MONEY TICK
        //
        private void timer1_Tick(object sender, EventArgs e)
        {
            Money =/* 10 * */(Money + (AutoIncome / ( 100 /CompanyShares )))/* / 10*/;
            Money = Math.Round(Money);
            string DisplayMoney = Money.ToString();
            CurrentMoneyNumber.Text = DisplayMoney + "$";
            if(Fame > 20)
            {
                int RemoveFame = Fame - 20;
                Fame = Fame - RemoveFame;
            }
            if(Fame >= 2)
            {
                FirstHidden.Visible = false;
                RealEstatePricesLabel.Visible = true;
                RealEstateLabel.Visible = true;
                RealEstateStatus.Visible = true;
            }
            if (Fame >= 4)
            {
                SecondHidden.Visible = false;
                FashionPricesLabel.Visible = true;
                FashionLabel.Visible = true;
                FashionStatus.Visible = true;
            }
            if (Fame >= 6)
            {
                ThirdHidden.Visible = false;
                ElectronicsPricesLabel.Visible = true;
                ElectronicsLabel.Visible = true;
                ElectronicsStatus.Visible = true;
            }
            if (Fame >= 8)
            {
                FourthHidden.Visible = false;
                VehclePricesLabel.Visible = true;
                VehiclesLabel.Visible = true;
                VehiclesStatus.Visible = true;
            }
            if (Fame >= 8)
            {
                HiddenInvestment.Visible = false;
                InvestPrecentage.Visible = true;
            }
            if (Fame >= 10)
            {
                FifthHidden.Visible = false;
                OilPricesLabel.Visible = true;
                OilSectorLabel.Visible = true;
                OilSectorStatus.Visible = true;
            }
        }

        //
        //TIMER, PRICE CHANGES
        //
        private void PriceChanges_Tick(object sender, EventArgs e)
        {
            
            FoodPrices = FoodBuisnessStatusInt + 5;
            string FoodPricesDisplay = FoodPrices.ToString();
            FoodPriceLabel.Text = FoodPricesDisplay + "$";

            RealEstatePrices = RealEstateStatusInt + 10;
            string RealEstatePricesDisplay = RealEstatePrices.ToString();
            RealEstatePricesLabel.Text = RealEstatePricesDisplay + "$";

            FashionPrices = FashionBuisnessStatusInt + 25;
            string FashionBuisnessPricesDisplay = FashionPrices.ToString();
            FashionPricesLabel.Text = FashionBuisnessPricesDisplay + "$";

            ElectronicsPrices = ElectronicBuisnessStatusInt + 180;
            string ElectronicPricesDisplay = ElectronicsPrices.ToString();
            ElectronicsPricesLabel.Text = ElectronicPricesDisplay + "$";

            VehiclePrices = VehicleBuisnessStatusInt + 380;
            string VehiclePricesDisplay = VehiclePrices.ToString();
            VehclePricesLabel.Text = VehiclePricesDisplay + "$";

            OilPrices = OilSectorStatusInt + 980;
            string OilPricesDisplay = OilPrices.ToString();
            OilPricesLabel.Text = OilPricesDisplay + "$";
        }

        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//

        private void button7_Click(object sender, EventArgs e)
        {
            //Supermarket
            if(Money >= FoodPrices)
            {
                Money = Money - FoodPrices;
                AutoIncome = AutoIncome + 2;
                string AutoIncomeUpdate1 = AutoIncome.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                AutoIncomeNumber.Text = AutoIncomeUpdate1 + "$";
                CurrentEventsDisplay.Text = "You buy a Supermarket.";
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            //Real-Estate
            if (Money >= RealEstatePrices)
            {
                Money = Money - RealEstatePrices;
                AutoIncome = AutoIncome + 5;
                string AutoIncomeUpdate1 = AutoIncome.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                AutoIncomeNumber.Text = AutoIncomeUpdate1 + "$";
                CurrentEventsDisplay.Text = "You buy property.";
            }
        }
        private void FastFoodPurchase_Click(object sender, EventArgs e)
        {
            //Fashion Industry
            if (Money >= FashionPrices)
            {
                Money = Money - FashionPrices;
                AutoIncome = AutoIncome + 10;
                string AutoIncomeUpdate1 = AutoIncome.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                AutoIncomeNumber.Text = AutoIncomeUpdate1 + "$";
                CurrentEventsDisplay.Text = "You invest in a new Fashion designer.";
            }
        }
        private void ElectronicsButton_Click(object sender, EventArgs e)
        {
            //Electronics Industry
            if (Money >= ElectronicsPrices)
            {
                Money = Money - ElectronicsPrices;
                AutoIncome = AutoIncome + 30;
                string AutoIncomeUpdate1 = AutoIncome.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                AutoIncomeNumber.Text = AutoIncomeUpdate1 + "$";
                CurrentEventsDisplay.Text = "You authorize creation of Electronic Products.";
            }
        }
        private void VehiclesButton_Click(object sender, EventArgs e)
        {
            //Vehicle Industry
            if (Money >= VehiclePrices)
            {
                Money = Money - VehiclePrices;
                AutoIncome = AutoIncome + 50;
                string AutoIncomeUpdate1 = AutoIncome.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                AutoIncomeNumber.Text = AutoIncomeUpdate1 + "$";
                CurrentEventsDisplay.Text = "You create a new Car model.";
            }
        }
        private void OilButton_Click(object sender, EventArgs e)
        {
            //Oil Industry
            if (Money >= OilPrices)
            {
                Money = Money - OilPrices;
                AutoIncome = AutoIncome + 100;
                string AutoIncomeUpdate1 = AutoIncome.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                AutoIncomeNumber.Text = AutoIncomeUpdate1 + "$";
                CurrentEventsDisplay.Text = "You expand the drilling industry.";
            }
        }
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //
        //STOCK
        //
        private void button8_Click(object sender, EventArgs e)
        {
            decimal StockPrice = AutoIncome * 4;
            //Stock and Shares, SELL
            if (CompanyShares > 20 && AutoIncome >= 1)
            {
                Money = Money + StockPrice;
                CompanyShares = CompanyShares - 10;
                string CompanySharesDisplay = CompanyShares.ToString();
                CompanySharesPrecentage.Text = CompanySharesDisplay + "%";
                CurrentEventsDisplay.Text = "You sell your company's stock.";
            }
        }
        private void BuyOutCompetitors_Click(object sender, EventArgs e)
        {
            decimal StockPrice = AutoIncome * 4;
            //Stock and Shares, BUY
            if(CompanyShares < 100 && AutoIncome >= 1 && Money >= StockPrice)
            { 
                CompanyShares = CompanyShares + 10;
                Money = Money - StockPrice;
                string CompanySharesDisplay = CompanyShares.ToString();
                CompanySharesPrecentage.Text = CompanySharesDisplay + "%";
                CurrentEventsDisplay.Text = "You buy stock to expand your company.";
            }
        }

        //
        //INVESTMENT
        //
        private void button9_Click(object sender, EventArgs e)
        {
            //Investment
            if (Money > 1 && Money < 10000)
            {
                
                int InvestmentPayoff = rnd.Next(1, 10);
                if(InvestmentPayoff >= 5)
                {
                    Money = Money - (Money / 4);
                    Money = (Money / 2) * 8;
                    CurrentEventsDisplay.Text = "Your investment payed off.";
                    string CurrentMoneyNumberUpdate1 = Money.ToString();
                    CurrentMoneyNumber.Text = CurrentMoneyNumberUpdate1 + "$";
                }
                if(InvestmentPayoff == 5)
                {
                    CurrentEventsDisplay.Text = "You were able to break even.";
                }
                if(InvestmentPayoff <5)
                {
                    Money = Money - (Money / 4);
                    CurrentEventsDisplay.Text = "Your investment failed unfortunately.";
                    string CurrentMoneyNumberUpdate1 = Money.ToString();
                    CurrentMoneyNumber.Text = CurrentMoneyNumberUpdate1 + "$";
                }
            }
        }

        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//

        private void button8_Click_1(object sender, EventArgs e)
        {
            if(Money >= 50 && Fame < 10)
            {
                //Internet Ads
                Money = Money - 50;
                Fame = Fame + 1;
                string FameUpdate = Fame.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                CurrentFame.Text = FameUpdate;
                CurrentEventsDisplay.Text = "You advertise on THE INTERWEBS.";
            }
        }
        private void TVAdsButton_Click(object sender, EventArgs e)
        {
            if (Money >= 100 && Fame < 10)
            {
                //Television Ads
                Money = Money - 150;
                Fame = Fame + 3;
                string FameUpdate = Fame.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                CurrentFame.Text = FameUpdate;
                CurrentEventsDisplay.Text = "You advertise between Episodes of GoT.";
            }
        }
        private void SignSponsorship_Click(object sender, EventArgs e)
        {
            if (Money >= 250 && Fame < 10)
            {
                //Sponsorship
                Money = Money - 250;
                Fame = Fame + 5;
                string FameUpdate = Fame.ToString();
                string DisplayMoney = Money.ToString();
                CurrentMoneyNumber.Text = DisplayMoney + "$";
                CurrentFame.Text = FameUpdate;
                CurrentEventsDisplay.Text = "You sponsor a Star.";
            }
        }

        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//

        private void MarketChangeTimer_Tick(object sender, EventArgs e)
        {
            //Market Chage Mechanic INCREASE
            int ChangeDeterminant = rnd.Next(1, 100);

            if(ChangeDeterminant <= 24)
            {
                //FOOD
                FoodBuisnessStatusInt = FoodBuisnessStatusInt + Fame;
                string FoodBuisDisplay = FoodBuisnessStatusInt.ToString();
                FoodBuisnessStatus.Text = FoodBuisDisplay;

                //REAL-ESTATE
                RealEstateStatusInt = RealEstateStatusInt + Fame * 2;
                string RealEstateBuisDisplay = RealEstateStatusInt.ToString();
                RealEstateStatus.Text = RealEstateBuisDisplay;

                //FASHION
                FashionBuisnessStatusInt = FashionBuisnessStatusInt + Fame * 3;
                string FashionIndustryBuisDisplay = FashionBuisnessStatusInt.ToString();
                FashionStatus.Text = FashionIndustryBuisDisplay;

                //ELECTRONICS
                ElectronicBuisnessStatusInt = ElectronicBuisnessStatusInt + Fame * 4;
                string ElectronicBuisDisplay = ElectronicBuisnessStatusInt.ToString();
                ElectronicsStatus.Text = ElectronicBuisDisplay;

                //VEHICLES
                VehicleBuisnessStatusInt = VehicleBuisnessStatusInt + Fame *5;
                string VehicleBuisnessDisplay = VehicleBuisnessStatusInt.ToString();
                VehiclesStatus.Text = VehicleBuisnessDisplay;

                //OIL
                OilSectorStatusInt = OilSectorStatusInt + Fame * 6;
                string OilSectorBuisDisplay = OilSectorStatusInt.ToString();
                OilSectorStatus.Text = OilSectorBuisDisplay;
            }
            if (ChangeDeterminant >= 25 && ChangeDeterminant <50 && FoodBuisnessStatusInt < 100)
            {
                //FOOD
                FoodBuisnessStatusInt = FoodBuisnessStatusInt + Fame * 2;
                string FoodBuisDisplay = FoodBuisnessStatusInt.ToString();
                FoodBuisnessStatus.Text = FoodBuisDisplay;

                //REAL-ESTATE
                RealEstateStatusInt = RealEstateStatusInt + Fame * 3;
                string RealEstateBuisDisplay = RealEstateStatusInt.ToString();
                RealEstateStatus.Text = RealEstateBuisDisplay;

                //FASHION
                FashionBuisnessStatusInt = FashionBuisnessStatusInt + Fame * 4;
                string FashionIndustryBuisDisplay = FashionBuisnessStatusInt.ToString();
                FashionStatus.Text = FashionIndustryBuisDisplay;

                //ELECTRONICS
                ElectronicBuisnessStatusInt = ElectronicBuisnessStatusInt + Fame *5;
                string ElectronicBuisDisplay = ElectronicBuisnessStatusInt.ToString();
                ElectronicsStatus.Text = ElectronicBuisDisplay;

                //VEHICLES
                VehicleBuisnessStatusInt = VehicleBuisnessStatusInt + Fame*6;
                string VehicleBuisnessDisplay = VehicleBuisnessStatusInt.ToString();
                VehiclesStatus.Text = VehicleBuisnessDisplay;

                //OIL
                OilSectorStatusInt = OilSectorStatusInt + Fame * 7;
                string OilSectorBuisDisplay = OilSectorStatusInt.ToString();
                OilSectorStatus.Text = OilSectorBuisDisplay;
            }
            if (ChangeDeterminant >= 51 && ChangeDeterminant <75 && FoodBuisnessStatusInt < 100)
            {
                //FOOD
                FoodBuisnessStatusInt = FoodBuisnessStatusInt + Fame * 3;
                string FoodBuisDisplay = FoodBuisnessStatusInt.ToString();
                FoodBuisnessStatus.Text = FoodBuisDisplay;

                //REAL-ESTATE
                RealEstateStatusInt = RealEstateStatusInt + Fame * 4;
                string RealEstateBuisDisplay = RealEstateStatusInt.ToString();
                RealEstateStatus.Text = RealEstateBuisDisplay;

                //FASHION
                FashionBuisnessStatusInt = FashionBuisnessStatusInt + Fame * 5;
                string FashionIndustryBuisDisplay = FashionBuisnessStatusInt.ToString();
                FashionStatus.Text = FashionIndustryBuisDisplay;

                //ELECTRONICS
                ElectronicBuisnessStatusInt = ElectronicBuisnessStatusInt + Fame *6;
                string ElectronicBuisDisplay = ElectronicBuisnessStatusInt.ToString();
                ElectronicsStatus.Text = ElectronicBuisDisplay;

                //VEHICLES
                VehicleBuisnessStatusInt = VehicleBuisnessStatusInt + Fame *7;
                string VehicleBuisnessDisplay = VehicleBuisnessStatusInt.ToString();
                VehiclesStatus.Text = VehicleBuisnessDisplay;

                //OIL
                OilSectorStatusInt = OilSectorStatusInt + Fame*8;
                string OilSectorBuisDisplay = OilSectorStatusInt.ToString();
                OilSectorStatus.Text = OilSectorBuisDisplay;
            }
            if (ChangeDeterminant >= 71 && FoodBuisnessStatusInt < 100)
            {
                //FOOD
                FoodBuisnessStatusInt = FoodBuisnessStatusInt + Fame * 4;
                string FoodBuisDisplay = FoodBuisnessStatusInt.ToString();
                FoodBuisnessStatus.Text = FoodBuisDisplay;

                //REAL-ESTATE
                RealEstateStatusInt = RealEstateStatusInt + Fame * 2;
                string RealEstateBuisDisplay = RealEstateStatusInt.ToString();
                RealEstateStatus.Text = RealEstateBuisDisplay;

                //FASHION
                FashionBuisnessStatusInt = FashionBuisnessStatusInt + Fame * 6;
                string FashionIndustryBuisDisplay = FashionBuisnessStatusInt.ToString();
                FashionStatus.Text = FashionIndustryBuisDisplay;

                //ELECTRONICS
                ElectronicBuisnessStatusInt = ElectronicBuisnessStatusInt + Fame *7;
                string ElectronicBuisDisplay = ElectronicBuisnessStatusInt.ToString();
                ElectronicsStatus.Text = ElectronicBuisDisplay;

                //VEHICLES
                VehicleBuisnessStatusInt = VehicleBuisnessStatusInt + Fame*8;
                string VehicleBuisnessDisplay = VehicleBuisnessStatusInt.ToString();
                VehiclesStatus.Text = VehicleBuisnessDisplay;

                //OIL
                OilSectorStatusInt = OilSectorStatusInt + Fame*9;
                string OilSectorBuisDisplay = OilSectorStatusInt.ToString();
                OilSectorStatus.Text = OilSectorBuisDisplay;
            }
            if (FoodBuisnessStatusInt >= 100)
            {
                //Market Change DECREASE
                if (ChangeDeterminant <= 24)
                {
                    //FOOD
                    FoodBuisnessStatusInt = FoodBuisnessStatusInt - (FoodBuisnessStatusInt / 4);
                    string FoodBuisDisplay = FoodBuisnessStatusInt.ToString();
                    FoodBuisnessStatus.Text = FoodBuisDisplay;
                }
                if (ChangeDeterminant >= 25 && ChangeDeterminant < 50)
                {
                    //FOOD
                    FoodBuisnessStatusInt = FoodBuisnessStatusInt - (FoodBuisnessStatusInt / 3);
                    string FoodBuisDisplay = FoodBuisnessStatusInt.ToString();
                    FoodBuisnessStatus.Text = FoodBuisDisplay;
                }
                if (ChangeDeterminant >= 51 && ChangeDeterminant < 75)
                {
                    //FOOD
                    FoodBuisnessStatusInt = FoodBuisnessStatusInt - (FoodBuisnessStatusInt / 2);
                    string FoodBuisDisplay = FoodBuisnessStatusInt.ToString();
                    FoodBuisnessStatus.Text = FoodBuisDisplay;
                }
                if (ChangeDeterminant >= 71)
                {
                    //FOOD
                    FoodBuisnessStatusInt = FoodBuisnessStatusInt - (FoodBuisnessStatusInt - 1);
                    string FoodBuisDisplay = FoodBuisnessStatusInt.ToString();
                    FoodBuisnessStatus.Text = FoodBuisDisplay;
                }
                
            }
            if (RealEstateStatusInt >= 100)
            {
                //Market Change DECREASE
                if (ChangeDeterminant <= 24)
                {
                    //REAL-ESTATE
                    RealEstateStatusInt = RealEstateStatusInt + -(RealEstateStatusInt / 2);
                    string RealEstateBuisDisplay = RealEstateStatusInt.ToString();
                    RealEstateStatus.Text = RealEstateBuisDisplay;
                }
                if (ChangeDeterminant >= 25 && ChangeDeterminant < 50)
                {
                    //REAL-ESTATE
                    RealEstateStatusInt = RealEstateStatusInt - (RealEstateStatusInt / 4);
                    string RealEstateBuisDisplay = RealEstateStatusInt.ToString();
                    RealEstateStatus.Text = RealEstateBuisDisplay;
                }
                if (ChangeDeterminant >= 51 && ChangeDeterminant < 75)
                {
                    //REAL-ESTATE
                    RealEstateStatusInt = RealEstateStatusInt - (RealEstateStatusInt / 1);
                    string RealEstateBuisDisplay = RealEstateStatusInt.ToString();
                    RealEstateStatus.Text = RealEstateBuisDisplay;
                }
                if (ChangeDeterminant >= 71)
                {
                    //REAL-ESTATE
                    RealEstateStatusInt = RealEstateStatusInt - (RealEstateStatusInt - 3);
                    string RealEstateBuisDisplay = RealEstateStatusInt.ToString();
                    RealEstateStatus.Text = RealEstateBuisDisplay;
                }
            }
            if (FashionBuisnessStatusInt >= 100)
            {
                //Market Change DECREASE
                if (ChangeDeterminant <= 24)
                {
                    //FASHION
                    FashionBuisnessStatusInt = FashionBuisnessStatusInt - (FashionBuisnessStatusInt / 1);
                    string FashionIndustryBuisDisplay = FashionBuisnessStatusInt.ToString();
                    FashionStatus.Text = FashionIndustryBuisDisplay;
                }
                if (ChangeDeterminant >= 25 && ChangeDeterminant < 50)
                {
                    //FASHION
                    FashionBuisnessStatusInt = FashionBuisnessStatusInt - (FashionBuisnessStatusInt / 2);
                    string FashionIndustryBuisDisplay = FashionBuisnessStatusInt.ToString();
                    FashionStatus.Text = FashionIndustryBuisDisplay;
                }
                if (ChangeDeterminant >= 51 && ChangeDeterminant < 75)
                {
                    //FASHION
                    FashionBuisnessStatusInt = FashionBuisnessStatusInt - (FashionBuisnessStatusInt / 3);
                    string FashionIndustryBuisDisplay = FashionBuisnessStatusInt.ToString();
                    FashionStatus.Text = FashionIndustryBuisDisplay;
                }
                if (ChangeDeterminant >= 71)
                {
                    //FASHION
                    FashionBuisnessStatusInt = FashionBuisnessStatusInt - (FashionBuisnessStatusInt / 4);
                    string FashionIndustryBuisDisplay = FashionBuisnessStatusInt.ToString();
                    FashionStatus.Text = FashionIndustryBuisDisplay;
                }
            }
            if (ElectronicBuisnessStatusInt >= 100)
            {
                //Market Change DECREASE
                if (ChangeDeterminant <= 24)
                {
                    //ELECTRONICS
                    ElectronicBuisnessStatusInt = ElectronicBuisnessStatusInt - (ElectronicBuisnessStatusInt / 2);
                    string ElectronicBuisDisplay = ElectronicBuisnessStatusInt.ToString();
                    ElectronicsStatus.Text = ElectronicBuisDisplay;
                }
                if (ChangeDeterminant >= 25 && ChangeDeterminant < 50)
                {
                    //ELECTRONICS
                    ElectronicBuisnessStatusInt = ElectronicBuisnessStatusInt - (ElectronicBuisnessStatusInt / 3);
                    string ElectronicBuisDisplay = ElectronicBuisnessStatusInt.ToString();
                    ElectronicsStatus.Text = ElectronicBuisDisplay;
                }
                if (ChangeDeterminant >= 51 && ChangeDeterminant < 75)
                {
                    //ELECTRONICS
                    ElectronicBuisnessStatusInt = ElectronicBuisnessStatusInt - (ElectronicBuisnessStatusInt / 1);
                    string ElectronicBuisDisplay = ElectronicBuisnessStatusInt.ToString();
                    ElectronicsStatus.Text = ElectronicBuisDisplay;
                }
                if (ChangeDeterminant >= 71)
                {
                    //ELECTRONICS
                    ElectronicBuisnessStatusInt = ElectronicBuisnessStatusInt - (ElectronicBuisnessStatusInt / 4);
                    string ElectronicBuisDisplay = ElectronicBuisnessStatusInt.ToString();
                    ElectronicsStatus.Text = ElectronicBuisDisplay;
                }
            }
            if (VehicleBuisnessStatusInt >= 100)
            {
                //Market Change DECREASE
                if (ChangeDeterminant <= 24)
                {
                    //VEHICLES
                    VehicleBuisnessStatusInt = VehicleBuisnessStatusInt - (VehicleBuisnessStatusInt / 3);
                    string VehicleBuisnessDisplay = VehicleBuisnessStatusInt.ToString();
                    VehiclesStatus.Text = VehicleBuisnessDisplay;
                }
                if (ChangeDeterminant >= 25 && ChangeDeterminant < 50)
                {
                    //VEHICLES
                    VehicleBuisnessStatusInt = VehicleBuisnessStatusInt - (VehicleBuisnessStatusInt / 2);
                    string VehicleBuisnessDisplay = VehicleBuisnessStatusInt.ToString();
                    VehiclesStatus.Text = VehicleBuisnessDisplay;
                }
                if (ChangeDeterminant >= 51 && ChangeDeterminant < 75)
                {
                    //VEHICLES
                    VehicleBuisnessStatusInt = VehicleBuisnessStatusInt - (VehicleBuisnessStatusInt / 1);
                    string VehicleBuisnessDisplay = VehicleBuisnessStatusInt.ToString();
                    VehiclesStatus.Text = VehicleBuisnessDisplay;
                }
                if (ChangeDeterminant >= 71)
                {
                    //VEHICLES
                    VehicleBuisnessStatusInt = VehicleBuisnessStatusInt - (VehicleBuisnessStatusInt / 4);
                    string VehicleBuisnessDisplay = VehicleBuisnessStatusInt.ToString();
                    VehiclesStatus.Text = VehicleBuisnessDisplay;
                }
            }
            if (OilSectorStatusInt >= 100)
            {
                //Market Change DECREASE
                if (ChangeDeterminant <= 24)
                {
                    //OIL
                    OilSectorStatusInt = OilSectorStatusInt - (OilSectorStatusInt / 1);
                    string OilSectorBuisDisplay = OilSectorStatusInt.ToString();
                    OilSectorStatus.Text = OilSectorBuisDisplay;
                }
                if (ChangeDeterminant >= 25 && ChangeDeterminant < 50)
                {
                    //OIL
                    OilSectorStatusInt = OilSectorStatusInt - (OilSectorStatusInt / 2);
                    string OilSectorBuisDisplay = OilSectorStatusInt.ToString();
                    OilSectorStatus.Text = OilSectorBuisDisplay;
                }
                if (ChangeDeterminant >= 51 && ChangeDeterminant < 75)
                {
                    //OIL
                    OilSectorStatusInt = OilSectorStatusInt - (OilSectorStatusInt / 3);
                    string OilSectorBuisDisplay = OilSectorStatusInt.ToString();
                    OilSectorStatus.Text = OilSectorBuisDisplay;
                }
                if (ChangeDeterminant >= 71)
                {
                    //OIL
                    OilSectorStatusInt = OilSectorStatusInt - (OilSectorStatusInt / 4);
                    string OilSectorBuisDisplay = OilSectorStatusInt.ToString();
                    OilSectorStatus.Text = OilSectorBuisDisplay;
                }
            }
        }
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
        //----------------------------------------------------------------------------------------//
    }
}

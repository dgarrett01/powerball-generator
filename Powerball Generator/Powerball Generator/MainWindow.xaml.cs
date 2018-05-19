using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace Powerball_Generator
{
    
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        // Declare variables

        // Integer variables for numbers drawn
        int numberOne;
        int numberTwo;
        int numberThree;
        int numberFour;
        int numberFive;
        int powerBall;

        // String variables for printing drawn numbers in text box
        string stringNumberOne;
        string stringNumberTwo;
        string stringNumberThree;
        string stringNumberFour;
        string stringNumberFive;
        string stringPowerBall;
        
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            // Call functions to draw and check numbers
            // for duplicates.
            getNumbers();
            checkNumbers();
        }

        public void getNumbers()
        {
            // Generate random numbers for the Powerball drawing
            Random number = new Random();
            numberOne = number.Next(1, 70);
            numberTwo = number.Next(1, 70);
            numberThree = number.Next(1, 70);
            numberFour = number.Next(1, 70);
            numberFive = number.Next(1, 70);
            powerBall = number.Next(1, 27);
        }

        public void checkNumbers()
        {
            // Add drawing numbers to a list in order to compare them for duplicates
            var listNumbers = new List<int> { numberOne, numberTwo, numberThree, numberFour, numberFive };

            // Check for distinct numbers in the list
            // Diplay the numbers if they're unique, or
            // generate a new list if not.
            if (listNumbers.Distinct().Count() == listNumbers.Count())
            {
                displayNumbers();
            } else {
                getNumbers();
                checkNumbers();
                displayNumbers();
            }            
        }

        public void displayNumbers()
        {
            // Convert numbers to string values
            stringNumberOne = numberOne.ToString();
            stringNumberTwo = numberTwo.ToString();
            stringNumberThree = numberThree.ToString();
            stringNumberFour = numberFour.ToString();
            stringNumberFive = numberFive.ToString();
            stringPowerBall = powerBall.ToString();

            // Display numbers in the list
            textBoxResults.AppendText(stringNumberOne + ", ");
            textBoxResults.AppendText(stringNumberTwo + ", ");
            textBoxResults.AppendText(stringNumberThree + ", ");
            textBoxResults.AppendText(stringNumberFour + ", ");
            textBoxResults.AppendText(stringNumberFive + ", ");
            textBoxResults.AppendText(stringPowerBall + "\n");
        }

        private void buttonClear_Click(object sender, RoutedEventArgs e)
        {
            // Clear the values in the text box
            textBoxResults.Text = "";
        }

        private void buttonQuit_Click(object sender, RoutedEventArgs e)
        {
            // Quit the application
            this.Close();
        }
    }
}

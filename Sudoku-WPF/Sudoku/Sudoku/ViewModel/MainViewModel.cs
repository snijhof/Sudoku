using SudokuGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku;
using System.Windows.Input;
using SudokuGame.MVVM;
using System.Windows;

namespace SudokuGame.ViewModel
{
    class MainViewModel : AbstractViewModel
    {
        private IGame myGame = new Game();
        private int canWrite;
        private short value;

        private String[,] gameValues = new String[9, 9];
        private short[] positions = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        private String[] values = { "", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        #region DataBinding

        public RelayCommand SubmitCommand { get; set; }
        public RelayCommand CheatCommand { get; set; }
        public RelayCommand HintCommand { get; set; }
        public RelayCommand ValidateCommand { get; set; }
        public RelayCommand NewGameCommand { get; set; }

        public short XValue { get; set; }
        public short YValue { get; set; }
        public short Value { get; set; }
        public string[] Values 
        {
            get
            {
                return values;
            }
        }
        public short[] Positions
        {
            get
            {
                return positions;
            }
        }

        public BoxContainerViewModel TopLeftContent { get; set; }
        public BoxContainerViewModel TopCenterContent { get; set; }
        public BoxContainerViewModel TopRightContent { get; set; }

        public BoxContainerViewModel MiddleLeftContent { get; set; }
        public BoxContainerViewModel MiddleCenterContent { get; set; }
        public BoxContainerViewModel MiddleRightContent { get; set; }

        public BoxContainerViewModel BottomLeftContent { get; set; }
        public BoxContainerViewModel BottomCenterContent { get; set; }
        public BoxContainerViewModel BottomRightContent { get; set; }

        #endregion

        public MainViewModel()
        {
            Start();
        }

        public void Start()
        {
            myGame.create();
            myGame.write(out canWrite);

            //Console.Write(canWrite);

            short rowCounter = 1;
            short counter = 1;
            short[] values = new short[9];

            short y = 1;
            short x = 1;

            short maxY = 4;
            short maxX = 4;

            for (short a = 1; a < 10; a++)
            {
                for (short b = 1; b < 10; b++)
                {
                    myGame.get(b, a, out value);
                    Console.Write(value);
                }
                Console.WriteLine("");
            }


            for (short i = 1; i < 10; i++)
            {
                int arrayIndex = 0;
                while (y < maxY)
                {
                    while (x < maxX)
                    {
                        myGame.get(x, y, out value);
                        values[arrayIndex] = value;
                        arrayIndex++;
                        x++;
                    }
                    x -= 3;
                    y++;
                }

                x = maxX;

                switch (rowCounter)
                {
                    case 1:
                        switch (counter)
                        {
                            case 1: TopLeftContent = new BoxContainerViewModel(values); OnPropertyChanged("TopLeftContent"); break;
                            case 2: TopCenterContent = new BoxContainerViewModel(values); OnPropertyChanged("TopCenterContent"); break;
                            case 3: TopRightContent = new BoxContainerViewModel(values); OnPropertyChanged("TopRightContent"); break;
                        }
                        break;
                    case 2:
                        switch (counter)
                        {
                            case 1: MiddleLeftContent = new BoxContainerViewModel(values); OnPropertyChanged("MiddleRightContent"); break;
                            case 2: MiddleCenterContent = new BoxContainerViewModel(values); OnPropertyChanged("MiddleCenterContent"); break;
                            case 3: MiddleRightContent = new BoxContainerViewModel(values); OnPropertyChanged("MiddleLeftContent"); break;
                        }
                        break;
                    case 3:
                        switch (counter)
                        {
                            case 1: BottomLeftContent = new BoxContainerViewModel(values); OnPropertyChanged("BottomRightContent"); break;
                            case 2: BottomCenterContent = new BoxContainerViewModel(values); OnPropertyChanged("BottomCenterContent"); break;
                            case 3: BottomRightContent = new BoxContainerViewModel(values); OnPropertyChanged("BottomLeftContent"); break;
                        }
                        break;
                }

                // Increase the row counter if counter is 3
                if (counter == 3)
                {
                    x = 1;
                    counter = 1;
                    rowCounter++;
                    maxY += 3;
                    maxX = 4;
                }
                else
                {
                    y = maxY;
                    y -= 3;
                    maxX += 3;
                    counter++;
                }
            }
        }

        public BoxContainerViewModel getBoxContainerViewModel(short x, short y)
        {
            if (y < 4)
            {
                if (x < 4)
                {
                    return TopLeftContent;
                }
                else if (x < 7)
                {
                    return TopCenterContent;
                }
                else
                {
                    return TopRightContent;
                }
            }
            else if (y < 7)
            {
                if (x < 4)
                {
                    return MiddleLeftContent;
                }
                else if (x < 7)
                {
                    return MiddleCenterContent;
                }
                else
                {
                    return MiddleRightContent;
                }
            }
            else
            {
                if (x < 4)
                {
                    return BottomLeftContent;
                }
                else if (x < 7)
                {
                    return BottomCenterContent;
                }
                else
                {
                    return BottomRightContent;
                }
            }
        }

        #region RelayCommands

        public void Submit(object commandParam)
        {
            short x = Positions[XValue];
            short y = Positions[YValue];

            int succeeded;
            myGame.set(x, y, Value, out succeeded);

            getBoxContainerViewModel(x, y).Submit(x, y, Value, succeeded);
        }        

        public void Hint(object commandParam)
        {
            short x, y, value;
            int succeeded;

            myGame.hint(out x, out y, out value, out succeeded);
            getBoxContainerViewModel(x, y).Submit(x, y, value, succeeded);
        }

        public void Validate(object commandParam)
        {
            int valid;

            myGame.isValid(out valid);

            if (valid == 1)
            {
                // You have won the game!
                MessageBox.Show("Everything is correct!", "No mistakes!", MessageBoxButton.OK);
            }
            else
            {
                // You have made some mistakes...
                MessageBox.Show("You have made some mistakes...", "Keep sweating!", MessageBoxButton.OK);
            }
        }

        public void Cheat(object commandParam)
        {
            int succeeded;
            for (int i = 0; i < 1000; i++ )
            {
                short x, y, value;

                myGame.hint(out x, out y, out value, out succeeded);
                getBoxContainerViewModel(x, y).Submit(x, y, value, succeeded);
            }
        }

        public void NewGame(object commandParam)
        {
            Start();
        }

        #endregion

        protected override void initRelayCommands()
        {
            SubmitCommand = new RelayCommand(Submit);
            CheatCommand = new RelayCommand(Cheat);
            HintCommand = new RelayCommand(Hint);
            ValidateCommand = new RelayCommand(Validate);
            NewGameCommand = new RelayCommand(NewGame);
        }
    }
}

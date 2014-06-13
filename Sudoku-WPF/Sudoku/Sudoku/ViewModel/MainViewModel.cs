using SudokuGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku;

namespace SudokuGame.ViewModel
{
    class MainViewModel : AbstractViewModel
    {
        private IGame myGame = new Game();
        private int canWrite;
        private short value;

        private String[,] gameValues = new String[9, 9];

        #region DataBinding

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
                                case 1: TopLeftContent = new BoxContainerViewModel(1, 1, values); OnPropertyChanged("TopLeftContent"); break;
                                case 2: TopCenterContent = new BoxContainerViewModel(4, 1, values); OnPropertyChanged("TopCenterContent"); break;
                                case 3: TopRightContent = new BoxContainerViewModel(7, 1, values); OnPropertyChanged("TopRightContent"); break;
                            }
                            break;
                        case 2:
                            switch (counter)
                            {
                                case 1: MiddleLeftContent = new BoxContainerViewModel(1, 4, values); OnPropertyChanged("MiddleRightContent"); break;
                                case 2: MiddleCenterContent = new BoxContainerViewModel(4, 4, values); OnPropertyChanged("MiddleCenterContent"); break;
                                case 3: MiddleRightContent = new BoxContainerViewModel(7, 4, values); OnPropertyChanged("MiddleLeftContent"); break;
                            }
                            break;
                        case 3:
                            switch (counter)
                            {
                                case 1: BottomLeftContent = new BoxContainerViewModel(1, 7, values); OnPropertyChanged("BottomRightContent"); break;
                                case 2: BottomCenterContent = new BoxContainerViewModel(4, 7, values); OnPropertyChanged("BottomCenterContent"); break;
                                case 3: BottomRightContent = new BoxContainerViewModel(7, 7, values); OnPropertyChanged("BottomLeftContent"); break;
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

        protected override void initRelayCommands()
        {
        }
    }
}

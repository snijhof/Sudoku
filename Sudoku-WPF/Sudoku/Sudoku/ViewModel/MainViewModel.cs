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

            Console.Write(canWrite);

            short rowCounter = 0;
            short counter = 0;
            short[] values = new short[9];

            for (short x = 1; x < 10; x++)
            {
                for (short y = 1; y < 10; y++)
                {
                    myGame.get(x, y, out value);
                    values[y - 1] = value;
                }

                switch (rowCounter) 
                {
                    case 0:
                        switch (counter)
                        {
                            case 0: TopLeftContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("TopLeftContent"); break;
                            case 1: TopCenterContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("TopCenterContent"); break;
                            case 2: TopRightContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("TopRightContent"); break;
                        }
                        break;
                    case 1:
                        switch (counter)
                        {
                            case 0: MiddleLeftContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("MiddleRightContent"); break;
                            case 1: MiddleCenterContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("MiddleCenterContent"); break;
                            case 2: MiddleRightContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("MiddleLeftContent"); break;
                        }
                        break;
                    case 2:
                        switch (counter)
                        {
                            case 0: BottomLeftContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("BottomRightContent"); break;
                            case 1: BottomCenterContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("BottomCenterContent"); break;
                            case 2: BottomRightContent = new BoxContainerViewModel(counter, rowCounter, values); OnPropertyChanged("BottomLeftContent"); break;
                        }
                        break;
                }

                // Increase the row counter if counter is 2
                if (counter == 2)
                {
                    counter = 0;
                    rowCounter++;
                }
                else
                    counter++;
            }
        }

        protected override void initRelayCommands()
        {
        }
    }
}

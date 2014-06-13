using Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame.ViewModel
{
    class BoxContainerViewModel : AbstractViewModel
    {
        private String[] values = { "", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private IGame myGame = new Game();
        private short xPosition;
        private short yPosition;
        private short topLeft, topCenter, topRight;
        private short middleLeft, middleCenter, middleRight;
        private short bottomLeft, bottomCenter, bottomRight;
        private int succeeded;

        #region DataBinding

        public String[] Values 
        { 
            get
            {
                return values;
            }
        }

        public short TopLeft 
        { 
            get
            {
                return topLeft;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    topLeft = value;
                    OnPropertyChanged("TopLeft");
                }
            }
        }
        public short TopCenter
        {
            get
            {
                return topCenter;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    topCenter = value;
                    OnPropertyChanged("TopCenter");
                }
            }
        }
        public short TopRight
        {
            get
            {
                return topRight;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    topRight = value;
                    OnPropertyChanged("TopRight");
                }
            }
        }

        public short MiddleLeft
        {
            get
            {
                return middleLeft;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    middleLeft = value;
                    OnPropertyChanged("MiddleLeft");
                }
            }
        }
        public short MiddleCenter
        {
            get
            {
                return middleCenter;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    middleCenter = value;
                    OnPropertyChanged("MiddleCenter");
                }
            }
        }
        public short MiddleRight
        {
            get
            {
                return middleRight;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    middleRight = value;
                    OnPropertyChanged("MiddleRight");
                }
            }
        }

        public short BottomLeft
        {
            get
            {
                return bottomLeft;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    bottomLeft = value;
                    OnPropertyChanged("BottomLeft");
                }
            }
        }
        public short BottomCenter
        {
            get
            {
                return bottomCenter;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    bottomCenter = value;
                    OnPropertyChanged("BottomCenter");
                }
            }
        }
        public short BottomRight
        {
            get
            {
                return bottomRight;
            }
            set
            {
                myGame.set(xPosition, yPosition, value, out succeeded);
                if (succeeded == 1)
                {
                    bottomRight = value;
                    OnPropertyChanged("BottomRight");
                }
            }
        }

        public bool TopLeftEnabled { get; set; }
        public bool TopCenterEnabled { get; set; }
        public bool TopRightEnabled { get; set; }

        public bool MiddleLeftEnabled { get; set; }
        public bool MiddleCenterEnabled { get; set; }
        public bool MiddleRightEnabled { get; set; }

        public bool BottomLeftEnabled { get; set; }
        public bool BottomCenterEnabled { get; set; }
        public bool BottomRightEnabled { get; set; }

        #endregion

        public BoxContainerViewModel(short x, short y, short[] values)
        {
            // Set the position of the container
            this.xPosition = x;
            this.yPosition = y;

            Console.WriteLine("X: " + x + ", Y: " + y);
            for (int i = 0; i < values.Length; i++ )
            {
                Console.WriteLine("Index: " + i + ", value: " + values[i]);
            }

            // Set the values
            topLeft = values[0];
            topCenter = values[1];
            topRight = values[2];

            middleLeft = values[3];
            middleCenter = values[4];
            middleRight = values[5];

            bottomLeft = values[6];
            bottomCenter = values[7];
            bottomRight = values[8];

            // Enable and disable the comboboxes
            TopLeftEnabled = values[0] != 0 ? false : true;
            TopCenterEnabled = values[1] != 0 ? false : true;
            TopRightEnabled = values[2] != 0 ? false : true;
            MiddleLeftEnabled = values[3] != 0 ? false : true;
            MiddleCenterEnabled = values[4] != 0 ? false : true;
            MiddleRightEnabled = values[5] != 0 ? false : true;
            BottomLeftEnabled = values[6] != 0 ? false : true;
            BottomCenterEnabled = values[7] != 0 ? false : true;
            BottomRightEnabled = values[8] != 0 ? false : true;
        }

        #region Relay Commands

        public void method()
        {

        }

        #endregion

        protected override void initRelayCommands()
        {
        }
    }
}

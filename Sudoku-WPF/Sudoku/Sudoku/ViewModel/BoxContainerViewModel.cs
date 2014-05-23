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
                topCenter = value;
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
                topRight = value;
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
                middleLeft = value;
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
                middleCenter = value;
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
                middleRight = value;
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
                bottomLeft = value;
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
                bottomCenter = value;
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
                bottomRight = value;
            }
        }

        #endregion

        public BoxContainerViewModel(short x, short y, short[] values)
        {
            // Set the position of the container
            this.xPosition = x;
            this.yPosition = y;

            // Set the values
            TopLeft = values[0];
            TopCenter = values[1];
            TopRight = values[2];

            MiddleLeft = values[3];
            MiddleCenter = values[4];
            MiddleRight = values[5];

            BottomLeft = values[6];
            BottomCenter = values[7];
            BottomRight = values[8];
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

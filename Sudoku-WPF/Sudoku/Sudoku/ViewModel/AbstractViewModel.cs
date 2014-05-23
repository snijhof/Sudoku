using SudokuGame.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuGame.ViewModel
{
    public abstract class AbstractViewModel : PropertyChangedBase
    {
        public AbstractViewModel()
        {
            initRelayCommands();
        }

        protected abstract void initRelayCommands();
    }
}

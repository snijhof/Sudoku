using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sudoku_ASP.Controllers
{
    public class DefaultController : Controller
    {
        // Variables
        private static Sudoku.IGame game;
        private int[,] values = new int[9, 9];

        // GET: Default
        public ActionResult Index()
        {
            if (game == null)
            {
                game = new Sudoku.Game();
                int canWrite;
                game.create();
                game.write(out canWrite);
            }

            if (Request.QueryString.Count == 3)
            {
                string requestValues = Request.QueryString.ToString();
                string[] values = requestValues.Split('&');

                short x, y, value;
                short.TryParse(values[0].Last().ToString(), out x);
                short.TryParse(values[1].Last().ToString(), out y);
                short.TryParse(values[2].Last().ToString(), out value);

                int canAdapt, canWrite;
                game.set(x, y, value, out canAdapt);
                game.write(out canWrite);
            }

            for (short row = 0; row < 9; row++)
            {
                for (short col = 0; col < 9; col++)
                {
                    short value;
                    short nRow = (short)(row + 1);
                    short nCol = (short)(col + 1);
                    game.get(nRow, nCol, out value);
                    values[row, col] = value;
                }
            }

            return View(values);
        }

        public string Validate()
        {
            int isValid;
            game.isValid(out isValid);

            if (isValid == 1)
            {
                return "The values are correct!";
            }
            else
            {
                return "Some values are not correct!";
            }
        }

        //public void Hint(object commandParam)
        //{
        //    short x, y, value;
        //    int succeeded;

        //    game.hint(out x, out y, out value, out succeeded);
        //    values[x, y] = value;
        //}

        //public void Cheat(object commandParam)
        //{
        //    int succeeded;
        //    for (int i = 0; i < 1000; i++)
        //    {
        //        short x, y, value;

        //        game.hint(out x, out y, out value, out succeeded);
        //        values[x, y] = value;
        //    }
        //}
    }
}
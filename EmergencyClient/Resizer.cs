using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmergencyClient
{
    class Resizer
    {
        int HEIGHT;
        Font gridFont;
        int gridRowHeight;
        int percent;
        float scaleFactor;
        bool resizeGrid;

        public Resizer(Font font, int height, int formHeight, bool isGrid)
        {
            gridFont = font;
            gridRowHeight = height;
            HEIGHT = formHeight;
            resizeGrid = isGrid;
        }

        public Font GridFont { get { return gridFont; } set { gridFont = value; } }
        public int GridRowHeight { get { return gridRowHeight; } set { gridRowHeight = value; } }

        public void ResizeForm(int lastFormHeight, bool isMaximized, DataGridView dataGrid, Control.ControlCollection coll)
        {
            ResizeGridFont(lastFormHeight, isMaximized, dataGrid);

            if (dataGrid.RowCount != 0 && resizeGrid)
                ResizeGrid(dataGrid);

            ResizeFont(coll);
        }

        private float LargerFontFactor(int height)
        {
            return 1.5f * height / 1050;
        }

        private float SmallerFontFactor(int height)
        {
            return 1 / (1.5f * height / 1050);
        }

        private void ResizeFont(Control.ControlCollection coll)
        {
            foreach (Control c in coll)
            {
                if (c.HasChildren)
                {
                    ResizeFont(c.Controls);
                }
                else
                {
                    if (true)
                    {
                        // scale font
                        c.Font = new Font(c.Font.FontFamily.Name, c.Font.Size * scaleFactor, c.Font.Style);
                    }
                }
            }
        }

        private void ResizeGridFont(int lastFormHeight, bool isMaximized, DataGridView dataGrid)
        {
            if (!isMaximized)
            {
                scaleFactor = LargerFontFactor(lastFormHeight);
                percent = 100 - GetPercent(lastFormHeight, HEIGHT);
                percent = GetPercentFromNumber(percent, gridRowHeight);
            }
            else
            {
                scaleFactor = SmallerFontFactor(lastFormHeight);
                percent = 100 - GetPercent(lastFormHeight, HEIGHT);
                percent = GetPercentFromNumber(percent, 50);
                percent *= -1;
            }

            if (resizeGrid)
            {
                gridFont = new Font(gridFont.FontFamily.Name, gridFont.Size * scaleFactor, gridFont.Style);
                gridRowHeight += percent;
            }

            ResizeGridHeaders(dataGrid);
        }

        private void ResizeGridHeaders(DataGridView dataGrid)
        {
            foreach (DataGridViewColumn col in dataGrid.Columns)
            {
                if (col.HeaderCell.Style.Font != null)
                {
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.Font = new Font(col.HeaderCell.Style.Font.FontFamily.Name, col.HeaderCell.Style.Font.Size * scaleFactor, FontStyle.Bold);
                    col.HeaderCell.Style = style;
                }
            }
        }

        private void ResizeGrid(DataGridView dataGrid)
        {
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                row.Height = gridRowHeight;

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    row.Cells[i].Style.Font = gridFont;
                }
            }
        }

        private int GetPercent(int b, int a)
        {
            if (b == 0) return 0;

            return (int)(a / (b / 100M));
        }

        private int GetPercentFromNumber(int percent, int num)
        {
            if (num == 0) return 0;

            return (int)(num * percent / 100M);
        }
    }
}

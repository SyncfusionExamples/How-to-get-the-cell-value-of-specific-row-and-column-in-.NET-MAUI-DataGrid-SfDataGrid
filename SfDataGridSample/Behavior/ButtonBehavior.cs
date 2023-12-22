using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample.Behaviors
{
    public class ButtonBehavior : Behavior<Button>
    {
        protected override void OnAttachedTo(Button button)
        {
            base.OnAttachedTo(button);
            button.Clicked += OnButtonClicked!;
        }

        protected override void OnDetachingFrom(Button button)
        {
            base.OnDetachingFrom(button);
            button.Clicked -= OnButtonClicked!;
        }

        string? cellValue;
        private void OnButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var stackLayout = button!.Parent as StackLayout;
            var dataGrid = stackLayout!.Children[0] as SfDataGrid;
            foreach (var column in dataGrid!.Columns)
            {
                if (column.MappingName == "Name")
                {
                    var rowData = dataGrid.GetRecordAtRowIndex(1);
                    cellValue = dataGrid.GetCellValue(rowData, column.MappingName) as String;
                    break;
                }
            }
            Application.Current!.MainPage!.DisplayAlert("ColumnName", cellValue, "Cancel");
        }
    }
}

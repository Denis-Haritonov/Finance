// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GridRenderer.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Common.Grid
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AdditionalClasses;
    using Common;   
    using Enum;
    using Html;
    using Interfaces;
    
    /// <summary>
    /// Render grid in html tag
    /// </summary>
    public class GridRenderer : IGridRenderer
    {
        /// <summary>
        /// Create grid from type
        /// </summary>
        private IGridReflector reflector;

        /// <summary>
        /// Initializes a new instance of the <see cref="GridRenderer"/> class.
        /// </summary>
        /// <param name="reflector">Reflects provided type to grid</param>
        public GridRenderer(IGridReflector reflector)
        {
            this.reflector = reflector;
        }

        /// <summary>
        /// Render grid
        /// </summary>
        /// <param name="t">Grid to render</param>
        /// <param name="entities">Entities for render</param>
        /// <param name="mode">Template render mode</param>
        /// <param name="sorting">Grid sorting</param>
        /// <returns>Rendered grid as string</returns>
        public string Render(Type t, PagingCollection<object> entities, TemplateMode mode, GridSorting sorting)
        {
            var grid = this.reflector.Reflect(t, mode);

            if (sorting != null)
            {
                grid.Sorting = sorting;
            }

            grid.Rows = grid.Rows.OrderBy(r => r.Order).ToList();
            var headerRender = this.RenderHeader(grid);
            var bodyRender = this.RenderBody(grid, entities.CurrentPageCollection.ToList());
            return string.Format("<div class=\"enable-grid-hor-overflow\"><table class=\"table table-bordered entity-grid dataTable\">{0}{1}</table></div>{2}", headerRender, bodyRender, this.RenderPaginanation(entities));
        }

        /// <summary>
        /// Set html properties for cell
        /// </summary>
        /// <param name="cellToConfigurate">Cell for setup</param>
        /// <param name="grid">Grid to render</param>
        /// <param name="row">Row to get properties</param>
        /// <returns>Configured header cell</returns>
        private HtmlTableHeaderCell ConfigureHeaderCell(HtmlTableHeaderCell cellToConfigurate, Grid grid, GridRow row)
        {         
            if (row.NonBordered)
            {
                cellToConfigurate.Styles.Add("display:none");
            }

            if (row.ColumnName != null)
            {
                cellToConfigurate.InnerHtml = row.ColumnName;
            }

            if (row.ColumnWidth != 0)
            {
                cellToConfigurate.Styles.Add(string.Format("max-width:{0}px", row.ColumnWidth));
            }

            if (!string.IsNullOrEmpty(row.DataField))
            {
                cellToConfigurate.Attributes.Add(new KeyValuePair<string, string>("data-field", row.DataField));
            }

            if (!string.IsNullOrEmpty(row.ModelField))
            {
                cellToConfigurate.Attributes.Add(new KeyValuePair<string, string>("data-modelfield", row.ModelField));
            }

            if (row.IsSortable)
            {
                cellToConfigurate.Classes.Add("sort-row");
                if (grid.Sorting != null && grid.Sorting.SortColumnName == row.DataField)
                {
                    cellToConfigurate.Classes.Add("current-sort");
                    if (grid.Sorting.LowestToHight)
                    {
                        cellToConfigurate.Classes.Add("sorting_asc");
                    }
                    else
                    {
                        cellToConfigurate.Classes.Add("sorting_desc");
                    }
                }
                else
                {
                    cellToConfigurate.Classes.Add("sorting");
                }
            }

            if (row.IsHidden)
            {
                cellToConfigurate.Styles.Add("display:none");
            }

            return cellToConfigurate;
        }

        /// <summary>
        /// Renders grid header
        /// </summary>
        /// <param name="grid">Grid to render</param>
        /// <returns>Rendered in string grid</returns>
        private string RenderHeader(Grid grid)
        {
            var headerRender = string.Empty;
            foreach (var row in grid.Rows)
            {
                var headerCell = new HtmlTableHeaderCell();
                headerCell = this.ConfigureHeaderCell(headerCell, grid, row);
                headerRender += headerCell.ToString();              
            }

            return string.Format("<thead><tr>{0}</tr></thead>", headerRender);
        }

        /// <summary>
        /// Render grid body
        /// </summary>
        /// <param name="grid">Grid to render</param>
        /// <param name="entities">List of entities to render</param>
        /// <returns>Render grid body in string</returns>
        private string RenderBody(Grid grid, List<object> entities)
        {
            var bodyRender = string.Empty;
            foreach (var entity in entities)
            {
                var column = string.Empty;
                foreach (var row in grid.Rows)
                {
                    var cell = new HtmlTableCell();                   
                    cell = this.ConfigureTableCell(cell, row, entity);
                    column += cell.ToString();                   
                }

                bodyRender += string.Format("<tr>{0}</tr>", column);
            }

            return string.Format("<tbody>{0}</tbody>", bodyRender);
        }

        /// <summary>
        /// Config table cell
        /// </summary>
        /// <param name="cellToConfigurate">Cell for configuration</param>
        /// <param name="row">Contains config properties</param>
        /// <param name="entity">Entity to config column</param>
        /// <returns>Config column</returns>
        private HtmlTableCell ConfigureTableCell(HtmlTableCell cellToConfigurate, GridRow row, object entity)
        {
            cellToConfigurate = row.RenderTemplate.Render(entity);
            if (row.NonBordered)
            {
                cellToConfigurate.Styles.Add("border:none");
            }

            if (row.IsKey)
            {
                cellToConfigurate.Classes.Add("key");
            }

            if (row.ColumnWidth != 0)
            {
                cellToConfigurate.Styles.Add(string.Format("max-width:{0}px", row.ColumnWidth));
                cellToConfigurate.Styles.Add("word-wrap:break-word");
            }

            if (!string.IsNullOrEmpty(row.DataField))
            {
                cellToConfigurate.Attributes.Add(new KeyValuePair<string, string>("data-field", row.DataField));
            }

            if (row.IsHidden)
            {
                cellToConfigurate.Styles.Add("display:none");
            }

            return cellToConfigurate;
        }

        /// <summary>
        /// Render pagination
        /// </summary>
        /// <param name="collection">Paging collection</param>
        /// <returns>Rendered pagination</returns>
        private string RenderPaginanation(PagingCollection<object> collection)
        {           
            if (collection.PagesCount > 1  && collection.CurrentPage != 0)
            {
                var pagination = "<div><nav class=\"pull-right\"><ul class=\"pagination\">";
                pagination += string.Format("<li data-page=\"1\"><a href=\"#\" >{0}</a></li>", "Перв");
                if (collection.CurrentPage > 1)
                {
                    pagination += string.Format("<li data-page=\"{1}\"><a href=\"#\" >{0}</a></li>", "Пред", collection.CurrentPage - 1);
                    pagination += string.Format("<li data-page=\"{0}\"><a href=\"#\" >{0}</a></li>", collection.CurrentPage - 1);
                }

                pagination += string.Format("<li class=\"active\" data-page=\"{0}\"><a href=\"#\">{0}</a></li>", collection.CurrentPage);
                if (collection.CurrentPage < collection.PagesCount)
                {
                    pagination += string.Format("<li data-page=\"{0}\"><a href=\"#\">{0}</a></li>", collection.CurrentPage + 1);
                    pagination += string.Format("<li data-page=\"{1}\"><a href=\"#\">{0}</a></li>", "Cлед", collection.CurrentPage + 1);
                }

                pagination += string.Format("<li data-page=\"{1}\"><a href=\"#\" >{0}</a></li>", "Посл" , collection.PagesCount);
                pagination += "</ul></nav></div>";
                return pagination;
            }

            return string.Empty;
        }
    }
}

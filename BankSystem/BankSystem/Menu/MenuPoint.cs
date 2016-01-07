using Common.Enum;

namespace Pl.Web.Portal.Menu
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Store fields for menu rendering
    /// </summary>
    public class MenuPoint
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuPoint"/> class.
        /// </summary>
        /// <param name="visibleFor">List of roles that can see that menu point</param>
        public MenuPoint(List<Roles> visibleFor = null)
        {
            if (visibleFor == null)
            {
                this.VisibleForRoles = Enum.GetValues(typeof(Roles)).Cast<Roles>().ToList();
            }
            else
            {
                this.VisibleForRoles = visibleFor;
            }

            this.ChildPoints = new List<MenuPoint>();
        }

        /// <summary>
        /// Menu point text and name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Url for menu point
        /// </summary>
        public string PointUrl { get; set; }

        /// <summary>
        /// Parent point
        /// </summary>
        public MenuPoint ParentPoint { get; set; }

        /// <summary>
        /// Child points
        /// </summary>
        public List<MenuPoint> ChildPoints { get; set; }

        /// <summary>
        /// User roles that can see this item
        /// </summary>
        private List<Roles> VisibleForRoles { get; set; }

        /// <summary>
        /// Is link should be marked as active
        /// </summary>
        /// <param name="currentUrl">Current request url</param>
        /// <returns>True if should be active</returns>
        public bool IsActive(string currentUrl)
        {
            if (this.PointUrl.ToLower() == currentUrl.ToLower() || this.ChildPoints.Any(point => point.IsActive(currentUrl)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Show is link will be visible
        /// </summary>
        /// <param name="currentRole">Current user role</param>
        /// <returns>Is link rendered</returns>
        public bool IsVisible(Roles currentRole)
        {
            return this.VisibleForRoles.Contains(currentRole);
        }

        /// <summary>
        /// Render submenu item in string
        /// </summary>
        /// <param name="currentUrl">Current request url</param>
        /// <param name="currentRole">Current user role</param>
        /// <returns>Menu item rendered in string</returns>
        public string Render(string currentUrl, Roles currentRole)
        {
            if (this.IsVisible(currentRole))
            {
                if (this.IsActive(currentUrl))
                {
                    if (this.ChildPoints.Any())
                    {
                        return string.Format(
                            MenuPointRenderTemplates.ActivePointWithChildren,
                            this.PointUrl,
                            this.Name,
                            this.RenderChildPoints(currentUrl, currentRole));
                    }
                    else
                    {
                        return string.Format(MenuPointRenderTemplates.ActivePointWithoutChildren, this.PointUrl, this.Name);
                    }
                }
                else
                {
                    if (this.ChildPoints.Any())
                    {
                        return string.Format(
                            MenuPointRenderTemplates.PointWithChildren,
                            this.PointUrl,
                            this.Name,
                            this.RenderChildPoints(currentUrl, currentRole));
                    }
                    else
                    {
                        return string.Format(MenuPointRenderTemplates.PointWithoutChildren, this.PointUrl, this.Name);
                    }
                }
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Render child menu items in html string
        /// </summary>
        /// <param name="currentUrl">Current request url</param>
        /// <param name="currentRole">Current user url</param>
        /// <returns>Menu item stored in string</returns>
        private string RenderChildPoints(string currentUrl, Roles currentRole)
        {
            var result = string.Empty;
            this.ChildPoints.ForEach(mp => result += mp.Render(currentUrl, currentRole));
            return result;
        }
    }
}
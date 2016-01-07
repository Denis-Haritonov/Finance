// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuPointRenderTemplates.cs" company="ZigZag">
//   Copyright © ZigZag 2015
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Pl.Web.Portal.Menu
{
    /// <summary>
    /// Templates for links render
    /// </summary>
    public static class MenuPointRenderTemplates
    {
        /// <summary>
        /// template for point without child
        /// </summary>
        internal const string PointWithoutChildren = @"<li>
                                                           <a href=""{0}"">
                                                               <i class=""menu-icon fa fa-caret-right""></i>
                                                               <span class=""menu-text"">{1}</span>
                                                           </a>
                                                       </li>";
        //// "<li class=\"\"><a href=\"{0}\"><i class=\"menu-icon fa fa-caret-right\"></i><span>{1}</span></a></li>";

        /// <summary>
        /// template for active point without child 
        /// </summary>
        internal const string ActivePointWithoutChildren = @"<li class=""active"">
                                                                <a href=""{0}"">
                                                                    <i class=""menu-icon fa fa-caret-right""></i>
                                                                    <span class=""menu-text"">{1}</span>
                                                                </a>
                                                              </li>";
        //// "<li class=\"active\"><a href=\"{0}\"><i class=\"menu-icon fa fa-caret-right\"></i><span>{1}</span></a></li>";

        /// <summary>
        /// template for point with inner points
        /// </summary>
        internal const string PointWithChildren = @"<li class="""">
                                                        <a class=""dropdown-toggle"" href=""{0}"">
                                                            <i class=""menu-icon fa fa-caret-right""></i>
                                                            <span class=""menu-text"">{1}</span>
                                                            <b class=""arrow fa fa-angle-down""></b>
                                                            <!-- arrow down icon if there's a submenu -->
                                                        </a>
                                                        <ul class=""submenu"">
                                                        {2}
                                                        </ul>
                                                    </li>";

        //// "<li lass=\"\"><a class=\"dropdown-toggle\" href=\"{0}\"><i class=\"menu-icon fa fa-caret-right\"></i>{1}<b class=\"arrow fa fa-angle-down\"></b></a><ul class=\"submebu\">{2}</ul></li>";

        /// <summary>
        /// template for active point with 
        /// </summary>
        internal const string ActivePointWithChildren = @"  <li class=""active"">
                                                                <a class=""dropdown-toggle"" href=""{0}"">
                                                                    <i class=""menu-icon fa fa-caret-right""></i>
                                                                    <span class=""menu-text"">{1}</span>
                                                                    <b class=""arrow fa fa-angle-down""></b>
                                                                    <!-- arrow down icon if there's a submenu -->
                                                                </a>
                                                                <ul class=""submenu"">
                                                                {2}
                                                                </ul>
                                                            </li>";

        //// "<li class=\"active\"><a class=\"dropdown-toggle\" href=\"{0}\"><i class=\"menu-icon fa fa-caret-right\"></i>{1}<b class=\"arrow fa fa-angle-down\"></b></a><ul class=\"submenu\">{2}</ul></li>";
    }
}
using System.Web;
using System.Web.Optimization;

namespace BankSystem
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/BotThemeScript").Include(
                        "~/Scripts/jquery-1.9.1.js",
                        "~/Scripts/Janux/bootstrap.js",
                        "~/Scripts/counter.js",
                        "~/Scripts/custom.js",
                        "~/Scripts/excanvas.js",
                        "~/Scripts/fullcalendar.min.js",
                        "~/Scripts/jquery-migrate-1.0.0.js",
                        "~/Scripts/jquery-ui-1.10.0.custom.js",
                        "~/Scripts/jquery.chosen.js",
                        "~/Scripts/jquery.cleditor.js",
                        "~/Scripts/jquery.cookie.js",
                        "~/Scripts/jquery.dataTables.js",
                        "~/Scripts/jquery.elfinder.js",
                        "~/Scripts/jquery.flot.js",
                        "~/Scripts/jquery.flot.pie.js",
                        "~/Scripts/jquery.flot.resize.js",
                        "~/Scripts/jquery.flot.stack.js",
                        "~/Scripts/jquery.gritter.js",
                        "~/Scripts/jquery.iphone.toggle.js",
                        "~/Scripts/jquery.knob.modified.js",
                        "~/Scripts/jquery.masonry.js",
                        "~/Scripts/jquery.noty.js",
                        "~/Scripts/jquery.raty.js",
                        "~/Scripts/jquery.sparkline.js",
                        "~/Scripts/jquery.ui.touch-punch.js",
                        "~/Scripts/jquery.uniform.js",
                        "~/Scripts/jquery.uploadify-3.1.js",
                        "~/Scripts/retina.js"));

            bundles.Add(new StyleBundle("~/BotThemeStyle").Include(
                        "~/Content/Janux/bootstrap-responsive.css",
                        "~/Content/Janux/bootstrap.css",
                        "~/Content/Janux/chosen.css",
                        "~/Content/Janux/elfinder.min.css",
                        "~/Content/Janux/elfinder.theme.css",
                        "~/Content/Janux/font-awesome-ie7.min.css",
                        "~/Content/Janux/font-awesome.min.css",
                        "~/Content/Janux/fullcalendar.css",
                        "~/Content/Janux/glyphicons.css",
                        "~/Content/Janux/halflings.css",
                        "~/Content/Janux/ie.css",
                        "~/Content/Janux/ie9.css",
                        "~/Content/Janux/jquery.cleditor.css",
                        "~/Content/Janux/jquery.gritter.css",
                        "~/Content/Janux/jquery.iphone.toggle.css",
                        "~/Content/Janux/jquery.noty.css",
                        "~/Content/Janux/noty_theme_default.css",
                        "~/Content/Janux/Site.css",
                        "~/Content/Janux/style-forms.css",
                        "~/Content/Janux/style-responsive.css",
                        "~/Content/Janux/janux/style.css",
                        "~/Content/Janux/uniform.default.css",
                        "~/Content/Janux/style.css",
                        "~/Content/Janux/uploadify.css",
                        "~/Content/jquery-ui-1.8.21.custom.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/datepicker.css",
                      "~/Content/Gridmvc.css",
                      "~/Content/gridmvc.datepicker.css",
                      "~/Content/facebox.css"));
        }
    }
}
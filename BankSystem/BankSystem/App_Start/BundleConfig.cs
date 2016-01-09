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
                        "~/Scripts/bootstrap.js",
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
                        "~/Content/bootstrap-responsive.css",
                        "~/Content/bootstrap.css",
                        "~/Content/chosen.css",
                        "~/Content/elfinder.min.css",
                        "~/Content/elfinder.theme.css",
                        "~/Content/font-awesome-ie7.min.css",
                        "~/Content/font-awesome.min.css",
                        "~/Content/fullcalendar.css",
                        "~/Content/glyphicons.css",
                        "~/Content/halflings.css",
                        "~/Content/ie.css",
                        "~/Content/ie9.css",
                        "~/Content/jquery.cleditor.css",
                        "~/Content/jquery.gritter.css",
                        "~/Content/jquery.iphone.toggle.css",
                        "~/Content/jquery.noty.css",
                        "~/Content/noty_theme_default.css",
                        "~/Content/Site.css",
                        "~/Content/style-forms.css",
                        "~/Content/style-responsive.css",
                        "~/Content/style.css",
                        "~/Content/uniform.default.css",
                        "~/Content/uploadify.css",
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
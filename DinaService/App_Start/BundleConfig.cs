using System.Web.Optimization;

namespace DinaService
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/App_theme/DinaTheme/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/App_theme/DinaTheme/js/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/App_theme/DinaTheme/js/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/App_theme/DinaTheme/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/all").Include(
                      "~/App_theme/DinaTheme/js/all.js",
                      "~/App_theme/DinaTheme/js/LoadPage.js"));

            bundles.Add(new ScriptBundle("~/bundles/body").Include(
                      "~/App_theme/DinaTheme/js/navbar.js",
                      "~/App_theme/DinaTheme/slider/assets/bootstrap/js/bootstrap.min.js",
                      "~/App_theme/DinaTheme/slider/assets/theme/js/script.js",
                      "~/App_theme/DinaTheme/slider/assets/bootstrapcarouselswipe/bootstrap-carousel-swipe.js",
                      "~/App_theme/DinaTheme/js/owl.carousel.min.js"));
            //style
            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                      "~/App_theme/DinaTheme/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/site/css").Include(
                     "~/App_theme/DinaTheme/css/all.css",
                     "~/App_theme/DinaTheme/slider/assets/web/assets/mobirise-icons/mobirise-icons.css",
                     "~/App_theme/DinaTheme/slider/assets/bootstrap/css/bootstrap.min.css",
                     "~/App_theme/DinaTheme/slider/assets/mobirise/css/mbr-additional.css",
                     "~/App_theme/DinaTheme/css/nav-style.css",
                     "~/App_theme/DinaTheme/css/owl.carousel.min.css",
                     "~/App_theme/DinaTheme/css/owl.theme.default.min.css",
                     "~/App_theme/DinaTheme/css/aos.css"));

            //bundles.Add(new StyleBundle("~/slider/css").Include(
            //          "~/App_theme/DinaTheme/css/r-slider.css"));

            bundles.Add(new StyleBundle("~/style/css").Include(
                    "~/App_theme/DinaTheme/css/style.css"));


        }
    }
}

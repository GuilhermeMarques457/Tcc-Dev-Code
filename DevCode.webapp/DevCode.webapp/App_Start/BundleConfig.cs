using System.Web;
using System.Web.Optimization;

namespace DevCode.webapp
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css",
            //          "~/Content/General.css",
            //          "~/Content/Form.css",
            //          "~/Content/Inicial.css",
            //          "~/Content/Question.css",
            //          "~/Content/Answer.css",
            //          "~/Content/User.css"
            //          ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Site.css",
                      "~/Content/General.css",
                      "~/Content/Inicial.css"
            ));


            bundles.Add(new StyleBundle("~/Form/css").Include(
                    "~/Content/Form.css"
            ));

            bundles.Add(new StyleBundle("~/User/css").Include(
                    "~/Content/User.css"
            ));

            bundles.Add(new StyleBundle("~/Question/css").Include(
                    "~/Content/Question.css"
            ));

            bundles.Add(new StyleBundle("~/Answer/css").Include(
                    "~/Content/Answer.css"
            ));

            bundles.Add(new StyleBundle("~/Inicial/css").Include(
                    "~/Content/Inicial.css"
            ));

            bundles.Add(new StyleBundle("~/News/css").Include(
                    "~/Content/News.css"
            ));

            bundles.Add(new StyleBundle("~/Amizade/css").Include(
                    "~/Content/Amizade.css"
            ));

            bundles.Add(new StyleBundle("~/MostrarAmigo/css").Include(
                    "~/Content/MostrarAmigo.css"
            ));


        }
    }
}

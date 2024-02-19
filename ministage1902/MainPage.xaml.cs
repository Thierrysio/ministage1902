using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace ministage1902
{
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();
            phaseSelenium();
        }
        public void phaseSelenium()
        {
            // Configurez Selenium pour utiliser Chrome
            var options = new ChromeOptions();
            //options.AddArgument("--headless"); // Exécutez le navigateur en mode sans tête si vous ne souhaitez pas voir la fenêtre du navigateur.

            // Spécifiez le chemin du ChromeDriver si nécessaire
            // Spécifiez le chemin du dossier contenant chromedriver.exe, pas le chemin du fichier lui-même
            var driverService = ChromeDriverService.CreateDefaultService(@"C:\Users\thier\source\repos\ministage1902\chrome");

            driverService.HideCommandPromptWindow = true; // Cache la fenêtre de commande du ChromeDriver

            using (IWebDriver driver = new ChromeDriver(driverService, options))
            {
                // Naviguez jusqu'à la page d'accueil de LDLC
                driver.Navigate().GoToUrl("https://www.ldlc.com/");

                // Acceptez les cookies si nécessaire
                // Exemple : Cliquer sur le bouton d'acceptation des cookies
                // driver.FindElement(By.Id("accept-cookies")).Click();

                // Trouvez la barre de recherche et entrez le texte de recherche
                var searchBox = driver.FindElement(By.XPath("/html/body/header/div[2]/div/div/form/div/div[2]/div[1]/input"));
                searchBox.SendKeys("carte vidéo NVIDIA" + Keys.Enter);

                // Attendez que la page des résultats se charge et traitez les résultats
                // Exemple : Lister les noms des produits trouvés
                var productNames = driver.FindElements(By.XPath("/html/body/div[4]/div/div[3]/div/div/div[2]/div[2]/ul[1]/li/div[2]/div[1]/div[1]/h3/a"));
                foreach (var productName in productNames)
                {
                    var secondProductName = productNames[1]; // Accédez au deuxième élément (index 1)
                    
                    string res = secondProductName.Text;
                }
            }
        }


    }

}

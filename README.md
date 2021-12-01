# APL
Questo file ha lo scopo di illustrare le principali caratteristiche dei moduli dell'applicazione realizzata come progetto per l'insegnamento di Advanced Programming Languages.


## Web Scraping (Python)
Il modulo per effettuare lo scraping sul sito IMDB è realizzato interamente in Python e sfrutta la libreria esterna BeautifulSoup che offre svariati metodi per recuperare informazioni dai DOM ricavati mediante richieste HTTP. Infatti come è possibile vedere dal file sorgente "scraper.py", una volta istanziato un ogetto di tipo BeautifulSoup passando in ingresso la risposta HTTP (che sarebbe una pagina HTML) e il tipo di parser da adottare, mediante questo oggetto possiamo ricavare tutte le informazioni che servono.
Finita la fase di scraping, i dati vengono poi conservati sia in un CSV che su una collezione di MongoDB; il CSV sarà successivamente analizzato dal modulo R per generare i grafici che saranno forniti al FE. 


## R Module
Grazie ad uno script realizzato in R e all'utilizzo della libreria "Plumber" ricavata da CRAN (https://cran.r-project.org/web/packages/plumber/index.html) siamo riusciti a realizzare due diversi grafici:
- Relationship between Movie Runtime and IMDb Movie Rating
- Relationship between Movie Release Year and IMDb Movie Rating

I grafici in questione, una volta generati e salvati nel server in cui viene lanciata l'applicazione in R, vengono recuperati dal FE mediante delle API REST che vengono esposte grazie all'utilizzo della libreria "Plumber" citata sopra; grazie a questo meccanismo è infatti possibile sfruttare il protocollo HTTP in maniera rapida e veloce per far comunicare i vari moduli.


## C# Module
Il FE della nostra applicazione è interamente realizzato in C# sfruttando "Windows Forms", ovvero una interfaccia grafica open-source fornita da Microsoft che sfrutta il framework .NET per C#; grazie a questa interfaccia grafica abbiamo realizzato quindi una applicazione client Desktop.
Il FE sostanzialmente è caratterizzato da due Form principali:
- Welcome (utilizzato per il login e per la registrazione)
- Dashboard (richiama altri forms "figli")

Gli altri form invece, quelli richiamati come "figli" dal form Dashboard sono:
- DashboardPlotForm (utilizzato per mostrare i grafici ottenuti chiamando l'API esposta dal modulo in R)
- SearchFilmsForm (utilizzato per effettuare ricerche di film mediante una chiamata alle API esposte da IMDB)
- YourFavouritesMovies (utilizzato per mostrare i film che sono stati aggiunti ai preferiti dall'utente loggato; i film sono recuperati mediante una chiamata HTTP al BE)

Il form Dashboard è sostanzialmente caratterizzato da due diversi pannelli, ovvero uno che richiama al suo interno i 3 form visti sopra a seconda dell'operazione scelta dall'utente, ed uno che consente di mostraare e gestire i risultati che vengono ottenuti dagli altri form.


## Go (Golang) Module
Il BE del nostro progetto è stato realizzato interamente in Go ed espone delle API REST grazie all'utilizzo del framwork "Gin Gonic Web Framework" (https://pkg.go.dev/github.com/gin-gonic/gin@v1.7.4) che consente di creare un web server in grado di esporre le API utilizzando delle route specifiche (richiede una versione di Go >= 1.12).
Il FE quindi non effettuerà delle chiamate dirette verso MongoDB, ma grazie alle API esposte dal BE sarà in grado di effettuare le CRUD sulle varie entità gestite dall'applicazione. Si è cercato quindi di rispettare le caratteristiche dei metodi HTTP:
- GET   ->  utilizzato semplicemente per recuperare dati dal DB
- POST  ->  effettuare update di entità (usata per assegnare un voto ad uno dei film tra i preferiti)
- PUT   ->  inserire nuove entità (usata per la registrazione di nuovi utenti o per l'agggiunta di un film tra i preferiti)

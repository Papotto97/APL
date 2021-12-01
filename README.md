# APL

## Web Scraping
Il modulo per effettuare lo scraping sul sito IMDB è realizzato interamente in Python e sfrutta la libreria esterna BeautifulSoup che offre svariati metodi per recuperare informazioni dai DOM ricavati mediante richieste HTTP. Infatti come è possibile vedere dal file sorgente "scraper.py", una volta istanziato un ogetto di tipo BeautifulSoup passando in ingresso la risposta HTTP (che sarebbe una pagina HTML) e il tipo di parser da adottare, mediante questo oggetto possiamo ricavare tutte le informazioni che servono.
Finita la fase di scraping, i dati vengono poi conservati sia in un CSV che su una collezione di MongoDB; il CSV sarà successivamente analizzato dal modulo R per generare i grafici che saranno forniti al FE. 

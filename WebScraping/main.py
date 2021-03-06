import os
from dotenv import load_dotenv
from scraping.scraper import movie_scraper
from database.client import MongoDBClient
from utils.printer import movie_printer

def main():
    load_dotenv()
    print("=========================================================")
    print("Papotto Placido")
    print("Restivo Luca")
    print("Russo Salvatore")
    print("=========================================================")
    print("")
    print("*********************************************************")
    print("Top 1000 IMDb Movie Scraper v",  os.environ.get("VERSION"))
    print("*********************************************************")
    print("")
    movies = movie_scraper()
    print("Scraped movies:", len(movies))
    print("Saving data")
    client = MongoDBClient(
        os.environ.get("MONGO_HOST"), 
        int(os.environ.get("MONGO_PORT")), 
        os.environ.get("MONGO_DB"), 
        os.environ.get("MONGO_COLLECTION")
    )
    client.insertMany(movies)
    movie_printer(movies)
    print("Finish")
    
if __name__ == "__main__":
    main()

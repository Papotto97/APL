import os
from dotenv import load_dotenv
from scraping.scraper import movie_scraper
from database.client import MongoDBClient

def main():
    load_dotenv()
    print("Top 500 Metacritic Movie Scraper v",  os.environ.get("VERSION"))
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
    print("Finish")
    
if __name__ == "__main__":
    main()

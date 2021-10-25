from pymongo import MongoClient

class MongoDBClient:
    def __init__(self):
        self.client = MongoClient(host="localhost", port=27017)
        self.db = self.client['APL']
        self.collection = self.db['scraped_movies']

    def insertOne(self, document):
        return self.collection.insert_one(document)

    def insertMany(self, documents):
        return self.collection.insert_many(documents)
from pymongo import MongoClient

class MongoDBClient:
    def __init__(self, host, port, db, collection):
        self.client = MongoClient(host=host, port=port)
        self.db = self.client[db]
        self.collection = self.db[collection]
        print("Initializing connection: [monogdb://", host, ":", port, "/", db, "]", sep='')

    def insertOne(self, document):
        return self.collection.insert_one(document)

    def insertMany(self, documents):
        return self.collection.insert_many(documents)
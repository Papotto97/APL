package config

import (
	"context"
	"fmt"
	"log"
	"time"

	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
)

const (
	//Timeout settings
	connectionTimeout        = 5
	connectionStringTemplate = "mongodb://%s:%s/?readPreference=primary&appname=MongoDBCompass&directConnection=true&ssl=false"
)

//MongoDB getConnection function
func GetConnection() (*mongo.Client, context.Context, context.CancelFunc) {
	//username := os.Getenv("MONGODB_USERNAME")
	//password := os.Getenv("MONGODB_PASSWORD")
	hostname := "localhost"
	port := "27017"
	log.Printf(port)

	connectionURI := fmt.Sprintf(connectionStringTemplate, hostname, port)

	client, err := mongo.NewClient(options.Client().ApplyURI(connectionURI))
	if err != nil {
		log.Printf("Failed to create client: %v", err)
	}

	ctx, cancel := context.WithTimeout(context.Background(), connectionTimeout*time.Second)

	err = client.Connect(ctx)
	if err != nil {
		log.Printf("Failed to connect to cluster: %v", err)
	}

	// Force a connection to verify our connection string
	err = client.Ping(ctx, nil)
	if err != nil {
		log.Printf("Failed to ping cluster: %v", err)
	}

	fmt.Println("Connected to Mongo DB")
	return client, ctx, cancel
}

package config

import (
	"context"
	"fmt"
	"go.mongodb.org/mongo-driver/mongo"
	"go.mongodb.org/mongo-driver/mongo/options"
	"log"
	"time"
)

const (
	//Timeout settings
	connectionTimeout        = 5
	connectionStringTemplate = "mongodb://%s:%s/?readPreference=primary&appname=MongoDBCompass&directConnection=true&ssl=false"
)

//MongoDB getConnection function
func GetConnection() (*mongo.Client, context.Context, context.CancelFunc) {
	//username := os.Getenv("MONGODB_USERNAME")
	username := "localhost"
	log.Printf(username)
	//password := os.Getenv("MONGODB_PASSWORD")
	password := "27017"
	log.Printf(password)

	connectionURI := fmt.Sprintf(connectionStringTemplate, username, password)

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
